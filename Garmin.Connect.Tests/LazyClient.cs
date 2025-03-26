using System;
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

        return new GarminConnectClient(new GarminConnectContext(httpClient,
            new BasicAuthParameters(
                Environment.GetEnvironmentVariable("GARMIN_LOGIN"),
                Environment.GetEnvironmentVariable("GARMIN_PASSWORD")), mfaCode));
    });
}