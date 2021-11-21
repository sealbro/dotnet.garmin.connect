using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using Garmin.Connect.Auth;
using Garmin.Connect.Converters;
using Garmin.Connect.Exceptions;
using Garmin.Connect.Models;

namespace Garmin.Connect;

public class GarminConnectContext
{
    private readonly HttpClient _httpClient;
    private readonly IAuthParameters _authParameters;

    public GarminConnectContext(HttpClient httpClient, IAuthParameters authParameters)
    {
        _httpClient = httpClient;
        _authParameters = authParameters;
    }

    public async Task ReLoginIfExpired(bool force = false)
    {
        if (force || _authParameters.NeedReLogin)
        {
            var (cookies, preferences, profile) = await Login();

            _authParameters.Cookies = cookies;
            Preferences = preferences;
            Profile = profile;
        }
    }

    public GarminSocialProfile Profile { get; private set; }

    public GarminUserPreferences Preferences { get; private set; }

    public async Task<HttpResponseMessage> MakeHttpGet(string url)
    {
        const int attempts = 3;
        var force = false;

        for (var i = 0; i < attempts; i++)
        {
            try
            {
                await ReLoginIfExpired(force);

                var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, $"{_authParameters.BaseUrl}{url}");

                httpRequestMessage.Headers.Add("Cookie", _authParameters.Cookies);
                var response = await _httpClient.SendAsync(httpRequestMessage);

                RaiseForStatus(response);

                return response;
            }
            catch (GarminConnectRequestException e)
            {
                if (e.Status == HttpStatusCode.Forbidden)
                {
                    force = true;
                    continue;
                }

                Debug.WriteLine(e.Message);
                throw;
            }
        }

        throw new GarminConnectAuthenticationException($"Authentication fail after {attempts} attempts");
    }

    public async Task<T> GetAndDeserialize<T>(string url)
    {
        var response = await MakeHttpGet(url);
        var json = await response.Content.ReadAsStringAsync();

        // Console.WriteLine($"{url}\n{json}\n\n\n");
        // return default;

        return GarminSerializer.To<T>(json);
    }

    private async Task<(string authUrl, string cookies)> GetAuthCookies()
    {
        var queryParams = _authParameters.GetQueryParameters();
        var fromParams = _authParameters.GetFormParameters();
        var headers = _authParameters.GetHeaders();

        var queryString = HttpUtility.ParseQueryString("");
        foreach (var (key, value) in queryParams)
        {
            queryString.Add(key, value);
        }

        var signinUrl = $"{_authParameters.SigninUrl}?{queryString}";

        var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, signinUrl);

        foreach (var (key, value) in headers)
        {
            httpRequestMessage.Headers.Add(key, value);
        }

        await _httpClient.SendAsync(httpRequestMessage);

        httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, signinUrl);
        foreach (var (key, value) in headers)
        {
            httpRequestMessage.Headers.Add(key, value);
        }

        httpRequestMessage.Content = new FormUrlEncodedContent(fromParams);
        var response = await _httpClient.SendAsync(httpRequestMessage);

        RaiseForStatus(response);

        var html = await response.Content.ReadAsStringAsync();
        var responseUrlRegex = new Regex(@"""(https:[^""]+?ticket=[^""]+)""", RegexOptions.Compiled);
        var responseUrlMatch = responseUrlRegex.Match(html);
        if (!responseUrlMatch.Success)
        {
            throw new GarminConnectAuthenticationException();
        }

        var responseUrl = responseUrlMatch.Groups[1].Value.Replace("\\", string.Empty);

        var cookies = response.Headers.SingleOrDefault(header => header.Key == "Set-Cookie").Value;
        var sb = new StringBuilder();
        foreach (var cookie in cookies)
        {
            sb.Append($"{cookie};");
        }

        return (responseUrl, sb.ToString());
    }

    private async Task<(string cookies, GarminUserPreferences preferences, GarminSocialProfile profile)> Login()
    {
        var (authUrl, cookies) = await GetAuthCookies();

        var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, authUrl);

        httpRequestMessage.Headers.Add("Cookie", cookies);
        var response = await _httpClient.SendAsync(httpRequestMessage);

        RaiseForStatus(response);

        var html = await response.Content.ReadAsStringAsync();

        var userPreferences = ParseJson<GarminUserPreferences>(html, "VIEWER_USERPREFERENCES");
        var socialProfile = ParseJson<GarminSocialProfile>(html, "VIEWER_SOCIAL_PROFILE");

        return (cookies, userPreferences, socialProfile);
    }

    private static void RaiseForStatus(HttpResponseMessage response)
    {
        switch (response.StatusCode)
        {
            case HttpStatusCode.TooManyRequests:
                throw new GarminConnectTooManyRequestsException();
            case HttpStatusCode.OK:
                return;
            default:
            {
                var url = response.RequestMessage?.RequestUri?.ToString() ?? string.Empty;

                throw new GarminConnectRequestException(url, response.StatusCode);
            }
        }
    }

    private static TModel ParseJson<TModel>(string html, string key)
    {
        var dataRegex = new Regex(key + @" = JSON\.parse\(\""(.*)\""\);", RegexOptions.Compiled);
        var dataMatch = dataRegex.Match(html);

        if (dataMatch.Success)
        {
            var json = dataMatch.Groups[1].Value.Replace("\\\"", "\"");
            var model = JsonSerializer.Deserialize<TModel>(json);
            if (model != null)
            {
                return model;
            }
        }

        throw new GarminConnectUnexpectedException(key);
    }
}