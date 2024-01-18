using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Garmin.Connect.Models;
using Garmin.Connect.Models.Internal;

namespace Garmin.Connect;

public partial class GarminConnectClient
{
    public Task SetUserWeight(double weight, CancellationToken cancellationToken = default)
    {
        var garminSetUserWeight = new GarminSetUserWeight(weight);
        return _context.MakeHttpPut(UserSettingsUrl, garminSetUserWeight, cancellationToken: cancellationToken);
    }

    public Task SetUserSleepTimes(long? sleepTime, long? wakeTime, CancellationToken cancellationToken = default)
    {
        var garminUserSettings = new GarminSetUserSleepTimes(sleepTime, wakeTime);

        return _context.MakeHttpPut(UserSettingsUrl, garminUserSettings, cancellationToken: cancellationToken);
    }

    public Task UpdateWorkout(GarminWorkout workout, CancellationToken cancellationToken = default)
    {
        if (workout.WorkoutId == 0)
        {
            throw new ArgumentException("WorkoutId must be from existing workout");
        }

        var workoutUrl = $"{WorkoutUrl}{workout.WorkoutId}";

        var headers = new Dictionary<string, string> { { "X-Http-Method-Override", "PUT" } };

        return _context.MakeHttpPost(workoutUrl, GarminUpdateWorkout.From(workout), headers, cancellationToken);
    }

    public Task ScheduleWorkout(long workoutId, DateOnly date, CancellationToken cancellationToken = default)
    {
        var workoutUrl = $"{WorkoutScheduleUrl}{workoutId}";

        return _context.MakeHttpPost(workoutUrl, new GarminDateRequest { Date = date }, cancellationToken: cancellationToken);
    }
}