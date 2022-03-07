using System;
using System.Threading.Tasks;

using Garmin.Connect.Models;

namespace Garmin.Connect;

public interface IGarminConnectClient
{
    Task<GarminUserPreferences> GetPreferences();

    Task<GarminSocialProfile> GetSocialProfile();

    /// <summary>
    /// Fetch user settings
    /// </summary>
    Task<GarminUserSettings> GetUserSettings();

    /// <summary>
    /// Fetch available activity data
    /// </summary>
    Task<GarminStats> GetUserSummary(DateTime date);

    /// <summary>
    /// Fetch available sleep data
    /// </summary>
    Task<GarminSleepData> GetWellnessSleepData(DateTime date);

    /// <summary>
    /// Fetch available heart rates data
    /// </summary>
    Task<GarminHr> GetWellnessHeartRates(DateTime date);

    /// <summary>
    /// Fetch available steps data
    /// </summary>
    Task<GarminStepsData[]> GetWellnessStepsData(DateTime date);

    /// <summary>
    /// Fetch available hydration data
    /// </summary>
    Task<GarminHydrationData> GetHydrationData(DateTime date);

    /// <summary>
    /// Fetch available body composition data (only for date)
    /// </summary>
    Task<GarminBodyComposition> GetBodyComposition(DateTime startDate, DateTime endDate);

    /// <summary>
    /// Fetch personal records by owner display name
    /// </summary>
    Task<GarminPersonalRecord[]> GetPersonalRecord(string ownerDisplayName);

    /// <summary>
    /// Fetch device last used
    /// </summary>
    Task<GarminDeviceLastUsed> GetDeviceLastUsed();

    /// <summary>
    /// Fetch device settings for current device
    /// </summary>
    Task<GarminDeviceSettings> GetDeviceSettings(long deviceId);

    /// <summary>
    /// Fetch available devices for the current account
    /// </summary>
    Task<GarminDevice[]> GetDevices();

    /// <summary>
    /// Fetch activity split summaries
    /// </summary>
    Task<GarminSplitSummary> GetActivitySplitSummaries(long activityId);

    /// <summary>
    /// Fetch activity details
    /// </summary>
    Task<GarminActivityDetails> GetActivityDetails(long activityId, int maxChartSize = 2000,
        int maxPolylineSize = 4000);

    /// <summary>
    /// Fetch activity excercise sets
    /// </summary>
    Task<GarminExcerciseSets> GetActivityExcerciseSets(long activityId);

    /// <summary>
    /// Fetch activity weather
    /// </summary>
    Task<GarminActivityWeather> GetActivityWeather(long activityId);

    /// <summary>
    ///  Fetch activity splits
    /// </summary>
    Task<GarminActivitySplits> GetActivitySplits(long activityId);

    /// <summary>
    /// Fetch activity HR in timezones
    /// </summary>
    Task<GarminHrTimeInZones[]> GetActivityHrInTimezones(long activityId);

    /// <summary>
    /// Downloads activity in requested format and returns the raw bytes. For
    /// "Original" will return the zip file content, up to user to extract it.
    /// "CSV" will return a csv of the splits.
    /// </summary>
    Task<byte[]> DownloadActivity(long activityId, ActivityDownloadFormat format = ActivityDownloadFormat.TCX);

    /// <summary>
    /// Fetch available activities
    /// </summary>
    Task<GarminActivity[]> GetActivities(int start, int limit);

    /// <summary>
    /// Fetch available activities between specific dates
    /// </summary>
    /// <param name="startDate"></param>
    /// <param name="endDate"></param>
    /// <param name="activityType">
    /// (Optional) Type of activity you are searching
    /// Possible values are [cycling, running, swimming, multi_sport, fitness_equipment, hiking, walking, other]
    /// </param>
    Task<GarminActivity[]> GetActivitiesByDate(DateTime startDate, DateTime endDate, string activityType = "");

    /// <summary>
    /// Fetch gear types.
    /// </summary>
    Task<GarminGearType[]> GetGearTypes();

    /// <summary>
    /// Fetch user gears.
    /// </summary>
    Task<GarminGear[]> GetUserGears(long userId);

    /// <summary>
    /// Fetch activity gears.
    /// </summary>
    Task<GarminGear[]> GetActivityGears(long activityId);

    /// <summary>
    /// Sets user's weight in grams.
    /// </summary>
    public Task SetUserWeight(double weight);

    /// <summary>
    /// Sets user's sleep and wake times.
    /// Null values set default time.
    /// </summary>
    public Task SetUserSleepTimes(long? sleepTime, long? wakeTime);
}