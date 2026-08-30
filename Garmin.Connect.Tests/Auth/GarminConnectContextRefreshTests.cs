using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Garmin.Connect.Auth;
using Garmin.Connect.Auth.External;

namespace Garmin.Connect.Tests.Auth;

public class GarminConnectContextRefreshTests
{
    private sealed class StubTokenCache : ITokenCache
    {
        public OAuth1Token? OAuth1;
        public OAuth2Token? OAuth2;

        public Task<OAuth2Token> GetOAuth2Token(CancellationToken cancellationToken) => Task.FromResult(OAuth2!);

        public Task SetOAuth2Token(OAuth2Token token, CancellationToken cancellationToken)
        {
            OAuth2 = token;
            return Task.CompletedTask;
        }

        public Task<OAuth1Token> GetOAuth1Token(CancellationToken cancellationToken) => Task.FromResult(OAuth1!);

        public Task SetOAuth1Token(OAuth1Token token, CancellationToken cancellationToken)
        {
            OAuth1 = token;
            return Task.CompletedTask;
        }
    }

    /// <summary>
    /// Only understands the OAuth2 exchange endpoint and the actual API call. Any request that
    /// belongs to the full SSO login flow (cookies/csrf/ticket) is counted separately so tests can
    /// assert whether a full login was attempted.
    /// </summary>
    private sealed class FakeGarminHandler : HttpMessageHandler
    {
        public int ExchangeCalls;
        public int FullLoginCalls;
        public HttpStatusCode ExchangeStatusCode = HttpStatusCode.OK;

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            var url = request.RequestUri!.ToString();

            if (url.Contains("/oauth-service/oauth/exchange/user/2.0"))
            {
                ExchangeCalls++;

                if (ExchangeStatusCode != HttpStatusCode.OK)
                    return Task.FromResult(new HttpResponseMessage(ExchangeStatusCode)
                    {
                        Content = new StringContent("rejected", Encoding.UTF8, "text/plain")
                    });

                const string json = "{\"access_token\":\"new-access-token\",\"token_type\":\"Bearer\"," +
                                     "\"refresh_token\":\"rt\",\"expires_in\":3600,\"refresh_token_expires_in\":7200}";
                return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(json, Encoding.UTF8, "application/json")
                });
            }

            if (url.Contains("connect.garmin.com"))
            {
                return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent("{}", Encoding.UTF8, "application/json")
                });
            }

            // sso.garmin.com / connectapi.garmin.com oauth1 steps — belongs to the full login flow
            FullLoginCalls++;
            return Task.FromResult(new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new StringContent("not implemented by fake", Encoding.UTF8, "text/plain")
            });
        }
    }

    [Test]
    public async Task MakeHttpGet_WithCachedOAuth1Token_RenewsViaExchange_WithoutFullLogin()
    {
        var handler = new FakeGarminHandler();
        var httpClient = new HttpClient(handler);
        var tokenCache = new StubTokenCache { OAuth1 = new OAuth1Token { Token = "t", TokenSecret = "s" } };
        var context = new GarminConnectContext(httpClient, new BasicAuthParameters("user", "pass"),
            new NotImplementedMfaCode(), tokenCache);

        using var response = await context.MakeHttpGet("/some/path");

        await Assert.That(handler.ExchangeCalls).IsEqualTo(1);
        await Assert.That(handler.FullLoginCalls).IsEqualTo(0);
        await Assert.That(tokenCache.OAuth2?.AccessToken).IsEqualTo("new-access-token");
    }

    [Test]
    public async Task MakeHttpGet_WhenCachedOAuth1TokenIsRejected_FallsBackToFullLogin()
    {
        var handler = new FakeGarminHandler { ExchangeStatusCode = HttpStatusCode.Unauthorized };
        var httpClient = new HttpClient(handler);
        var tokenCache = new StubTokenCache { OAuth1 = new OAuth1Token { Token = "t", TokenSecret = "s" } };
        var context = new GarminConnectContext(httpClient, new BasicAuthParameters("user", "pass"),
            new NotImplementedMfaCode(), tokenCache);

        await Assert.That(async () => await context.MakeHttpGet("/some/path"))
            .Throws<GarminConnectAuthenticationException>();

        await Assert.That(handler.ExchangeCalls).IsEqualTo(1);
        await Assert.That(handler.FullLoginCalls).IsGreaterThan(0);
    }

    [Test]
    public async Task MakeHttpGet_WithoutCachedOAuth1Token_GoesStraightToFullLogin()
    {
        var handler = new FakeGarminHandler();
        var httpClient = new HttpClient(handler);
        var tokenCache = new StubTokenCache();
        var context = new GarminConnectContext(httpClient, new BasicAuthParameters("user", "pass"),
            new NotImplementedMfaCode(), tokenCache);

        await Assert.That(async () => await context.MakeHttpGet("/some/path"))
            .Throws<GarminConnectAuthenticationException>();

        await Assert.That(handler.ExchangeCalls).IsEqualTo(0);
        await Assert.That(handler.FullLoginCalls).IsGreaterThan(0);
    }
}
