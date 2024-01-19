using System;
using System.Linq;
using System.Threading.Tasks;
using Garmin.Connect.Parameters;
using Xunit;

namespace Garmin.Connect.Tests.Integrations;

[Collection("Garmin Integrations")]
public class WorkoutTests
{
    private readonly IGarminConnectClient _garmin;

    public WorkoutTests()
    {
        _garmin = LazyClient.Garmin.Value;
    }

    [Fact]
    public async Task GetWorkouts_NotEmpty()
    {
        var workouts = await _garmin.GetWorkouts(new WorkoutsParameters { Limit = 200 });

        Assert.NotEmpty(workouts);
    }

    [Fact]
    public async Task GetWorkoutTypes_NotNull()
    {
        var workoutTypes = await _garmin.GetWorkoutTypes();

        Assert.NotNull(workoutTypes);
    }

    [Fact]
    public async Task GetWorkout_NotNull()
    {
        var workoutsParameters = new WorkoutsParameters
            { OrderSeq = OrderSeq.ASC, OrderBy = WorkoutsOrderBy.UPDATE_DATE };
        var workouts = await _garmin.GetWorkouts(workoutsParameters);

        Assert.NotEmpty(workouts);

        var workout = await _garmin.GetWorkout(workouts.First().WorkoutId);

        Assert.NotNull(workout);
    }

    [Fact]
    public async Task UpdateWorkout()
    {
        var expectedConditionValue = 2000;
        var workoutId = (await _garmin.GetWorkouts(new WorkoutsParameters
            { OrderSeq = OrderSeq.ASC, OrderBy = WorkoutsOrderBy.CREATED_DATE })).First().WorkoutId;

        var workout = await _garmin.GetWorkout(workoutId);

        Assert.NotEmpty(workout.WorkoutSegments);
        Assert.NotEmpty(workout.WorkoutSegments.First().WorkoutSteps);

        var originalWorkoutStep = workout.WorkoutSegments.First().WorkoutSteps[0];
        workout.WorkoutSegments.First().WorkoutSteps[0] =
            originalWorkoutStep with { EndConditionValue = expectedConditionValue };
        await _garmin.UpdateWorkout(workout);
        workout = await _garmin.GetWorkout(workoutId);

        Assert.Equal(expectedConditionValue, workout.WorkoutSegments.First().WorkoutSteps.First().EndConditionValue);

        workout.WorkoutSegments.First().WorkoutSteps[0] = originalWorkoutStep with
        {
            EndConditionValue = originalWorkoutStep.EndConditionValue
        };
        await _garmin.UpdateWorkout(workout);
        workout = await _garmin.GetWorkout(workoutId);

        Assert.Equal(originalWorkoutStep.EndConditionValue,
            workout.WorkoutSegments.First().WorkoutSteps.First().EndConditionValue);
    }

    [Fact]
    public async Task ScheduleWorkout()
    {
        var workouts = await _garmin.GetWorkouts(new WorkoutsParameters { OrderSeq = OrderSeq.ASC, Limit = 5 });
        var workout = workouts.First();
        var scheduleDate = DateOnly.FromDateTime(workout.CreatedDate);

        Assert.NotEmpty(workouts);

        var calendarWeek = await _garmin.GetCalendarWeek(scheduleDate);

        Assert.DoesNotContain(calendarWeek.CalendarItems, x => x.WorkoutId == workout.WorkoutId);

        await _garmin.ScheduleWorkout(workout.WorkoutId, scheduleDate);
        calendarWeek = await _garmin.GetCalendarWeek(scheduleDate);

        Assert.Contains(calendarWeek.CalendarItems, x => x.WorkoutId == workout.WorkoutId);

        var calendarId = calendarWeek.CalendarItems
            .First(x => x.WorkoutId == workout.WorkoutId).Id;
        await _garmin.RemoveScheduledWorkout(calendarId);
        calendarWeek = await _garmin.GetCalendarWeek(scheduleDate);

        Assert.DoesNotContain(calendarWeek.CalendarItems, x => x.WorkoutId == workout.WorkoutId);
    }
}