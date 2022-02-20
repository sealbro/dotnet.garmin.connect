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
        new(() => LazyClient.Garmin.Value.GetActivities(1, 1));

    private readonly IGarminConnectClient _garmin;

    public ActivitiesTests()
    {
        _garmin = LazyClient.Garmin.Value;
    }

    [Fact]
    public async Task GetActivities_NotNull()
    {
        var garminActivities = await _lazyActivities.Value;

        Assert.NotNull(garminActivities);
        Assert.NotEmpty(garminActivities);
    }

    [Fact]
    public async Task GetActivitiesByDate_NotNull()
    {
        var activitiesByDate =
            await _garmin.GetActivitiesByDate(DateTime.Now.AddDays(-7), DateTime.Now.AddDays(-2), "running");

        Assert.NotNull(activitiesByDate);
        Assert.NotEmpty(activitiesByDate);
    }

    [Fact]
    public async Task DownloadActivity_NotNull()
    {
        var garminActivities = await _lazyActivities.Value;
        var activityId = garminActivities.First().ActivityId;

        var downloadActivity = await _garmin.DownloadActivity(activityId);

        Assert.NotNull(downloadActivity);
        Assert.NotEmpty(downloadActivity);
    }

    [Fact]
    public async Task GetActivityExcerciseSets_NotNull()
    {
        var garminActivities = await _lazyActivities.Value;
        var activityId = garminActivities.First().ActivityId;

        var garminExcerciseSets = await _garmin.GetActivityExcerciseSets(activityId);

        Assert.NotNull(garminExcerciseSets);
    }

    [Fact]
    public async Task GetActivityHrInTimezones_NotNull()
    {
        var garminActivities = await _lazyActivities.Value;
        var activityId = garminActivities.First().ActivityId;

        var garminHrTimeInZonesArray = await _garmin.GetActivityHrInTimezones(activityId);

        Assert.NotNull(garminHrTimeInZonesArray);
    }

    [Fact]
    public async Task GetActivitySplits_NotNull()
    {
        var garminActivities = await _lazyActivities.Value;
        var activityId = garminActivities.First().ActivityId;

        var garminActivitySplits = await _garmin.GetActivitySplits(activityId);

        Assert.NotNull(garminActivitySplits);
    }

    [Fact]
    public async Task GetActivityWeather_NotNull()
    {
        var garminActivities = await _lazyActivities.Value;
        var activityId = garminActivities.First().ActivityId;

        var garminActivityWeather = await _garmin.GetActivityWeather(activityId);

        Assert.NotNull(garminActivityWeather);
    }

    [Fact]
    public async Task GetActivityDetails_NotNull()
    {
        var garminActivities = await _lazyActivities.Value;
        var activityId = garminActivities.First().ActivityId;

        var garminActivityDetails = await _garmin.GetActivityDetails(activityId, 50, 50);

        Assert.NotNull(garminActivityDetails);
    }

    [Fact]
    public async Task GetActivitySplitSummaries_NotNull()
    {
        var garminActivities = await _lazyActivities.Value;
        var activityId = garminActivities.First().ActivityId;

        var activitySplitSummaries = await _garmin.GetActivitySplitSummaries(activityId);

        Assert.NotNull(activitySplitSummaries);
    }
}