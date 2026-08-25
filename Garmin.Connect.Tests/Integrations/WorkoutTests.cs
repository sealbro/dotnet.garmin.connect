using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Garmin.Connect.Models;
using Garmin.Connect.Parameters;

namespace Garmin.Connect.Tests.Integrations;

[NotInParallel("Garmin Integrations")]
public class WorkoutTests
{
    private readonly IGarminConnectClient _garmin = LazyClient.Garmin.Value;

    private readonly Lazy<Task<GarminWorkout[]>> _lazyWorkouts =
        new(() => LazyClient.Garmin.Value.GetWorkouts(new WorkoutsParameters
        {
            OrderSeq = OrderSeq.ASC,
            OrderBy = WorkoutsOrderBy.CREATED_DATE,
            Limit = 5
        }));

    [Test]
    public async Task GetWorkouts_NotEmpty()
    {
        var workouts = await _lazyWorkouts.Value;

        await Assert.That(workouts).IsNotEmpty();
    }

    [Test]
    public async Task GetWorkoutTypes_NotNull()
    {
        var workoutTypes = await _garmin.GetWorkoutTypes(TestContext.Current!.Execution.CancellationToken);

        await Assert.That(workoutTypes).IsNotNull();
    }

    [Test]
    public async Task GetWorkout_NotNull()
    {
        var ct = TestContext.Current!.Execution.CancellationToken;
        var workoutsParameters = new WorkoutsParameters { OrderBy = WorkoutsOrderBy.UPDATE_DATE };
        var workouts = await _garmin.GetWorkouts(workoutsParameters, ct);

        await Assert.That(workouts).IsNotEmpty();

        var workout = await _garmin.GetWorkout(workouts.First().WorkoutId, ct);

        await Assert.That(workout).IsNotNull();
    }

    [Test]
    public async Task UpdateWorkout()
    {
        var ct = TestContext.Current!.Execution.CancellationToken;
        var expectedConditionValue = 2000;
        var workoutId = (await _lazyWorkouts.Value).First().WorkoutId;

        var workout = await _garmin.GetWorkout(workoutId, ct);

        await Assert.That(workout.WorkoutSegments).IsNotEmpty();
        await Assert.That(workout.WorkoutSegments.First().WorkoutSteps).IsNotEmpty();

        var originalWorkoutStep = workout.WorkoutSegments.First().WorkoutSteps[0];
        workout.WorkoutSegments.First().WorkoutSteps[0] =
            originalWorkoutStep with { EndConditionValue = expectedConditionValue };
        await _garmin.UpdateWorkout(workout, ct);
        workout = await _garmin.GetWorkout(workoutId, ct);

        await Assert.That(workout.WorkoutSegments.First().WorkoutSteps.First().EndConditionValue)
            .IsEqualTo(expectedConditionValue);

        workout.WorkoutSegments.First().WorkoutSteps[0] = originalWorkoutStep with
        {
            EndConditionValue = originalWorkoutStep.EndConditionValue
        };
        await _garmin.UpdateWorkout(workout, ct);
        workout = await _garmin.GetWorkout(workoutId, ct);

        await Assert.That(workout.WorkoutSegments.First().WorkoutSteps.First().EndConditionValue)
            .IsEqualTo(originalWorkoutStep.EndConditionValue);
    }

    [Test]
    public async Task ScheduleWorkout()
    {
        var ct = TestContext.Current!.Execution.CancellationToken;
        var workouts = await _lazyWorkouts.Value;
        var workout = workouts.First();
        var scheduleDate = DateOnly.FromDateTime(workout.CreatedDate);

        await Assert.That(workouts).IsNotEmpty();

        var calendarWeek = await _garmin.GetCalendarByWeek(scheduleDate, ct);

        await Assert.That(calendarWeek.CalendarItems).DoesNotContain(x => x.WorkoutId == workout.WorkoutId);

        await _garmin.ScheduleWorkout(workout.WorkoutId, scheduleDate, ct);
        calendarWeek = await _garmin.GetCalendarByWeek(scheduleDate, ct);

        await Assert.That(calendarWeek.CalendarItems).Contains(x => x.WorkoutId == workout.WorkoutId);

        var calendarId = calendarWeek.CalendarItems
            .First(x => x.WorkoutId == workout.WorkoutId).Id;
        await _garmin.RemoveScheduledWorkout(calendarId, ct);
        calendarWeek = await _garmin.GetCalendarByWeek(scheduleDate, ct);

        await Assert.That(calendarWeek.CalendarItems).DoesNotContain(x => x.WorkoutId == workout.WorkoutId);
    }

    [Test, Skip("Not for CI only for self test")]
    public async Task SendToDevice()
    {
        var ct = TestContext.Current!.Execution.CancellationToken;
        var workouts = await _lazyWorkouts.Value;
        var workout = workouts.First();

        await Assert.That(workout.SportType.SportTypeKey).IsEqualTo("running");

        var deviceId = (await _garmin.GetDevices(ct)).First(device => device.SupportedHrZones.Contains("RUNNING"))
            .DeviceId;

        await _garmin.SendWorkoutToDevices(workout.WorkoutId, [deviceId], ct);

        var deviceMessages = await _garmin.GetDeviceMessages(ct);

        await Assert.That(deviceMessages.Messages)
            .Contains(x => x.MessageType == "workouts" && x.DeviceId == deviceId &&
                           x.MetaData.MetaDataId == workout.WorkoutId);
    }

    [Test, Skip("Not for CI only for self test")]
    public async Task UploadFileFromLocalMachine()
    {
        var filename = "/some.fit";

        await _garmin.UploadFile(filename, TestContext.Current!.Execution.CancellationToken);
    }

    [Test, Skip("Not for CI only for self test")]
    public async Task UploadFileFromStream()
    {
        var ct = TestContext.Current!.Execution.CancellationToken;
        var filename = "/some.fit";
        var memoryStream = new MemoryStream();
        await using (var fileStream = new FileStream(filename, FileMode.Open, FileAccess.Read))
        {
            await fileStream.CopyToAsync(memoryStream, ct);
        }

        memoryStream.Position = 0;

        await _garmin.UploadFile(filename, memoryStream, ct);
    }
}
