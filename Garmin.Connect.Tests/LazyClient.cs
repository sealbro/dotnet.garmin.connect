using System;
using System.Net.Http;
using Garmin.Connect.Auth;

namespace Garmin.Connect.Tests;

public static class LazyClient
{
    public static readonly Lazy<IGarminConnectClient> Garmin = new(() =>
        new GarminConnectClient(new GarminConnectContext(new HttpClient(),
            new BasicAuthParameters(
                Environment.GetEnvironmentVariable("GARMIN_LOGIN"),
                Environment.GetEnvironmentVariable("GARMIN_PASSWORD")))));
}