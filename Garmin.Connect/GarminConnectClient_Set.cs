using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Garmin.Connect.Models;
using Garmin.Connect.Models.Internal;

namespace Garmin.Connect;

public partial class GarminConnectClient
{
    private static readonly string[] ValidExtensions =
    [
        // Garmin Activity Files
        ".fit", ".tcx", ".gpx",
        // Fitbit® body or activity data
        ".csv", ".xls", ".xlsx"
    ];

    public async Task SetUserWeight(double weight, CancellationToken cancellationToken = default)
    {
        var garminSetUserWeight = new GarminSetUserWeight(weight);
        using var response =
            await _context.MakeHttpPut(UserSettingsUrl, garminSetUserWeight, cancellationToken: cancellationToken);
    }

    public async Task SetUserSleepTimes(long? sleepTime, long? wakeTime,
        CancellationToken cancellationToken = default)
    {
        var garminUserSettings = new GarminSetUserSleepTimes(sleepTime, wakeTime);

        using var response =
            await _context.MakeHttpPut(UserSettingsUrl, garminUserSettings, cancellationToken: cancellationToken);
    }

    public async Task UpdateWorkout(GarminWorkout workout, CancellationToken cancellationToken = default)
    {
        if (workout.WorkoutId == 0)
        {
            throw new ArgumentException("WorkoutId must be from existing workout");
        }

        var workoutUrl = $"{WorkoutUrl}{workout.WorkoutId}";

        var headers = new Dictionary<string, string> { { "X-Http-Method-Override", "PUT" } };

        using var response =
            await _context.MakeHttpPost(workoutUrl, GarminUpdateWorkout.From(workout), headers, cancellationToken);
    }

    public async Task ScheduleWorkout(long workoutId, DateOnly date, CancellationToken cancellationToken = default)
    {
        var workoutUrl = $"{WorkoutScheduleUrl}{workoutId}";

        using var response = await _context.MakeHttpPost(workoutUrl, new GarminDateRequest { Date = date },
            cancellationToken: cancellationToken);
    }

    public async Task RemoveScheduledWorkout(long calendarId, CancellationToken cancellationToken = default)
    {
        var workoutUrl = $"{WorkoutScheduleUrl}{calendarId}";

        using var response = await _context.MakeHttpDelete(workoutUrl, cancellationToken: cancellationToken);
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

        using var response =
            await _context.MakeHttpPost(DeviceMessageUrl, sendToDevice, cancellationToken: cancellationToken);
    }

    public async Task<bool> AddBloodPressure(GarminBloodPressure bloodPressureData,
        CancellationToken cancellationToken = default)
    {
        if (!bloodPressureData.IsValid())
        {
            return false;
        }

        var roundedDateTime = new DateTime(
            bloodPressureData.MeasurementDateTime.Year,
            bloodPressureData.MeasurementDateTime.Month,
            bloodPressureData.MeasurementDateTime.Day,
            bloodPressureData.MeasurementDateTime.Hour,
            bloodPressureData.MeasurementDateTime.Minute,
            0);
        var request = new GarminBloodPressureRequest
        {
            Version = null,
            Systolic = bloodPressureData.Systolic,
            Diastolic = bloodPressureData.Diastolic,
            Pulse = bloodPressureData.Pulse,
            MultiMeasurement = false,
            Notes = bloodPressureData.Notes,
            SourceType = "MANUAL",
            MeasurementTimestampLocal = roundedDateTime,
            MeasurementTimestampGmt = roundedDateTime.ToUniversalTime(),
            Category = null,
            CategoryName = null
        };

        using var response =
            await _context.MakeHttpPost(BloodPressureUrl, request, cancellationToken: cancellationToken);

        return true;
    }

    public async Task RemoveBloodPressure(GarminBloodPressureIdentifier bloodPressureIdentifier,
        CancellationToken cancellationToken = default)
    {
        var url =
            $"{BloodPressureUrl}/{bloodPressureIdentifier.MeasurementTimestampGmt:yyyy-MM-dd}/{bloodPressureIdentifier.Version}";

        using var response = await _context.MakeHttpDelete(url, cancellationToken: cancellationToken);
    }

    public async Task<bool> AddWeight(GarminWeight weightData, CancellationToken cancellationToken = default)
    {
        if (!weightData.IsValid())
        {
            return false;
        }

        var roundedDateTime = new DateTime(
            weightData.MeasurementDateTime.Year,
            weightData.MeasurementDateTime.Month,
            weightData.MeasurementDateTime.Day,
            weightData.MeasurementDateTime.Hour,
            weightData.MeasurementDateTime.Minute,
            0);
        var request = new GarminWeightRequest
        {
            DateTimestamp = roundedDateTime,
            GmtTimestamp = roundedDateTime.ToUniversalTime(),
            UnitKey = weightData.UnitKey.ToString().ToLowerInvariant(),
            Value = weightData.Value
        };

        using var response = await _context.MakeHttpPost(WeightUrl, request, cancellationToken: cancellationToken);

        return true;
    }

    public async Task RemoveWeight(GarminWeightIdentifier weightIdentifier, CancellationToken cancellationToken = default)
    {
        var url = $"{WeightUrl}/{weightIdentifier.CalendarDate:yyyy-MM-dd}/byversion/{weightIdentifier.SamplePk}";

        using var response = await _context.MakeHttpDelete(url, cancellationToken: cancellationToken);
    }

    public async Task UploadFile(string filepath, CancellationToken cancellationToken = default)
    {
        await using var fileStream = new FileStream(filepath, FileMode.Open, FileAccess.Read, FileShare.Read,
            bufferSize: 4096, FileOptions.Asynchronous | FileOptions.SequentialScan);

        await UploadFile(filepath, fileStream, cancellationToken);
    }

    public async Task UploadFile(string filename, Stream stream, CancellationToken cancellationToken = default)
    {
        var extension = Path.GetExtension(filename).ToLowerInvariant();
        if (!ValidExtensions.Contains(extension))
        {
            throw new ArgumentException($"File extension {extension} is not supported. Supported extensions are: {string.Join(", ", ValidExtensions)}");
        }

        var url = $"{UploadUrl}/{extension}";

        // Buffered up front so an authentication retry can rebuild the body: the previous
        // attempt's content is disposed, and the source stream may not be seekable.
        using var buffer = new MemoryStream();
        await stream.CopyToAsync(buffer, cancellationToken);
        var bytes = buffer.ToArray();
        var name = Path.GetFileName(filename);

        using var response = await _context.MakeHttpRequest(url, HttpMethod.Post, null, () =>
        {
            var fileContent = new ByteArrayContent(bytes)
            {
                Headers = { ContentType = new MediaTypeHeaderValue("application/octet-stream") }
            };

            return new MultipartFormDataContent { { fileContent, "userfile", name } };
        }, cancellationToken);
    }
}