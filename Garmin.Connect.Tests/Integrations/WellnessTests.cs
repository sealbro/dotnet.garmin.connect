using System;
using System.Threading.Tasks;
using Xunit;

namespace Garmin.Connect.Tests.Integrations;

[Collection("Garmin Integrations")]
public class WellnessTests
{
    private readonly IGarminConnectClient _garmin;
    private readonly DateTime _startDate;
    private readonly DateTime _endDate;

    public WellnessTests()
    {
        _garmin = LazyClient.Garmin.Value;
        _startDate = DateTime.Now.AddDays(-1);
        _endDate = DateTime.Now;
    }

    [Fact]
    public async Task GetUserSummary_NotNull()
    {
        var userSummary = await _garmin.GetUserSummary(_startDate);

        Assert.NotNull(userSummary);
    }

    [Fact]
    public async Task GetWellnessStepsData_NotNull()
    {
        var wellnessStepsData = await _garmin.GetWellnessStepsData(_startDate);

        Assert.NotNull(wellnessStepsData);
    }

    [Fact]
    public async Task GetWellnessSleepData_NotNull()
    {
        var wellnessSleepData = await _garmin.GetWellnessSleepData(_startDate);

        Assert.NotNull(wellnessSleepData);
    }

    [Fact]
    public async Task GetWellnessHeartRates_NotNull()
    {
        var wellnessHeartRates = await _garmin.GetWellnessHeartRates(_startDate);

        Assert.NotNull(wellnessHeartRates);
    }

    [Fact]
    public async Task GetWellnessBodyBattery_NotNull()
    {
        var garminBodyBattery = await _garmin.GetWelnessBodyBatteryData(_startDate, _endDate);

        Assert.NotNull(garminBodyBattery);
    }

    [Fact]
    public async Task GetHydrationData_NotNull()
    {
        var garminHydrationData = await _garmin.GetHydrationData(_startDate);

        Assert.NotNull(garminHydrationData);
    }

    [Fact]
    public async Task GetBodyComposition_NotNull()
    {
        var garminBodyComposition = await _garmin.GetBodyComposition(_startDate, _endDate);

        Assert.NotNull(garminBodyComposition);
    }
}