using System;
using System.Collections.Generic;
using System.Linq;
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

        return _context.MakeHttpPost(workoutUrl, new GarminDateRequest { Date = date },
            cancellationToken: cancellationToken);
    }

    public Task RemoveScheduledWorkout(long calendarId, CancellationToken cancellationToken = default)
    {
        var workoutUrl = $"{WorkoutScheduleUrl}{calendarId}";

        return _context.MakeHttpDelete(workoutUrl, cancellationToken: cancellationToken);
    }

    public async Task SendWorkoutToDevices(long workoutId, long[] deviceIds,
        CancellationToken cancellationToken = default)
    {
        if (workoutId == 0)
        {
            throw new ArgumentException("WorkoutId must be from existing workout");
        }

        if (deviceIds is null || deviceIds.Length == 0)
        {
            throw new ArgumentException("DeviceIds must be not empty");
        }

        var workoutTask = GetWorkout(workoutId, cancellationToken);
        var devicesTask = GetDevices(cancellationToken);
        await Task.WhenAll(workoutTask, devicesTask);
        var workout = await workoutTask;
        var devices = await devicesTask;

        if (workout.WorkoutId != workoutId)
        {
            throw new ArgumentException("Workout not found");
        }

        var devicesNotFound = deviceIds.Except(devices.Select(x => x.DeviceId)).ToArray();
        if (devicesNotFound.Any())
        {
            throw new ArgumentException($"Devices [{string.Join(",", devicesNotFound)}] not found");
        }

        var sendToDevice = devices
            .Where(device => deviceIds.Contains(device.DeviceId))
            .Select(device => new GarminSendToDevice
            {
                DeviceId = device.DeviceId,
                MessageType = "workouts",
                MessageUrl = $"workout-service/workout/FIT/{workoutId}",
                FileType = "FIT",
                MessageName = workout.WorkoutName,
                Priority = 1,
                MetaDataId = workoutId,
                GroupName = null,
            }).ToArray();

        await _context.MakeHttpPost(DeviceMessageUrl, sendToDevice, cancellationToken: cancellationToken);
    }
}