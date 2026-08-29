using System;
using System.IO;
using System.Net.Http;
using System.Security.Authentication;
using Garmin.Connect.Auth;

namespace Garmin.Connect.Tests;

public static class LazyContext
{
    public static readonly Lazy<GarminConnectContext> Context = new(() =>
    {
        var handler = new HttpClientHandler();
        handler.SslProtocols = SslProtocols.Tls13 | SslProtocols.Tls12;
        var httpClient = new HttpClient(handler);

        var mfaCode = new NotImplementedMfaCode();

        var userProfile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        var fileTokenCache = new FileTokenCache(Path.Combine(userProfile, ".garmin_token.json"));
        var loggingTokenCache = new LoggingTokenCache(fileTokenCache, Path.Combine(userProfile, ".garmin_token_refresh.log"));

        return new GarminConnectContext(httpClient,
            new BasicAuthParameters(
                TestEnvironment.GetRequired("GARMIN_LOGIN"),
                TestEnvironment.GetRequired("GARMIN_PASSWORD")), mfaCode, loggingTokenCache);
    });
}
