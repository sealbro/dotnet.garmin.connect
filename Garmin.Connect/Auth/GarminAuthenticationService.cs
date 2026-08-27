using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Garmin.Connect.Auth.External;
using Garmin.Connect.OAuth;

namespace Garmin.Connect.Auth;

internal class GarminAuthenticationService
{
    private readonly IAuthParameters _authParameters;
    private readonly IMfaCodeProvider _userMfaCodeProviderService;
    private readonly HttpClient _httpClient;
    private const uint MaxNumberOfRedirects = 3;
    private string SsoUrl => $"https://sso.{_authParameters.Domain}/sso";
    private string EmbedUrl => $"{SsoUrl}/embed";
    private string SigninUrl => $"{SsoUrl}/signin";
    private string MfaCodeURL => $"{SsoUrl}/verifyMFA/loginEnterMfaCode";

    public GarminAuthenticationService(
        HttpClient httpClient,
        IAuthParameters authParameters,
        IMfaCodeProvider userMfaCodeProviderService)
    {
        _authParameters = authParameters;
        _userMfaCodeProviderService = userMfaCodeProviderService;
        _httpClient = httpClient;
    }

    public async Task<(OAuth1Token OAuth1Token, OAuth2Token OAuth2Token)> RefreshGarminAuthenticationAsync(CancellationToken cancellationToken)
    {
        _authParameters.Cookies = await RequestCookies(cancellationToken);
        _authParameters.Csrf = await RequestCsrfToken(cancellationToken);

        var ticket = await GetOAuthTicket(cancellationToken);
        var consumerCredentials = _authParameters.ConsumerCredentials;

        var auth1Token = await GetOAuth1Token(ticket, consumerCredentials, cancellationToken);

        try
        {
            var auth2Token = await GetOAuth2TokenAsync(auth1Token, consumerCredentials, cancellationToken);
            return (auth1Token, auth2Token);
        }
        catch (Exception e) when (e is not GarminConnectAuthenticationException)
        {
            throw new GarminConnectAuthenticationException("Auth appeared successful but failed to get the OAuth2 token.", e)
            { Code = Code.OAuth2TokenNotFound };
        }
    }

    /// <summary>
    /// Renews an OAuth2 access token from a previously cached, still-valid OAuth1 token.
    /// Skips the cookie/CSRF/ticket dance entirely, so it is both cheaper and far less
    /// likely to hit Garmin's Cloudflare rate limiting than a full re-login.
    /// </summary>
    public Task<OAuth2Token> ExchangeOAuth1TokenAsync(OAuth1Token oAuth1Token, CancellationToken cancellationToken) =>
        GetOAuth2TokenAsync(oAuth1Token, _authParameters.ConsumerCredentials, cancellationToken);

    private async Task<string> RequestCookies(CancellationToken cancellationToken)
    {
        var queryEmbed = HttpUtility.ParseQueryString(string.Empty);
        foreach (var kv in _authParameters.GetQueryParameters())
        {
            queryEmbed.Add(kv.Key, kv.Value);
        }

        queryEmbed.Add("gauthHost", SsoUrl);

        var requestUriEmbed = $"{EmbedUrl}?{queryEmbed}";

        using var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, requestUriEmbed);
        foreach (var kv in _authParameters.GetHeaders())
        {
            httpRequestMessage.Headers.Add(kv.Key, kv.Value);
        }

        var responseMessage = await _httpClient.SendAsync(httpRequestMessage, cancellationToken);

        if (responseMessage.StatusCode != HttpStatusCode.OK)
            throw new GarminConnectAuthenticationException("Failed to fetch cookies from Garmin.")
            { Code = Code.CookiesNotFound };

        // TryGetValues is case-insensitive: HTTP/2 lower-cases header names.
        if (!responseMessage.Headers.TryGetValues("Set-Cookie", out var headerCookies))
            throw new GarminConnectAuthenticationException("Garmin returned no Set-Cookie header.")
            { Code = Code.CookiesNotFound };

        var cookies = BuildCookieHeader(headerCookies);

        if (string.IsNullOrWhiteSpace(cookies))
            throw new GarminConnectAuthenticationException("Found cookies but they are null.")
            { Code = Code.CookiesNotFound };

