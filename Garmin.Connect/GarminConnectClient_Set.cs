using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Garmin.Connect.Models;
using Garmin.Connect.Models.Internal;

namespace Garmin.Connect;

public partial class GarminConnectClient
{
    public Task SetUserWeight(double weight)
    {
        var garminSetUserWeight = new GarminSetUserWeight(weight);
        return _context.MakeHttpPut(UserSettingsUrl, garminSetUserWeight);
    }

    public Task SetUserSleepTimes(long? sleepTime, long? wakeTime)
    {
        var garminUserSettings = new GarminSetUserSleepTimes(sleepTime, wakeTime);

        return _context.MakeHttpPut(UserSettingsUrl, garminUserSettings);
    }

    public Task UpdateWorkout(GarminWorkout workout)
    {
        if (workout.WorkoutId == 0)
        {
            throw new ArgumentException("WorkoutId must be from existing workout");
        }

        var workoutUrl = $"{WorkoutUrl}{workout.WorkoutId}";

        var headers = new Dictionary<string, string> { { "X-Http-Method-Override", "PUT" } };

        return _context.MakeHttpPost(workoutUrl, GarminUpdateWorkout.From(workout), headers);
    }

    public Task ScheduleWorkout(long workoutId, DateOnly date)
    {
        var workoutUrl = $"{WorkoutScheduleUrl}{workoutId}";

        return _context.MakeHttpPost(workoutUrl, new GarminDateRequest { Date = date });
    }
}