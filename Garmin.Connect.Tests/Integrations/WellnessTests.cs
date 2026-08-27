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

    [Test]
    public async Task GetRestingHeartRate_ReturnsMappedFields()
    {
        var restingHeartRate =
            await _garmin.GetRestingHeartRate(_startDate, _endDate, TestContext.Current!.Execution.CancellationToken);

        await Assert.That(restingHeartRate).IsNotNull();
        await Assert.That(restingHeartRate.UserProfileId).IsGreaterThan(0);
        await Assert.That(restingHeartRate.StatisticsStartDate).IsEqualTo(DateOnly.FromDateTime(_startDate));
        await Assert.That(restingHeartRate.StatisticsEndDate).IsEqualTo(DateOnly.FromDateTime(_endDate));
        await Assert.That(restingHeartRate.AllMetrics.MetricsMap).IsNotEmpty();
    }

    [Test]
    public async Task GetCaloriesDaily_ReturnsMappedFields()
    {
        var caloriesDaily =
            await _garmin.GetCaloriesDaily(_startDate, _endDate, TestContext.Current!.Execution.CancellationToken);

        await Assert.That(caloriesDaily).IsNotEmpty();
        await Assert.That(caloriesDaily[0].CalendarDate).IsEqualTo(DateOnly.FromDateTime(_startDate));
        await Assert.That(caloriesDaily[0].Values).IsNotNull();
    }

    [Test]
    public async Task GetWeeklySteps_ReturnsMappedFields()
    {
        var weeklySteps = await _garmin.GetWeeklySteps(_endDate, weeks: 4,
            cancellationToken: TestContext.Current!.Execution.CancellationToken);

        await Assert.That(weeklySteps).IsNotEmpty();
        await Assert.That(weeklySteps.Length).IsEqualTo(4);
        await Assert.That(weeklySteps[^1].CalendarDate).IsLessThanOrEqualTo(DateOnly.FromDateTime(_endDate));
        await Assert.That(weeklySteps[^1].Values).IsNotNull();
    }

    [Test]
    public async Task GetWeeklyStress_ReturnsMappedFields()
    {
        var weeklyStress = await _garmin.GetWeeklyStress(_endDate, weeks: 4,
            cancellationToken: TestContext.Current!.Execution.CancellationToken);

        await Assert.That(weeklyStress).IsNotEmpty();
        await Assert.That(weeklyStress[^1].CalendarDate).IsLessThanOrEqualTo(DateOnly.FromDateTime(_endDate));
    }

    [Test]
    public async Task GetWeeklyIntensityMinutes_ReturnsMappedFields()
    {
        var weeklyIntensityMinutes = await _garmin.GetWeeklyIntensityMinutes(_startDate, _endDate,
            TestContext.Current!.Execution.CancellationToken);

        await Assert.That(weeklyIntensityMinutes).IsNotEmpty();
        await Assert.That(weeklyIntensityMinutes[0].CalendarDate).IsLessThanOrEqualTo(DateOnly.FromDateTime(_endDate));
    }

    [Test]
    public async Task GetRespirationData_ReturnsMappedFields()
    {
        var respirationData =
            await _garmin.GetRespirationData(_startDate, TestContext.Current!.Execution.CancellationToken);

        await Assert.That(respirationData).IsNotNull();
        await Assert.That(respirationData.UserProfilePk).IsGreaterThan(0);
        await Assert.That(respirationData.CalendarDate).IsEqualTo(DateOnly.FromDateTime(_startDate));
    }

    [Test]
    public async Task GetSpo2Data_ReturnsMappedFields()
    {
        var spo2Data = await _garmin.GetSpo2Data(_startDate, TestContext.Current!.Execution.CancellationToken);

        await Assert.That(spo2Data).IsNotNull();
        await Assert.That(spo2Data.UserProfilePk).IsGreaterThan(0);
        await Assert.That(spo2Data.CalendarDate).IsEqualTo(DateOnly.FromDateTime(_startDate));
    }

    [Test]
    public async Task GetIntensityMinutesData_ReturnsMappedFields()
    {
        var intensityMinutesData =
            await _garmin.GetIntensityMinutesData(_startDate, TestContext.Current!.Execution.CancellationToken);

        await Assert.That(intensityMinutesData).IsNotNull();
        await Assert.That(intensityMinutesData.UserProfilePk).IsGreaterThan(0);
        await Assert.That(intensityMinutesData.CalendarDate).IsEqualTo(DateOnly.FromDateTime(_startDate));
    }

    [Test]
    public async Task GetAllDayStress_ReturnsMappedFields()
    {
        var allDayStress = await _garmin.GetAllDayStress(_startDate, TestContext.Current!.Execution.CancellationToken);

        await Assert.That(allDayStress).IsNotNull();
        await Assert.That(allDayStress.UserProfilePk).IsGreaterThan(0);
        await Assert.That(allDayStress.CalendarDate).IsEqualTo(DateOnly.FromDateTime(_startDate));
    }

    [Test]
    public async Task GetAllDayEvents_ReturnsMappedFields()
    {
        var allDayEvents = await _garmin.GetAllDayEvents(_startDate, TestContext.Current!.Execution.CancellationToken);

        // events are sporadic by nature — assert the mapping only when the day has any
        await Assert.That(allDayEvents).IsNotNull();

        foreach (var allDayEvent in allDayEvents)
        {
            await Assert.That(allDayEvent.UserProfilePk).IsGreaterThan(0);
            await Assert.That(allDayEvent.CalendarDate).IsEqualTo(DateOnly.FromDateTime(_startDate));
        }
    }

    [Test]
    public async Task GetFitnessAge_ReturnsMappedFields()
    {
        var fitnessAge = await _garmin.GetFitnessAge(_startDate, TestContext.Current!.Execution.CancellationToken);

        await Assert.That(fitnessAge).IsNotNull();
        await Assert.That(fitnessAge.ChronologicalAge).IsGreaterThan(0);
        await Assert.That(fitnessAge.Components).IsNotNull();
    }

    [Test]
    public async Task GetHeartRateZones_ReturnsMappedFields()
    {
        var heartRateZones = await _garmin.GetHeartRateZones(TestContext.Current!.Execution.CancellationToken);

        await Assert.That(heartRateZones).IsNotEmpty();
        await Assert.That(heartRateZones[0].TrainingMethod).IsNotNullOrEmpty();
        await Assert.That(heartRateZones[0].Zone1Floor).IsGreaterThan(0);
    }

    [Test]
    public async Task GetPowerZones_ReturnsMappedFields()
    {
        var powerZones = await _garmin.GetPowerZones(TestContext.Current!.Execution.CancellationToken);

        await Assert.That(powerZones).IsNotEmpty();
        await Assert.That(powerZones[0].Sport).IsNotNullOrEmpty();
    }

    [Test]
    public async Task GetPowerZonesForSport_ReturnsRequestedSport()
    {
        const string sport = "cycling";

        var powerZones =
            await _garmin.GetPowerZonesForSport(sport, TestContext.Current!.Execution.CancellationToken);

        await Assert.That(powerZones).IsNotNull();
        await Assert.That(powerZones.Sport).IsEqualTo(sport).IgnoringCase();
    }
}