        return cookies;
    }

    /// <summary>
    /// Turns Set-Cookie values into a Cookie header: only the leading name=value pair of each
    /// directive belongs there, the attributes (Path, Expires, HttpOnly, ...) do not.
    /// </summary>
    private static string BuildCookieHeader(IEnumerable<string> setCookieValues)
    {
        var pairs = new Dictionary<string, string>(StringComparer.Ordinal);

        foreach (var setCookie in setCookieValues)
        {
            if (string.IsNullOrWhiteSpace(setCookie))
                continue;

            var separatorIndex = setCookie.IndexOf(';');
            var pair = (separatorIndex < 0 ? setCookie : setCookie.Substring(0, separatorIndex)).Trim();

            var equalsIndex = pair.IndexOf('=');
            if (equalsIndex <= 0)
                continue;

            // a later Set-Cookie for the same name replaces the earlier one
            pairs[pair.Substring(0, equalsIndex)] = pair;
        }

        return string.Join("; ", pairs.Values);
    }

    private string FindCsrfToken(string rawResponseBody, Code failureStepCode)
    {
        if (string.IsNullOrEmpty(rawResponseBody))
            throw new GarminConnectAuthenticationException("Failed to find csrf token. content is null or empty.")
            { Code = failureStepCode };

        var tokenRegex = new Regex("name=\"_csrf\"\\s+value=\"(?<csrf>.+?)\"");
        var match = tokenRegex.Match(rawResponseBody);
        if (!match.Success)
            throw new GarminConnectAuthenticationException($"Failed to find regex match for csrf token. tokenResult: {rawResponseBody}") { Code = failureStepCode };

        var csrfToken = match.Groups.GetValueOrDefault("csrf")?.Value;

        if (string.IsNullOrWhiteSpace(csrfToken))
            throw new GarminConnectAuthenticationException("Found csrfToken but its null.") { Code = failureStepCode };

        return csrfToken;
    }

    private async Task<string> RequestCsrfToken(CancellationToken cancellationToken)
    {
        var parameters = new Dictionary<string, string>(_authParameters.GetQueryParameters());
        parameters.Add("gauthHost", EmbedUrl);
        parameters.Add("service", EmbedUrl);
        parameters.Add("source", EmbedUrl);
        parameters.Add("redirectAfterAccountLoginUrl", EmbedUrl);
        parameters.Add("redirectAfterAccountCreationUrl", EmbedUrl);

        var queryCsrf = HttpUtility.ParseQueryString(string.Empty);
        foreach (var kv in parameters)
        {
            queryCsrf.Add(kv.Key, kv.Value);
        }

        var requestUriSignin = $"{SigninUrl}?{queryCsrf}";
        using var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, requestUriSignin);
        foreach (var kv in _authParameters.GetHeaders())
        {
            httpRequestMessage.Headers.Add(kv.Key, kv.Value);
        }

        var responseMessage = await _httpClient.SendAsync(httpRequestMessage, cancellationToken);

        if (responseMessage.StatusCode != HttpStatusCode.OK)
            throw new GarminConnectAuthenticationException("Failed to fetch csrf token from Garmin.")
            { Code = Code.CsrfTokenNotFound };

        var content = await responseMessage.Content.ReadAsStringAsync(cancellationToken);
        var csrf = FindCsrfToken(content, Code.CsrfTokenNotFound);

        return csrf;
    }

    public async Task<string> CompleteMfaAuthAsync(string mfaCode, CancellationToken cancellationToken)
    {
        var qParams = new Dictionary<string, string>(_authParameters.GetQueryParameters());
        qParams.Add("gauthHost", EmbedUrl);
        qParams.Add("service", EmbedUrl);
        qParams.Add("source", EmbedUrl);
        qParams.Add("redirectAfterAccountLoginUrl", EmbedUrl);
        qParams.Add("redirectAfterAccountCreationUrl", EmbedUrl);

        var queryMfa = HttpUtility.ParseQueryString(string.Empty);
        foreach (var kv in qParams)
        {
            queryMfa.Add(kv.Key, kv.Value);
        }
        var requestMfa = $"{MfaCodeURL}?{queryMfa}";

        var parameters = new Dictionary<string, string>(_authParameters.GetMfaParameters());
        parameters.Add("mfa-code", mfaCode);

        // Send the MFA Code to Garmin

        using var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, requestMfa);
        foreach (var kv in _authParameters.GetHeaders())
        {
            httpRequestMessage.Headers.Add(kv.Key, kv.Value);
        }
        httpRequestMessage.Content = new FormUrlEncodedContent(parameters);

        var responseMessage = await _httpClient.SendAsync(httpRequestMessage, cancellationToken);
        if (responseMessage.StatusCode == HttpStatusCode.Redirect)
        {
            var content = await HandleRedirect(responseMessage, cancellationToken, 0);
            return content;
        }
        else if (responseMessage.IsSuccessStatusCode)
        {
            return await responseMessage.Content.ReadAsStringAsync(cancellationToken);
        }
        else
        {
            var responseContent = await responseMessage.Content.ReadAsStringAsync(cancellationToken);
            if (responseContent == "error code: 1020")
                throw new GarminConnectAuthenticationException(
                    "MFA: Garmin Authentication Failed. Blocked by CloudFlare.")
                {
                    Code = Code.MfaBlockedCloudflare
                };
            throw new GarminConnectAuthenticationException("MFA: MFA Code rejected by Garmin.")
            {
                Code = Code.MfaInvalidCode
            };
        }
    }

    private async Task<string> HandleRedirect(HttpResponseMessage msg, CancellationToken cancellationToken, uint currentRedirectCount)
    {
        if (currentRedirectCount == MaxNumberOfRedirects) //zerobased counting
            return string.Empty;

        var redirectUrl = msg.Headers.Location;
        //get the redirect url manually:
        using var httpRequestMessageRedirect = new HttpRequestMessage(HttpMethod.Get, redirectUrl);

        using var responseMessageRedirect = await _httpClient.SendAsync(httpRequestMessageRedirect, cancellationToken);
        while (responseMessageRedirect.StatusCode == HttpStatusCode.Redirect)
        {
            return await HandleRedirect(responseMessageRedirect, cancellationToken, currentRedirectCount + 1);
        }

        return await responseMessageRedirect.Content.ReadAsStringAsync(cancellationToken);
    }

    private async Task<string> GetOAuthTicket(CancellationToken cancellationToken)
    {
        var parameters = new Dictionary<string, string>(_authParameters.GetQueryParameters())
        {
            { "gauthHost", EmbedUrl },
            { "service", EmbedUrl },
            { "source", EmbedUrl },
            { "redirectAfterAccountLoginUrl", EmbedUrl },
            { "redirectAfterAccountCreationUrl", EmbedUrl }
        };

        var queryCsrf = HttpUtility.ParseQueryString(string.Empty);
        foreach (var kv in parameters)
        {
            queryCsrf.Add(kv.Key, kv.Value);
        }

        var requestUriSignin = $"{SigninUrl}?{queryCsrf}";

        HttpResponseMessage responseMessage;
        var i = 0;
        const int TooManyRequestsAttempts = 5;
        do
        {
            using var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, requestUriSignin);
            foreach (var kv in _authParameters.GetHeaders())
            {
                httpRequestMessage.Headers.Add(kv.Key, kv.Value);
            }

            httpRequestMessage.Headers.Add("referer", SigninUrl);
            httpRequestMessage.Headers.Add("NK", "NT");
            httpRequestMessage.Content = new FormUrlEncodedContent(_authParameters.GetFormParameters());

            responseMessage = await _httpClient.SendAsync(httpRequestMessage, cancellationToken);
            if (responseMessage.StatusCode != HttpStatusCode.TooManyRequests)
            {
                break;
            }
            i++;
            await Task.Delay(TimeSpan.FromSeconds(3 * i), cancellationToken);
        } while (i < TooManyRequestsAttempts);

        var content = await responseMessage.Content.ReadAsStringAsync(cancellationToken);
        responseMessage.Dispose();

        if (responseMessage.StatusCode is HttpStatusCode.TooManyRequests or HttpStatusCode.Forbidden)
        {
            throw new GarminConnectAuthenticationException(
                    $"Garmin Authentication Failed after {i} attempts. {responseMessage.StatusCode}: {content}")
            { Code = Code.OAuth1TicketNotFound };
        }

        var isRedirectMfaFlow = responseMessage.StatusCode == HttpStatusCode.Found
                                && responseMessage.Headers.Location != null
                                && responseMessage.Headers.Location.ToString()
                                    .Contains(MfaCodeURL);

        // check if the MFA code resend cooldown and can reuse the old code
        var isMfaCodeCooldown = responseMessage.StatusCode is HttpStatusCode.OK
                             && content.Contains("validateMfaCodeAndPrivacyConsents()");

        // Handle MFA, important: this needs the injected HTTP client to not handle redirects automatically
        // didn't look for a way to detect the redirect with automatic redirect
        // this would allow to use an HTTPClient with (default) HTTP redirect set to auto
        if (isRedirectMfaFlow || isMfaCodeCooldown)
        {
            if (isRedirectMfaFlow)
            {
                // handle redirect manually
                content = await HandleRedirect(responseMessage, cancellationToken, 0);
            }

            // extract new csrf token for MFA Code flow
            _authParameters.Csrf = FindCsrfToken(content, Code.CsrfTokenNotFound);
            // get the MFA code from the user:
            var mfaCode = await _userMfaCodeProviderService.GetMfaCodeAsync();
            // complete MFA code flow
            if (string.IsNullOrEmpty(mfaCode))
            {
                throw new GarminConnectAuthenticationException("MFA Code provided is empty!")
                {
                    Code = Code.MfaInvalidCode
                };
            }

            content = await CompleteMfaAuthAsync(mfaCode, cancellationToken);
        }

        var regexTicket = new Regex(@"embed\?ticket=([^""]+)""", RegexOptions.Compiled | RegexOptions.Multiline);
        var match = regexTicket.Match(content);
        if (!match.Success)
            throw new GarminConnectAuthenticationException("Failed to find regex match for ticket.")
            { Code = Code.OAuth1TicketNotFound };

        var ticket = match.Groups[1].Value;

        if (string.IsNullOrWhiteSpace(ticket))
            throw new GarminConnectAuthenticationException("Found ticket but its null.")
            { Code = Code.OAuth1TicketNotFound };

        return ticket;
    }

    private async Task<OAuth1Token> GetOAuth1Token(string ticket, ConsumerCredentials credentials,
        CancellationToken cancellationToken)
    {
        string oauth1Response;
        try
        {
            var oauthClient = OAuthRequest.ForRequestToken(credentials.ConsumerKey, credentials.ConsumerSecret);
            oauthClient.RequestUrl =
                $"https://connectapi.{_authParameters.Domain}/oauth-service/oauth/preauthorized?ticket={ticket}&login-url=https://sso.garmin.com/sso/embed&accepts-mfa-tokens=true";

            using var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, oauthClient.RequestUrl);
            httpRequestMessage.Headers.Add("User-Agent", _authParameters.UserAgent);
            httpRequestMessage.Headers.Add("Authorization", oauthClient.GetAuthorizationHeader());

            var responseMessage = await _httpClient.SendAsync(httpRequestMessage, cancellationToken);

            oauth1Response = await responseMessage.Content.ReadAsStringAsync(cancellationToken);
        }
        catch (Exception e)
        {
            throw new GarminConnectAuthenticationException("Auth appeared successful but failed to get the OAuth1 token.", e)
            { Code = Code.OAuth1TokenNotFound };
        }

        if (string.IsNullOrWhiteSpace(oauth1Response))
            throw new GarminConnectAuthenticationException(
                    "Auth appeared successful but returned OAuth1 Token response is null.")
            { Code = Code.OAuth1TokenNotFound };

        var queryParams = HttpUtility.ParseQueryString(oauth1Response);

        var oAuthToken = queryParams.Get("oauth_token");
        var oAuthTokenSecret = queryParams.Get("oauth_token_secret");

        if (string.IsNullOrWhiteSpace(oAuthToken))
            throw new GarminConnectAuthenticationException(
                    $"Auth appeared successful but returned OAuth1 token is null. oauth1Response: {oauth1Response}")
            { Code = Code.OAuth1TokenNotFound };

        if (string.IsNullOrWhiteSpace(oAuthTokenSecret))
            throw new GarminConnectAuthenticationException(
                    $"Auth appeared successful but returned OAuth1 token secret is null. oauth1Response: {oauth1Response}")
            { Code = Code.OAuth1TokenNotFound };

        return new OAuth1Token
        {
            Token = oAuthToken,
            TokenSecret = oAuthTokenSecret
        };
    }


    private async Task<OAuth2Token> GetOAuth2TokenAsync(OAuth1Token oAuth1Token, ConsumerCredentials credentials,
        CancellationToken cancellationToken)
    {
        var oauth2Client = OAuthRequest.ForProtectedResource("POST", credentials.ConsumerKey,
            credentials.ConsumerSecret, oAuth1Token.Token, oAuth1Token.TokenSecret);
        oauth2Client.RequestUrl = $"https://connectapi.{_authParameters.Domain}/oauth-service/oauth/exchange/user/2.0";

        using var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, oauth2Client.RequestUrl);
        httpRequestMessage.Headers.Add("User-Agent", _authParameters.UserAgent);
        httpRequestMessage.Headers.Add("Authorization", oauth2Client.GetAuthorizationHeader());

        httpRequestMessage.Content = new FormUrlEncodedContent([new KeyValuePair<string, string>()]);
        var responseMessage = await _httpClient.SendAsync(httpRequestMessage, cancellationToken);

        var content = await responseMessage.Content.ReadAsStringAsync(cancellationToken);

        if (!responseMessage.IsSuccessStatusCode)
            throw new GarminConnectAuthenticationException(
                    $"Failed to exchange OAuth1 token for OAuth2 token. {responseMessage.StatusCode}: {content}")
            { Code = Code.OAuth2TokenNotFound };

        var token = JsonSerializer.Deserialize<OAuth2Token>(content);

        if (string.IsNullOrWhiteSpace(token?.AccessToken))
            throw new GarminConnectAuthenticationException(
                    $"Auth appeared successful but returned OAuth2 access token is null. content: {content}")
            { Code = Code.OAuth2TokenNotFound };

        return token;
    }
}