using System;
using System.Linq;
using System.Threading.Tasks;
using Garmin.Connect.Models;

namespace Garmin.Connect.Tests.Integrations;

[NotInParallel("Garmin Integrations")]
public class DeviceTests
{
    private readonly Lazy<Task<GarminDevice[]>> _lazyDevices = new(() => LazyClient.Garmin.Value.GetDevices());

    private readonly IGarminConnectClient _garmin = LazyClient.Garmin.Value;

    [Test]
    public async Task GetDevices_NotNull()
    {
        var garminDevices = await _lazyDevices.Value;

        await Assert.That(garminDevices).IsNotNull();
        await Assert.That(garminDevices).IsNotEmpty();
    }

    [Test]
    public async Task GetDeviceSettings_NotNull()
    {
        var garminDevices = await _lazyDevices.Value;
        var garminDeviceSettings =
            await _garmin.GetDeviceSettings(garminDevices.First().DeviceId, TestContext.Current!.Execution.CancellationToken);

        await Assert.That(garminDeviceSettings).IsNotNull();
    }

    [Test]
    public async Task GetDeviceLastUsed_NotNull()
    {
        var garminDeviceLastUsed = await _garmin.GetDeviceLastUsed(TestContext.Current!.Execution.CancellationToken);

        await Assert.That(garminDeviceLastUsed).IsNotNull();
    }

    [Test]
    public async Task GetDeviceMessages_Exists()
    {
        var deviceMessages = await _garmin.GetDeviceMessages(TestContext.Current!.Execution.CancellationToken);

        await Assert.That(deviceMessages.Messages).IsNotEmpty();
    }
}
