using System;
using System.Linq;
using System.Threading.Tasks;
using Garmin.Connect.Models;
using Xunit;

namespace Garmin.Connect.Tests.Integrations;

[Collection("Garmin Integrations")]
public class ActivitiesTests
{
    private readonly Lazy<Task<GarminActivity[]>> _lazyActivities =
        new(() => LazyClient.Garmin.Value.GetActivities(2, 1));

    private readonly IGarminConnectClient _garmin = LazyClient.Garmin.Value;

    [Fact]
    public async Task GetActivities_NotEmpty()
    {
        var garminActivities = await _lazyActivities.Value;

        Assert.NotNull(garminActivities);
        Assert.NotEmpty(garminActivities);
    }

    [Fact]
    public async Task GetActivitiesByDate_NotEmpty()
    {
        var activitiesByDate =
            await _garmin.GetActivitiesByDate(DateTime.Now.AddDays(-30), DateTime.Now.AddDays(-2), "walking",
                cancellationToken: TestContext.Current.CancellationToken);

        Assert.NotNull(activitiesByDate);
        Assert.NotEmpty(activitiesByDate);
    }

    [Fact]
    public async Task DownloadActivity_NotNull()
    {
        var garminActivities = await _lazyActivities.Value;
        var activityId = garminActivities.First().ActivityId;

        var downloadActivity = await _garmin.DownloadActivity(activityId,
            cancellationToken: TestContext.Current.CancellationToken);

        Assert.NotNull(downloadActivity);
        Assert.NotEmpty(downloadActivity);
    }

    [Fact]
    public async Task GetActivityExerciseSets_Exists()
    {
        var garminActivities = await _lazyActivities.Value;
        var activityId = garminActivities.First().ActivityId;

        var garminExerciseSets =
            await _garmin.GetActivityExerciseSets(activityId, TestContext.Current.CancellationToken);

        Assert.NotEqual(0, garminExerciseSets.ActivityId);
    }

    [Fact]
    public async Task GetActivityHrInTimezones_NotEmpty()
    {
        var garminActivities = await _lazyActivities.Value;
        var activityId = garminActivities.First().ActivityId;

        var garminHrTimeInZonesArray =
            await _garmin.GetActivityHrInTimezones(activityId, TestContext.Current.CancellationToken);

        Assert.NotNull(garminHrTimeInZonesArray);
        Assert.NotEmpty(garminHrTimeInZonesArray);
    }

    [Fact]
    public async Task GetActivitySplits_Exists()
    {
        var garminActivities = await _lazyActivities.Value;
        var activityId = garminActivities.First().ActivityId;

        var garminActivitySplits = await _garmin.GetActivitySplits(activityId, TestContext.Current.CancellationToken);

        Assert.NotEqual(0, garminActivitySplits.ActivityId);
    }

    [Fact]
    public async Task GetActivityWeather_Exists()
    {
        var ct = TestContext.Current.CancellationToken;
        var activitiesByDate =
            await _garmin.GetActivitiesByDate(DateTime.Now.AddDays(-30), DateTime.Now.AddDays(-2), "walking",
                cancellationToken: ct);
        var activityId = activitiesByDate.First().ActivityId;

        var garminActivityWeather = await _garmin.GetActivityWeather(activityId, ct);

        DateTime defaultDt = default;

        Assert.NotEqual(defaultDt, garminActivityWeather.IssueDate);
    }

    [Fact]
    public async Task GetActivityDetails_Exists()
    {
        var garminActivities = await _lazyActivities.Value;
        var activityId = garminActivities.First().ActivityId;

        var garminActivityDetails =
            await _garmin.GetActivityDetails(activityId, 50, 50, TestContext.Current.CancellationToken);

        Assert.NotEmpty(garminActivityDetails.ActivityDetailMetrics);
    }

    [Fact]
    public async Task GetActivitySplitSummaries_Exists()
    {
        var garminActivities = await _lazyActivities.Value;
        var activityId = garminActivities.First().ActivityId;

        var activitySplitSummaries =
            await _garmin.GetActivitySplitSummaries(activityId, TestContext.Current.CancellationToken);

        Assert.NotEmpty(activitySplitSummaries.SplitSummaries);
    }
}