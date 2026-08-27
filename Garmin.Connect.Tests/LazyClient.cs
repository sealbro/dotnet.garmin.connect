using System;

namespace Garmin.Connect.Tests;

public static class LazyClient
{
    public static readonly Lazy<IGarminConnectClient> Garmin = new(() =>
        new GarminConnectClient(LazyContext.Context.Value));
}