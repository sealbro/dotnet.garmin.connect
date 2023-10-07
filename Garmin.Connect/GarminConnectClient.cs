using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Garmin.Connect.Models;

namespace Garmin.Connect;

public partial class GarminConnectClient : IGarminConnectClient
{
    private readonly GarminConnectContext _context;

    private const string UserProfileUrl = "/userprofile-service/socialProfile";
    private const string UserPreferencesUrl = "/userprofile-service/preferences";
    private const string UserSettingsUrl = "/userprofile-service/userprofile/user-settings";
    private const string UserSummaryUrl = "/usersummary-service/usersummary/daily/";
    private const string UserSummaryChartUrl = "/wellness-service/wellness/dailySummaryChart/";
    private const string HeartRatesUrl = "/wellness-service/wellness/dailyHeartRate/";
    private const string SleepDataUrl = "/wellness-service/wellness/dailySleepData/";
    private const string BodyCompositionUrl = "/weight-service/weight/daterangesnapshot";
    private const string ActivitiesUrl = "/activitylist-service/activities/search/activities";
    private const string HydrationDataUrl = "/usersummary-service/usersummary/hydration/daily/";
    private const string ActivityUrl = "/activity-service/activity/";
    private const string PersonalRecordUrl = "/personalrecord-service/personalrecord/";
    private const string TcxDownloadUrl = "/download-service/export/tcx/activity/";
    private const string GpxDownloadUrl = "/download-service/export/gpx/activity/";
    private const string KmlDownloadUrl = "/download-service/export/kml/activity/";
    private const string FitDownloadUrl = "/download-service/files/activity/";
    private const string CsvDownloadUrl = "/download-service/export/csv/activity/";
    private const string DeviceListUrl = "/device-service/deviceregistration/devices";
    private const string DeviceServiceUrl = "/device-service/deviceservice/";
    private const string GearUrl = "/gear-service/gear/";

    public GarminConnectClient(GarminConnectContext context)
    {
        _context = context;
    }

    #region Activities

    public Task<GarminActivity[]> GetActivities(int start, int limit)
    {
        var activitiesUrl = $"{ActivitiesUrl}?start={start}&limit={limit}";

        return _context.GetAndDeserialize<GarminActivity[]>(activitiesUrl);
    }

    public async Task<GarminActivity[]> GetActivitiesByDate(DateTime startDate, DateTime endDate,
        string activityType)
    {
        string activitySlug;

        var start = 0;
        var limit = 20;

        // mimicking the behavior of the web interface that fetches 20 activities at a time
        // and automatically loads more on scroll
        if (!string.IsNullOrEmpty(activityType))
        {
            activitySlug = "&activityType=" + activityType;
        }
        else
        {
            activitySlug = "";
        }

        var result = new List<GarminActivity>();

        var returnData = true;
        while (returnData)
        {
            var activitiesUrl =
                $"{ActivitiesUrl}?startDate={startDate:yyyy-MM-dd}&endDate={endDate:yyyy-MM-dd}&start={start}&limit={limit}{activitySlug}";

            var activities = await _context.GetAndDeserialize<GarminActivity[]>(activitiesUrl);

            if (activities.Any())
            {
                result.AddRange(activities);
                start += limit;
            }
            else
            {
                returnData = false;
            }
        }

        return result.ToArray();
    }

    public Task<GarminExerciseSets> GetActivityExerciseSets(long activityId)
    {
        var exerciseSetsUrl = $"{ActivityUrl}{activityId}";

        return _context.GetAndDeserialize<GarminExerciseSets>(exerciseSetsUrl);
    }

    public Task<GarminActivitySplits> GetActivitySplits(long activityId)
    {
        var splitsUrl = $"{ActivityUrl}{activityId}/splits";

        return _context.GetAndDeserialize<GarminActivitySplits>(splitsUrl);
    }

    public Task<GarminSplitSummary> GetActivitySplitSummaries(long activityId)
    {
        var splitSummariesUrl = $"{ActivityUrl}{activityId}/split_summaries";

        return _context.GetAndDeserialize<GarminSplitSummary>(splitSummariesUrl);
    }

    public Task<GarminActivityWeather> GetActivityWeather(long activityId)
    {
        var activityWeatherUrl = $"{ActivityUrl}{activityId}/weather";

        return _context.GetAndDeserialize<GarminActivityWeather>(activityWeatherUrl);
    }

    public Task<GarminHrTimeInZones[]> GetActivityHrInTimezones(long activityId)
    {
        var activityHrTimezoneUrl = $"{ActivityUrl}{activityId}/hrTimeInZones";

        return _context.GetAndDeserialize<GarminHrTimeInZones[]>(activityHrTimezoneUrl);
    }

    public Task<GarminActivityDetails> GetActivityDetails(long activityId, int maxChartSize,
        int maxPolylineSize = 4000)
    {
        var queryParams = $"maxChartSize={maxChartSize}&maxPolylineSize={maxPolylineSize}";
        var detailsUrl = $"{ActivityUrl}{activityId}/details?{queryParams}";

        return _context.GetAndDeserialize<GarminActivityDetails>(detailsUrl);
    }

