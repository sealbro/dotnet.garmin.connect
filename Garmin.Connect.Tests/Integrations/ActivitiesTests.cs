using System;
using System.Linq;
using System.Threading.Tasks;
using Garmin.Connect.Models;

namespace Garmin.Connect.Tests.Integrations;

[NotInParallel("Garmin Integrations")]
public class ActivitiesTests
{
    private readonly Lazy<Task<GarminActivity[]>> _lazyActivities =
        new(() => LazyClient.Garmin.Value.GetActivities(2, 1));

    private readonly IGarminConnectClient _garmin = LazyClient.Garmin.Value;

    [Test]
    public async Task GetActivities_NotEmpty()
    {
        var garminActivities = await _lazyActivities.Value;

        await Assert.That(garminActivities).IsNotNull();
        await Assert.That(garminActivities).IsNotEmpty();
    }

    [Test]
    public async Task GetActivitiesByDate_NotEmpty()
    {
        var activitiesByDate =
            await _garmin.GetActivitiesByDate(DateTime.Now.AddDays(-30), DateTime.Now.AddDays(-2), "walking",
                cancellationToken: TestContext.Current!.Execution.CancellationToken);

        await Assert.That(activitiesByDate).IsNotNull();
        await Assert.That(activitiesByDate).IsNotEmpty();
    }

    [Test]
    public async Task DownloadActivity_NotNull()
    {
        var garminActivities = await _lazyActivities.Value;
        var activityId = garminActivities.First().ActivityId;

        var downloadActivity = await _garmin.DownloadActivity(activityId,
            cancellationToken: TestContext.Current!.Execution.CancellationToken);

        await Assert.That(downloadActivity).IsNotNull();
        await Assert.That(downloadActivity).IsNotEmpty();
    }

    [Test]
    public async Task GetActivityExerciseSets_Exists()
    {
        var garminActivities = await _lazyActivities.Value;
        var activityId = garminActivities.First().ActivityId;

        var garminExerciseSets =
            await _garmin.GetActivityExerciseSets(activityId, TestContext.Current!.Execution.CancellationToken);

        await Assert.That(garminExerciseSets.ActivityId).IsNotEqualTo(0);
    }

    [Test]
    public async Task GetActivityHrInTimezones_NotEmpty()
    {
        var garminActivities = await _lazyActivities.Value;
        var activityId = garminActivities.First().ActivityId;

        var garminHrTimeInZonesArray =
            await _garmin.GetActivityHrInTimezones(activityId, TestContext.Current!.Execution.CancellationToken);

        await Assert.That(garminHrTimeInZonesArray).IsNotNull();
        await Assert.That(garminHrTimeInZonesArray).IsNotEmpty();
    }

    [Test]
    public async Task GetActivitySplits_Exists()
    {
        var garminActivities = await _lazyActivities.Value;
        var activityId = garminActivities.First().ActivityId;

        var garminActivitySplits =
            await _garmin.GetActivitySplits(activityId, TestContext.Current!.Execution.CancellationToken);

        await Assert.That(garminActivitySplits.ActivityId).IsNotEqualTo(0);
    }

    [Test]
    public async Task GetActivityWeather_Exists()
    {
        var ct = TestContext.Current!.Execution.CancellationToken;
        var activitiesByDate =
            await _garmin.GetActivitiesByDate(DateTime.Now.AddDays(-30), DateTime.Now.AddDays(-2), "walking",
                cancellationToken: ct);
        var activityId = activitiesByDate.First().ActivityId;

        var garminActivityWeather = await _garmin.GetActivityWeather(activityId, ct);

        DateTime defaultDt = default;

        await Assert.That(garminActivityWeather.IssueDate).IsNotEqualTo(defaultDt);
    }

    [Test]
    public async Task GetActivityDetails_Exists()
    {
        var garminActivities = await _lazyActivities.Value;
        var activityId = garminActivities.First().ActivityId;

        var garminActivityDetails =
            await _garmin.GetActivityDetails(activityId, 50, 50, TestContext.Current!.Execution.CancellationToken);

        await Assert.That(garminActivityDetails.ActivityDetailMetrics).IsNotEmpty();
    }

    [Test]
    public async Task GetActivitySplitSummaries_Exists()
    {
        var garminActivities = await _lazyActivities.Value;
        var activityId = garminActivities.First().ActivityId;

        var activitySplitSummaries =
            await _garmin.GetActivitySplitSummaries(activityId, TestContext.Current!.Execution.CancellationToken);

        // The split_summaries endpoint has no 'hasSplits' field, so it always deserializes
        // to false — only assert on what the endpoint actually returns.
        await Assert.That(activitySplitSummaries.SplitSummaries).IsNotNull();
    }
}
