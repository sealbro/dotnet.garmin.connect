using System;
using System.Threading.Tasks;
using Xunit;

namespace Garmin.Connect.Tests.Integrations;

[Collection("Garmin Integrations")]
public class WellnessTests
{
    private readonly IGarminConnectClient _garmin = LazyClient.Garmin.Value;
    private readonly DateTime _startDate = DateTime.Now.AddDays(-1);
    private readonly DateTime _endDate = DateTime.Now;

    [Fact]
    public async Task GetUserSummary_NotNull()
    {
        var userSummary = await _garmin.GetUserSummary(_startDate, TestContext.Current.CancellationToken);

        Assert.NotNull(userSummary);
    }

    [Fact]
    public async Task GetWellnessStepsData_NotNull()
    {
        var wellnessStepsData = await _garmin.GetWellnessStepsData(_startDate, TestContext.Current.CancellationToken);

        Assert.NotNull(wellnessStepsData);
    }

    [Fact]
    public async Task GetWellnessSleepData_NotNull()
    {
        var wellnessSleepData = await _garmin.GetWellnessSleepData(_startDate, TestContext.Current.CancellationToken);

        Assert.NotNull(wellnessSleepData);
    }

    [Fact]
    public async Task GetWellnessHeartRates_NotNull()
    {
        var wellnessHeartRates = await _garmin.GetWellnessHeartRates(_startDate, TestContext.Current.CancellationToken);

        Assert.NotNull(wellnessHeartRates);
    }

    [Fact]
    public async Task GetWellnessBodyBattery_NotNull()
    {
        var garminBodyBattery =
            await _garmin.GetWelnessBodyBatteryData(_startDate, _endDate, TestContext.Current.CancellationToken);

        Assert.NotNull(garminBodyBattery);
    }

    [Fact]
    public async Task GetHydrationData_NotNull()
    {
        var garminHydrationData = await _garmin.GetHydrationData(_startDate, TestContext.Current.CancellationToken);

        Assert.NotNull(garminHydrationData);
    }

    [Fact]
    public async Task GetBodyComposition_NotNull()
    {
        var garminBodyComposition =
            await _garmin.GetBodyComposition(_startDate, _endDate, TestContext.Current.CancellationToken);

        Assert.NotNull(garminBodyComposition);
    }
}