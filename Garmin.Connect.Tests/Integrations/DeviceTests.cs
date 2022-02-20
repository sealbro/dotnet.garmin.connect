using System;
using System.Linq;
using System.Threading.Tasks;
using Garmin.Connect.Models;
using Xunit;

namespace Garmin.Connect.Tests.Integrations;

[Collection("Garmin Integrations")]
public class DeviceTests
{
    private readonly Lazy<Task<GarminDevice[]>> _lazyDevices = new(() => LazyClient.Garmin.Value.GetDevices());

    private readonly IGarminConnectClient _garmin;

    public DeviceTests()
    {
        _garmin = LazyClient.Garmin.Value;
    }

    [Fact]
    public async Task GetDevices_NotNull()
    {
        var garminDevices = await _lazyDevices.Value;

        Assert.NotNull(garminDevices);
        Assert.NotEmpty(garminDevices);
    }

    [Fact]
    public async Task GetDeviceSettings_NotNull()
    {
        var garminDevices = await _lazyDevices.Value;
        var garminDeviceSettings = await _garmin.GetDeviceSettings(garminDevices.First().DeviceId);

        Assert.NotNull(garminDeviceSettings);
    }

    [Fact]
    public async Task GetDeviceLastUsed_NotNull()
    {
        var garminDeviceLastUsed = await _garmin.GetDeviceLastUsed();

        Assert.NotNull(garminDeviceLastUsed);
    }
}