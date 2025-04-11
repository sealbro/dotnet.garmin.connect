using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Garmin.Connect.Models;
using Garmin.Connect.Parameters;

namespace Garmin.Connect;

public interface IGarminConnectClient
{
    /// <summary>
    /// Fetch owner social profile
    /// </summary>
    Task<GarminSocialProfile> GetSocialProfile(CancellationToken cancellationToken = default);

    /// <summary>
    /// Fetch user settings
    /// </summary>
    Task<GarminUserSettings> GetUserSettings(CancellationToken cancellationToken = default);

    /// <summary>
    /// Fetch available activity data
    /// </summary>
    Task<GarminStats> GetUserSummary(DateTime date, CancellationToken cancellationToken = default);

    /// <summary>
    /// Fetch available sleep data
    /// </summary>
    Task<GarminSleepData> GetWellnessSleepData(DateTime date, CancellationToken cancellationToken = default);

    /// <summary>
    /// Fetch available heart rates data
    /// </summary>
    Task<GarminHr> GetWellnessHeartRates(DateTime date, CancellationToken cancellationToken = default);

    /// <summary>
    /// Fetch available steps data
    /// </summary>
    Task<GarminStepsData[]> GetWellnessStepsData(DateTime date, CancellationToken cancellationToken = default);

    /// <summary>
    /// Fetch hrv summary data between specific dates
    /// </summary>
    Task<GarminReportHrvStatus> GetReportHrvStatus(DateTime startDate, DateTime endDate,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Fetch available hydration data
    /// </summary>
    Task<GarminHydrationData> GetHydrationData(DateTime date, CancellationToken cancellationToken = default);

    /// <summary>
    /// Fetch available body composition data (only for date)
    /// </summary>
    Task<GarminBodyComposition> GetBodyComposition(DateTime startDate, DateTime endDate,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Fetch available body battery data (only for date)
    /// </summary>
    Task<GarminBodyBatteryData[]> GetWelnessBodyBatteryData(DateTime startDate, DateTime endDate,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Fetch personal records by owner display name
    /// </summary>
    Task<GarminPersonalRecord[]> GetPersonalRecord(string ownerDisplayName,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Fetch device last used
    /// </summary>
    Task<GarminDeviceLastUsed> GetDeviceLastUsed(CancellationToken cancellationToken = default);

    /// <summary>
    /// Fetch device settings for current device
    /// </summary>
    Task<GarminDeviceSettings> GetDeviceSettings(long deviceId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Fetch available devices for the current account
    /// </summary>
    Task<GarminDevice[]> GetDevices(CancellationToken cancellationToken = default);

    /// <summary>
    /// Get messages for device
    /// </summary>
    Task<GarminDeviceMessages> GetDeviceMessages(CancellationToken cancellationToken = default);

    /// <summary>
    /// Fetch activity split summaries
    /// </summary>
    Task<GarminSplitSummary> GetActivitySplitSummaries(long activityId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Fetch activity details
    /// </summary>
    Task<GarminActivityDetails> GetActivityDetails(long activityId, int maxChartSize = 2000,
        int maxPolylineSize = 4000, CancellationToken cancellationToken = default);

    /// <summary>
    /// Fetch activity exercise sets
    /// </summary>
    Task<GarminExerciseSets> GetActivityExerciseSets(long activityId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Fetch activity weather
    /// </summary>
    Task<GarminActivityWeather> GetActivityWeather(long activityId, CancellationToken cancellationToken = default);

    /// <summary>
    ///  Fetch activity splits
    /// </summary>
    Task<GarminActivitySplits> GetActivitySplits(long activityId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Fetch activity HR in timezones
    /// </summary>
    Task<GarminHrTimeInZones[]>
        GetActivityHrInTimezones(long activityId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Downloads activity in requested format and returns the raw bytes. For
    /// "Original" will return the zip file content, up to user to extract it.
    /// "CSV" will return a csv of the splits.
    /// </summary>
    Task<byte[]> DownloadActivity(long activityId, ActivityDownloadFormat format = ActivityDownloadFormat.TCX,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Fetch available activities
    /// </summary>
    Task<GarminActivity[]> GetActivities(int start, int limit, CancellationToken cancellationToken = default);

    /// <summary>
    /// Fetch available activities between specific dates
    /// </summary>
    /// <param name="startDate">Start date of range when activities were</param>
    /// <param name="endDate">End date of range when activities were</param>
    /// <param name="activityType">
    /// (Optional) Type of activity you are searching
    /// Possible values are [cycling, running, swimming, multi_sport, fitness_equipment, hiking, walking, other]
    /// </param>
    /// <param name="cancellationToken"></param>
    Task<GarminActivity[]> GetActivitiesByDate(DateTime startDate, DateTime endDate, string activityType = "",
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Fetch gear types.
    /// </summary>
    Task<GarminGearType[]> GetGearTypes(CancellationToken cancellationToken = default);

    /// <summary>
    /// Fetch user gears.
    /// </summary>
    Task<GarminGear[]> GetUserGears(long userId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Fetch activity gears.
    /// </summary>
    Task<GarminGear[]> GetActivityGears(long activityId, CancellationToken cancellationToken = default);

    /// <summary>
    /// [Experimental] Sets user's weight in grams.
    /// </summary>
    [Obsolete("Use AddWeight(GarminWeight weight)")]
    Task SetUserWeight(double weight, CancellationToken cancellationToken = default);

    /// <summary>
    /// [Experimental] Sets user's sleep and wake times.
    /// Null values set default time.
    /// </summary>
    Task SetUserSleepTimes(long? sleepTime, long? wakeTime, CancellationToken cancellationToken = default);

    /// <summary>
    /// [Experimental] Update workout from exists.
    /// </summary>
    Task UpdateWorkout(GarminWorkout workout, CancellationToken cancellationToken = default);

    /// <summary>
    /// Fetch specific workout by id
    /// </summary>
    Task<GarminWorkout> GetWorkout(long workoutId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Fetch available workouts by parameters
    /// </summary>
    Task<GarminWorkout[]> GetWorkouts(WorkoutsParameters parameters, CancellationToken cancellationToken = default);

    /// <summary>
    /// Fetch available workout types
    /// (used for changing workout)
    /// </summary>
    Task<GarminWorkoutTypes> GetWorkoutTypes(CancellationToken cancellationToken = default);

    /// <summary>
    /// [Experimental] Send workout to devices or sync command to Garmin Connect App
    /// </summary>
    Task SendWorkoutToDevices(long workoutId, long[] deviceIds, CancellationToken cancellationToken = default);

    /// <summary>
    /// Schedule workout for specific date
    /// </summary>
    Task ScheduleWorkout(long workoutId, DateOnly date, CancellationToken cancellationToken = default);

    /// <summary>
    /// Remove scheduled workout by calendar id
    /// </summary>
    Task RemoveScheduledWorkout(long calendarId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Fetch calendar by year
    /// </summary>
    Task<GarminCalendarYear> GetCalendarByYear(int year, CancellationToken cancellationToken = default);

    /// <summary>
    /// Fetch calendar by month
    /// </summary>
    Task<GarminCalendarMonth> GetCalendarByMonth(int year, GarminMonth month,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Fetch calendar by week
    /// </summary>
    /// <param name="dateOnly">Any date from this week</param>
    /// <param name="cancellationToken"></param>
    Task<GarminCalendarWeek> GetCalendarByWeek(DateOnly dateOnly, CancellationToken cancellationToken = default);

    /// <summary>
    /// Fetch blood pressure daily data
    /// </summary>
    /// <param name="date">Date</param>
    /// <param name="cancellationToken"></param>
    Task<GarminBloodPressureDaily> GetBloodPressureDaily(DateTime date, CancellationToken cancellationToken = default);

    /// <summary>
    /// Fetch blood pressure range data
    /// <param name="startDate">Date start</param>
    /// <param name="endDate">Date end</param>
    /// <param name="cancellationToken"></param>
    Task<GarminBloodPressureMeasurement[]> GetBloodPressureRange(DateTime startDate, DateTime endDate,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Add blood pressure data
    /// </summary>
    /// <param name="bloodPressureData">Blood pressure data</param>
    /// <param name="cancellationToken"></param>
    Task<bool> AddBloodPressure(GarminBloodPressure bloodPressureData, CancellationToken cancellationToken = default);

    /// <summary>
    /// Remove blood pressure data
    /// </summary>
    /// <param name="bloodPressureIdentifier">Blood pressure identifier</param>
    /// <param name="cancellationToken"></param>
    Task RemoveBloodPressure(GarminBloodPressureIdentifier bloodPressureIdentifier, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get weight range data
    /// <param name="startDate">Date start</param>
    /// <param name="endDate">Date end</param>
    /// <param name="cancellationToken"></param>
    Task<GarminWeightRange> GetWeightRange(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default);

    /// <summary>
    /// Add weight data
    /// </summary>
    /// <param name="weightData">Weight data</param>
    /// <param name="cancellationToken"></param>
    Task<bool> AddWeight(GarminWeight weightData, CancellationToken cancellationToken = default);

    /// <summary>
    /// Remove weight data
    /// </summary>
    /// <param name="weightIdentifier">Weight identifier</param>
    /// <param name="cancellationToken"></param>
    Task RemoveWeight(GarminWeightIdentifier weightIdentifier, CancellationToken cancellationToken = default);

    /// <summary>
    /// Upload file to Garmin Connect from file path
    /// </summary>
    /// <param name="filepath">Full file path on your machine</param>
    /// <param name="cancellationToken"></param>
    Task UploadFile(string filepath, CancellationToken cancellationToken = default);

    /// <summary>
    /// Upload file to Garmin Connect from stream
    /// </summary>
    /// <param name="filename">File name with extension</param>
    /// <param name="stream">Stream with file content</param>
    /// <param name="cancellationToken"></param>
    Task UploadFile(string filename, Stream stream, CancellationToken cancellationToken = default);
}