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

    private readonly IGarminConnectClient _garmin = LazyClient.Garmin.Value;

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
        var garminDeviceSettings =
            await _garmin.GetDeviceSettings(garminDevices.First().DeviceId, TestContext.Current.CancellationToken);

        Assert.NotNull(garminDeviceSettings);
    }

    [Fact]
    public async Task GetDeviceLastUsed_NotNull()
    {
        var garminDeviceLastUsed = await _garmin.GetDeviceLastUsed(TestContext.Current.CancellationToken);

        Assert.NotNull(garminDeviceLastUsed);
    }

    [Fact]
    public async Task GetDeviceMessages_Exists()
    {
        var deviceMessages = await _garmin.GetDeviceMessages(TestContext.Current.CancellationToken);

        Assert.NotEmpty(deviceMessages.Messages);
    }
}