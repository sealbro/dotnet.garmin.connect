using System;
using System.IO;
using System.Net.Http;
using System.Security.Authentication;
using Garmin.Connect.Auth;

namespace Garmin.Connect.Tests;

public static class LazyClient
{
    public static readonly Lazy<IGarminConnectClient> Garmin = new(() =>
    {
        var handler = new HttpClientHandler();
        handler.SslProtocols = SslProtocols.Tls13 | SslProtocols.Tls12;
        var httpClient = new HttpClient(handler);

        var mfaCode = new NotImplementedMfaCode();

        var fileTokenCache = new FileTokenCache(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".garmin_token.json"));
        return new GarminConnectClient(new GarminConnectContext(httpClient,
            new BasicAuthParameters(
                TestEnvironment.GetRequired("GARMIN_LOGIN"),
                TestEnvironment.GetRequired("GARMIN_PASSWORD")), mfaCode, fileTokenCache));
    });
}