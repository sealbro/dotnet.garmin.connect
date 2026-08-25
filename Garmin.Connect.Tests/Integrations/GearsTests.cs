using System;
using System.Threading.Tasks;
using Garmin.Connect.Models;

namespace Garmin.Connect.Tests.Integrations;

[NotInParallel("Garmin Integrations")]
public class GearsTests
{
    private readonly Lazy<Task<GarminActivity[]>> _lazyActivities =
        new(() => LazyClient.Garmin.Value.GetActivities(1, 1));

    private readonly IGarminConnectClient _garmin = LazyClient.Garmin.Value;

    [Test]
    public async Task GetGearTypes_NotNull()
    {
        var gearTypes = await _garmin.GetGearTypes(TestContext.Current!.Execution.CancellationToken);

        await Assert.That(gearTypes).IsNotNull();
        await Assert.That(gearTypes).IsNotEmpty();
    }

    [Test]
    public async Task GetUserGears_NotNull()
    {
        var garminActivities = await _lazyActivities.Value;
        var userGears =
            await _garmin.GetUserGears(garminActivities[0].OwnerId, TestContext.Current!.Execution.CancellationToken);

        await Assert.That(userGears).IsNotNull();
        await Assert.That(userGears).IsNotEmpty();
    }

    [Test]
    public async Task GetActivityGears_NotNull()
    {
        var garminActivities = await _lazyActivities.Value;
        var activityGears =
            await _garmin.GetActivityGears(garminActivities[0].ActivityId, TestContext.Current!.Execution.CancellationToken);

        await Assert.That(activityGears).IsNotNull();
    }
}