    public async Task<byte[]> DownloadActivity(long activityId, ActivityDownloadFormat format)
    {
        var urls = new Dictionary<ActivityDownloadFormat, string>
        {
            {
                ActivityDownloadFormat.ORIGINAL,
                $"{FitDownloadUrl}{activityId}"
            },
            {
                ActivityDownloadFormat.TCX,
                $"{TcxDownloadUrl}{activityId}"
            },
            {
                ActivityDownloadFormat.GPX,
                $"{GpxDownloadUrl}{activityId}"
            },
            {
                ActivityDownloadFormat.KML,
                $"{KmlDownloadUrl}{activityId}"
            },
            {
                ActivityDownloadFormat.CSV,
                $"{CsvDownloadUrl}{activityId}"
            }
        };
        if (!urls.ContainsKey(format))
        {
            throw new ArgumentException($"Unexpected value {format} for dl_fmt");
        }

        var url = urls[format];

        var response = await _context.MakeHttpGet(url);

        return await response.Content.ReadAsByteArrayAsync();
    }

    #endregion

    #region Device

    public Task<GarminDevice[]> GetDevices()
    {
        return _context.GetAndDeserialize<GarminDevice[]>(DeviceListUrl);
    }

    public Task<GarminDeviceSettings> GetDeviceSettings(long deviceId)
    {
        var devicesUrl = $"{DeviceServiceUrl}device-info/settings/{deviceId}";

        return _context.GetAndDeserialize<GarminDeviceSettings>(devicesUrl);
    }

    public Task<GarminDeviceLastUsed> GetDeviceLastUsed()
    {
        const string deviceLastUsedUrl = $"{DeviceServiceUrl}mylastused";

        return _context.GetAndDeserialize<GarminDeviceLastUsed>(deviceLastUsedUrl);
    }

    #endregion

    #region MyRegion

    public Task<GarminGearType[]> GetGearTypes()
    {
        const string gearTypesUrl = $"{GearUrl}types";

        return _context.GetAndDeserialize<GarminGearType[]>(gearTypesUrl);
    }

    public Task<GarminGear[]> GetUserGears(long userId)
    {
        string userGearsUrl = $"{GearUrl}filterGear?userProfilePk={userId}";

        return _context.GetAndDeserialize<GarminGear[]>(userGearsUrl);
    }

    public Task<GarminGear[]> GetActivityGears(long activityId)
    {
        string activityGearsUrl = $"{GearUrl}filterGear?activityId={activityId}";

        return _context.GetAndDeserialize<GarminGear[]>(activityGearsUrl);
    }

    #endregion

    #region Owner

    public async Task<GarminSocialProfile> GetSocialProfile()
    {
        if (_context.Profile is null)
        {
            _context.Profile = await _context.GetAndDeserialize<GarminSocialProfile>(UserProfileUrl);
        }

        return _context.Profile;
    }

    public Task<GarminUserSettings> GetUserSettings()
    {
        return _context.GetAndDeserialize<GarminUserSettings>(UserSettingsUrl);
    }

    public Task<GarminPersonalRecord[]> GetPersonalRecord(string ownerDisplayName)
    {
        var personalRecordsUrl = $"{PersonalRecordUrl}prs/{ownerDisplayName}";

        return _context.GetAndDeserialize<GarminPersonalRecord[]>(personalRecordsUrl);
    }

    #endregion

    #region Wellness

    public async Task<GarminStepsData[]> GetWellnessStepsData(DateTime date)
    {
        var profile = await GetSocialProfile();

        return await _context.GetAndDeserialize<GarminStepsData[]>(
            $"{UserSummaryChartUrl}{profile.DisplayName}?date={date:yyyy-MM-dd}");
    }

    public async Task<GarminStats> GetUserSummary(DateTime date)
    {
        var profile = await GetSocialProfile();

        return await _context.GetAndDeserialize<GarminStats>(
            $"{UserSummaryUrl}{profile.DisplayName}?calendarDate={date:yyy-MM-dd}");
    }

    public async Task<GarminHr> GetWellnessHeartRates(DateTime date)
    {
        var profile = await GetSocialProfile();

        return await _context.GetAndDeserialize<GarminHr>(
            $"{HeartRatesUrl}{profile.DisplayName}?date={date:yyyy-MM-dd}");
    }

    public async Task<GarminSleepData> GetWellnessSleepData(DateTime date)
    {
        var profile = await GetSocialProfile();

        return await _context.GetAndDeserialize<GarminSleepData>(
            $"{SleepDataUrl}{profile.DisplayName}?date={date:yyyy-MM-dd}");
    }

    public Task<GarminBodyComposition> GetBodyComposition(DateTime startDate, DateTime endDate)
    {
        var bodyCompositionUrl =
            $"{BodyCompositionUrl}?startDate={startDate:yyyy-MM-dd}&endDate={endDate:yyyy-MM-dd}";

        return _context.GetAndDeserialize<GarminBodyComposition>(bodyCompositionUrl);
    }

    public Task<GarminHydrationData> GetHydrationData(DateTime date)
    {
        var hydrationUrl = $"{HydrationDataUrl}{date:yyyy-MM-dd}";

        return _context.GetAndDeserialize<GarminHydrationData>(hydrationUrl);
    }

    #endregion
}