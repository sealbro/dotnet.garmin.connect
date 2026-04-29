using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Garmin.Connect.Models;
using Garmin.Connect.Parameters;
using Xunit;

namespace Garmin.Connect.Tests.Integrations;

[Collection("Garmin Integrations")]
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

    [Fact]
    public async Task GetWorkouts_NotEmpty()
    {
        var workouts = await _lazyWorkouts.Value;

        Assert.NotEmpty(workouts);
    }

    [Fact]
    public async Task GetWorkoutTypes_NotNull()
    {
        var workoutTypes = await _garmin.GetWorkoutTypes(TestContext.Current.CancellationToken);

        Assert.NotNull(workoutTypes);
    }

    [Fact]
    public async Task GetWorkout_NotNull()
    {
        var ct = TestContext.Current.CancellationToken;
        var workoutsParameters = new WorkoutsParameters { OrderBy = WorkoutsOrderBy.UPDATE_DATE };
        var workouts = await _garmin.GetWorkouts(workoutsParameters, ct);

        Assert.NotEmpty(workouts);

        var workout = await _garmin.GetWorkout(workouts.First().WorkoutId, ct);

        Assert.NotNull(workout);
    }

    [Fact]
    public async Task UpdateWorkout()
    {
        var ct = TestContext.Current.CancellationToken;
        var expectedConditionValue = 2000;
        var workoutId = (await _lazyWorkouts.Value).First().WorkoutId;

        var workout = await _garmin.GetWorkout(workoutId, ct);

        Assert.NotEmpty(workout.WorkoutSegments);
        Assert.NotEmpty(workout.WorkoutSegments.First().WorkoutSteps);

        var originalWorkoutStep = workout.WorkoutSegments.First().WorkoutSteps[0];
        workout.WorkoutSegments.First().WorkoutSteps[0] =
            originalWorkoutStep with { EndConditionValue = expectedConditionValue };
        await _garmin.UpdateWorkout(workout, ct);
        workout = await _garmin.GetWorkout(workoutId, ct);

        Assert.Equal(expectedConditionValue, workout.WorkoutSegments.First().WorkoutSteps.First().EndConditionValue);

        workout.WorkoutSegments.First().WorkoutSteps[0] = originalWorkoutStep with
        {
            EndConditionValue = originalWorkoutStep.EndConditionValue
        };
        await _garmin.UpdateWorkout(workout, ct);
        workout = await _garmin.GetWorkout(workoutId, ct);

        Assert.Equal(originalWorkoutStep.EndConditionValue,
            workout.WorkoutSegments.First().WorkoutSteps.First().EndConditionValue);
    }

    [Fact]
    public async Task ScheduleWorkout()
    {
        var ct = TestContext.Current.CancellationToken;
        var workouts = await _lazyWorkouts.Value;
        var workout = workouts.First();
        var scheduleDate = DateOnly.FromDateTime(workout.CreatedDate);

        Assert.NotEmpty(workouts);

        var calendarWeek = await _garmin.GetCalendarByWeek(scheduleDate, ct);

        Assert.DoesNotContain(calendarWeek.CalendarItems, x => x.WorkoutId == workout.WorkoutId);

        await _garmin.ScheduleWorkout(workout.WorkoutId, scheduleDate, ct);
        calendarWeek = await _garmin.GetCalendarByWeek(scheduleDate, ct);

        Assert.Contains(calendarWeek.CalendarItems, x => x.WorkoutId == workout.WorkoutId);

        var calendarId = calendarWeek.CalendarItems
            .First(x => x.WorkoutId == workout.WorkoutId).Id;
        await _garmin.RemoveScheduledWorkout(calendarId, ct);
        calendarWeek = await _garmin.GetCalendarByWeek(scheduleDate, ct);

        Assert.DoesNotContain(calendarWeek.CalendarItems, x => x.WorkoutId == workout.WorkoutId);
    }

    [Fact(Skip = "Not for CI only for self test")]
    public async Task SendToDevice()
    {
        var ct = TestContext.Current.CancellationToken;
        var workouts = await _lazyWorkouts.Value;
        var workout = workouts.First();

        Assert.Equal("running", workout.SportType.SportTypeKey);

        var deviceId = (await _garmin.GetDevices(ct)).First(device => device.SupportedHrZones.Contains("RUNNING"))
            .DeviceId;

        await _garmin.SendWorkoutToDevices(workout.WorkoutId, [deviceId], ct);

        var deviceMessages = await _garmin.GetDeviceMessages(ct);

        Assert.Contains(deviceMessages.Messages,
            x => x.MessageType == "workouts" && x.DeviceId == deviceId && x.MetaData.MetaDataId == workout.WorkoutId);
    }

    [Fact(Skip = "Not for CI only for self test")]
    public async Task UploadFileFromLocalMachine()
    {
        var filename = "/some.fit";

        await _garmin.UploadFile(filename, TestContext.Current.CancellationToken);
    }

    [Fact(Skip = "Not for CI only for self test")]
    public async Task UploadFileFromStream()
    {
        var ct = TestContext.Current.CancellationToken;
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