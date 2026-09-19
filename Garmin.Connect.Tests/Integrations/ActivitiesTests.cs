using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Garmin.Connect.Exceptions;
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
    public async Task UpdateActivityDescription()
    {
        var ct = TestContext.Current!.Execution.CancellationToken;
        var expectedSuffix = Guid.NewGuid().ToString()[..6];
        var activity = (await _lazyActivities.Value).First();

        var originalDescription = activity.Description ?? string.Empty;
        var expectedDescription = originalDescription + expectedSuffix;
        var descriptionChanged = false;

        var updateActivity = new GarminUpdateActivity()
        {
            ActivityId = activity.ActivityId,
            Description = expectedDescription
        };

        var restoreActivity = updateActivity with { Description = originalDescription };

        try
        {
            await _garmin.UpdateActivity(updateActivity, ct);
            descriptionChanged = true;
            var updatedActivity = await _garmin.GetActivityExerciseSets(activity.ActivityId, ct);

            await Assert.That(updatedActivity.Description)
                .IsEqualTo(expectedDescription);

            await _garmin.UpdateActivity(updateActivity with { Description = originalDescription }, ct);
            updatedActivity = await _garmin.GetActivityExerciseSets(activity.ActivityId, ct);
            descriptionChanged = false;

            await Assert.That(updatedActivity.Description ?? string.Empty).IsEqualTo(originalDescription);
        }
        finally
        {
            if (descriptionChanged)
            {
                await _garmin.UpdateActivity(restoreActivity, ct);
            }
        }
    }

    [Test]
    public async Task AddImageToActivity_ThenRemoveImageFromActivity_UpdatesActivityImages()
    {
        var activityImagePath = $"TestData{Path.DirectorySeparatorChar}activity-image.jpg";
        var ct = TestContext.Current!.Execution.CancellationToken;
        var activity = (await _lazyActivities.Value).First();
        var activityBefore = await _garmin.GetActivityExerciseSets(activity.ActivityId, ct);
        var previousImageIds = activityBefore.MetadataDto.ActivityImages.Select(x => x.ImageId).ToArray();
        var imagePath = Path.Combine(AppContext.BaseDirectory, activityImagePath);
        var filename = Path.GetFileName(imagePath);

        await Assert.That(File.Exists(imagePath)).IsTrue().Because($"Put a real test image at '{imagePath}'.");

        ActivityImage addedImage;
        var imageRemoved = false;
        await using (var imageStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read, FileShare.Read))
        {
            addedImage = await _garmin.AddImageToActivity(activity.ActivityId, imageStream, filename, ct);
        }

        try
        {
            await Assert.That(addedImage.ImageId).IsNotNull().And.IsNotEmpty();
            await Assert.That(previousImageIds).DoesNotContain(addedImage.ImageId);

            var activityWithImage = await _garmin.GetActivityExerciseSets(activity.ActivityId, ct);
            var imageIdsAfterAdd = activityWithImage.MetadataDto.ActivityImages.Select(x => x.ImageId).ToArray();

            await Assert.That(imageIdsAfterAdd).Contains(addedImage.ImageId);

            await _garmin.RemoveImageFromActivity(activity.ActivityId, addedImage.ImageId, ct);
            imageRemoved = true;

            var activityAfterRemove = await _garmin.GetActivityExerciseSets(activity.ActivityId, ct);
            var imageIdsAfterRemove = activityAfterRemove.MetadataDto.ActivityImages.Select(x => x.ImageId).ToArray();

            await Assert.That(imageIdsAfterRemove).DoesNotContain(addedImage.ImageId);
        }
        finally
        {
            if (!imageRemoved)
            {
                await _garmin.RemoveImageFromActivity(activity.ActivityId, addedImage.ImageId, ct);
            }
        }
    }

    [Test, Skip("Not for CI only for self test")]
    public async Task LinkActivityGear_ThenUnlinkActivityGear_UpdatesActivityGears()
    {
        var ct = TestContext.Current!.Execution.CancellationToken;
        var activity = (await _garmin.GetActivitiesByDate(DateTime.Now.AddDays(-30), DateTime.Now.AddDays(-2), "walking", ct)).First();
        var activityGearsBefore = await _garmin.GetActivityGears(activity.ActivityId, ct);
        var userGears = await _garmin.GetUserGears(activity.OwnerId, ct);
        var gearToLink = userGears.FirstOrDefault(gear =>
            string.Equals(gear.GearTypeName, "Shoes", StringComparison.OrdinalIgnoreCase) &&
            string.Equals(gear.GearStatusName, "active", StringComparison.OrdinalIgnoreCase) &&
            activityGearsBefore.All(activityGear => activityGear.Uuid != gear.Uuid));

        await Assert.That(gearToLink).IsNotNull()
            .Because("The test requires an active Shoes gear that is not already linked to the walking activity.");

        GarminGear linkedGear = null!;
        var gearUnlinked = false;

        try
        {
            linkedGear = await _garmin.LinkActivityGear(activity.ActivityId, gearToLink!.Uuid, ct);

            await Assert.That(linkedGear.Uuid).IsEqualTo(gearToLink.Uuid);

            var activityGearsAfterLink = await _garmin.GetActivityGears(activity.ActivityId, ct);

            await Assert.That(activityGearsAfterLink.Select(gear => gear.Uuid)).Contains(gearToLink.Uuid);

            await _garmin.UnlinkActivityGear(activity.ActivityId, gearToLink.Uuid, ct);
            gearUnlinked = true;

            var activityGearsAfterUnlink = await _garmin.GetActivityGears(activity.ActivityId, ct);

            await Assert.That(activityGearsAfterUnlink.Select(gear => gear.Uuid)).DoesNotContain(gearToLink.Uuid);
        }
        finally
        {
            if (!gearUnlinked)
            {
                await _garmin.UnlinkActivityGear(activity.ActivityId, gearToLink!.Uuid, ct);
            }
        }
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

    [Test, Skip("Not for CI only for self test")]
    public async Task DeleteActivity_ThenGetActivityExerciseSets_Throws()
    {
        var ct = TestContext.Current!.Execution.CancellationToken;
        long activityId = 0;

        await Assert.That(activityId).IsNotEqualTo(0).Because("Set a known activity ID before running this test.");

        var activity = await _garmin.GetActivityExerciseSets(activityId, ct);

        await Assert.That(activity).IsNotNull();
        await Assert.That(activity.ActivityId).IsEqualTo(activityId);

        await _garmin.DeleteActivity(activityId, ct);

        await Assert.That(async () => await _garmin.GetActivityExerciseSets(activityId, ct))
            .Throws<GarminConnectRequestException>();
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
