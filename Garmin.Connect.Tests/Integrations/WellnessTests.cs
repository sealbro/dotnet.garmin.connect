using System;
using System.Threading.Tasks;

namespace Garmin.Connect.Tests.Integrations;

[NotInParallel("Garmin Integrations")]
public class WellnessTests
{
    private readonly IGarminConnectClient _garmin = LazyClient.Garmin.Value;
    private readonly DateTime _startDate = DateTime.Now.AddDays(-1);
    private readonly DateTime _endDate = DateTime.Now;

    [Test]
    public async Task GetUserSummary_NotNull()
    {
        var userSummary = await _garmin.GetUserSummary(_startDate, TestContext.Current!.Execution.CancellationToken);

        await Assert.That(userSummary).IsNotNull();
    }

    [Test]
    public async Task GetWellnessStepsData_NotNull()
    {
        var wellnessStepsData = await _garmin.GetWellnessStepsData(_startDate, TestContext.Current!.Execution.CancellationToken);

        await Assert.That(wellnessStepsData).IsNotNull();
    }

    [Test]
    public async Task GetWellnessSleepData_NotNull()
    {
        var wellnessSleepData = await _garmin.GetWellnessSleepData(_startDate, TestContext.Current!.Execution.CancellationToken);

        await Assert.That(wellnessSleepData).IsNotNull();
    }

    [Test]
    public async Task GetWellnessHeartRates_NotNull()
    {
        var wellnessHeartRates =
            await _garmin.GetWellnessHeartRates(_startDate, TestContext.Current!.Execution.CancellationToken);

        await Assert.That(wellnessHeartRates).IsNotNull();
    }

    [Test]
    public async Task GetWellnessBodyBattery_NotNull()
    {
        var garminBodyBattery =
            await _garmin.GetWelnessBodyBatteryData(_startDate, _endDate, TestContext.Current!.Execution.CancellationToken);

        await Assert.That(garminBodyBattery).IsNotNull();
    }

    [Test]
    public async Task GetHydrationData_NotNull()
    {
        var garminHydrationData = await _garmin.GetHydrationData(_startDate, TestContext.Current!.Execution.CancellationToken);

        await Assert.That(garminHydrationData).IsNotNull();
    }

    [Test]
    public async Task GetBodyComposition_NotNull()
    {
        var garminBodyComposition =
            await _garmin.GetBodyComposition(_startDate, _endDate, TestContext.Current!.Execution.CancellationToken);

        await Assert.That(garminBodyComposition).IsNotNull();
    }
}
