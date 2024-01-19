using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Garmin.Connect.Models;
using Garmin.Connect.Parameters;

namespace Garmin.Connect;

public partial class GarminConnectClient : IGarminConnectClient
{
    private readonly GarminConnectContext _context;

    private const string UserProfileUrl = "/userprofile-service/socialProfile";
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
    private const string WorkoutUrl = "/workout-service/workout/";
    private const string WorkoutScheduleUrl = "/workout-service/schedule/";
    private const string WorkoutsUrl = "/workout-service/workouts";
    private const string ReportHrvStatusUrl = "/hrv-service/hrv/daily/";
    private const string CalendarYearUrl = "/calendar-service/year/";

    public GarminConnectClient(GarminConnectContext context)
    {
        _context = context;
    }

    #region Activities

    public Task<GarminActivity[]> GetActivities(int start, int limit, CancellationToken cancellationToken = default)
    {
        var activitiesUrl = $"{ActivitiesUrl}?start={start}&limit={limit}";

        return _context.GetAndDeserialize<GarminActivity[]>(activitiesUrl, cancellationToken);
    }

    public async Task<GarminActivity[]> GetActivitiesByDate(DateTime startDate, DateTime endDate,
        string activityType, CancellationToken cancellationToken = default)
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

            var activities = await _context.GetAndDeserialize<GarminActivity[]>(activitiesUrl, cancellationToken);

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

    public Task<GarminExerciseSets> GetActivityExerciseSets(long activityId,
        CancellationToken cancellationToken = default)
    {
        var exerciseSetsUrl = $"{ActivityUrl}{activityId}";

        return _context.GetAndDeserialize<GarminExerciseSets>(exerciseSetsUrl, cancellationToken);
    }

    public Task<GarminActivitySplits> GetActivitySplits(long activityId, CancellationToken cancellationToken = default)
    {
        var splitsUrl = $"{ActivityUrl}{activityId}/splits";

        return _context.GetAndDeserialize<GarminActivitySplits>(splitsUrl, cancellationToken);
    }

    public Task<GarminSplitSummary> GetActivitySplitSummaries(long activityId,
        CancellationToken cancellationToken = default)
    {
        var splitSummariesUrl = $"{ActivityUrl}{activityId}/split_summaries";

        return _context.GetAndDeserialize<GarminSplitSummary>(splitSummariesUrl, cancellationToken);
    }

    public Task<GarminActivityWeather> GetActivityWeather(long activityId,
        CancellationToken cancellationToken = default)
    {
        var activityWeatherUrl = $"{ActivityUrl}{activityId}/weather";

        return _context.GetAndDeserialize<GarminActivityWeather>(activityWeatherUrl, cancellationToken);
    }

    public Task<GarminHrTimeInZones[]> GetActivityHrInTimezones(long activityId,
        CancellationToken cancellationToken = default)
    {
        var activityHrTimezoneUrl = $"{ActivityUrl}{activityId}/hrTimeInZones";

        return _context.GetAndDeserialize<GarminHrTimeInZones[]>(activityHrTimezoneUrl, cancellationToken);
    }

    public Task<GarminActivityDetails> GetActivityDetails(long activityId, int maxChartSize,
        int maxPolylineSize = 4000, CancellationToken cancellationToken = default)
    {
        var queryParams = $"maxChartSize={maxChartSize}&maxPolylineSize={maxPolylineSize}";
        var detailsUrl = $"{ActivityUrl}{activityId}/details?{queryParams}";

        return _context.GetAndDeserialize<GarminActivityDetails>(detailsUrl, cancellationToken);
    }

    public async Task<byte[]> DownloadActivity(long activityId, ActivityDownloadFormat format,
        CancellationToken cancellationToken = default)
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

        var response = await _context.MakeHttpGet(url, cancellationToken: cancellationToken);

        return await response.Content.ReadAsByteArrayAsync(cancellationToken);
    }

    #endregion

    #region Calendar

    public Task<GarminCalendarYear> GetCalendarYear(int year, CancellationToken cancellationToken = default)
    {
        var calendarUrl = $"{CalendarYearUrl}{year}";

        return _context.GetAndDeserialize<GarminCalendarYear>(calendarUrl, cancellationToken);
    }

    public Task<GarminCalendarMonth> GetCalendarMonth(int year, GarminMonth month,
        CancellationToken cancellationToken = default)
    {
        var calendarUrl = $"{CalendarYearUrl}{year}/month/{month.GetHashCode()}";

        return _context.GetAndDeserialize<GarminCalendarMonth>(calendarUrl, cancellationToken);
    }

    public Task<GarminCalendarWeek> GetCalendarWeek(DateOnly dateOnly, CancellationToken cancellationToken = default)
    {
        var calendarUrl = $"{CalendarYearUrl}{dateOnly.Year}/month/{dateOnly.Month-1}/day/{dateOnly.Day}/start/1";

        return _context.GetAndDeserialize<GarminCalendarWeek>(calendarUrl, cancellationToken);
    }
    
    #endregion

    #region Device

    public Task<GarminDevice[]> GetDevices(CancellationToken cancellationToken = default)
    {
        return _context.GetAndDeserialize<GarminDevice[]>(DeviceListUrl, cancellationToken);
    }

    public Task<GarminDeviceSettings> GetDeviceSettings(long deviceId, CancellationToken cancellationToken = default)
    {
        var devicesUrl = $"{DeviceServiceUrl}device-info/settings/{deviceId}";

        return _context.GetAndDeserialize<GarminDeviceSettings>(devicesUrl, cancellationToken);
    }

    public Task<GarminDeviceLastUsed> GetDeviceLastUsed(CancellationToken cancellationToken = default)
    {
        const string deviceLastUsedUrl = $"{DeviceServiceUrl}mylastused";

        return _context.GetAndDeserialize<GarminDeviceLastUsed>(deviceLastUsedUrl, cancellationToken);
    }

    #endregion

    #region MyRegion

    public Task<GarminGearType[]> GetGearTypes(CancellationToken cancellationToken = default)
    {
        const string gearTypesUrl = $"{GearUrl}types";

        return _context.GetAndDeserialize<GarminGearType[]>(gearTypesUrl, cancellationToken);
    }

    public Task<GarminGear[]> GetUserGears(long userId, CancellationToken cancellationToken = default)
    {
        string userGearsUrl = $"{GearUrl}filterGear?userProfilePk={userId}";

        return _context.GetAndDeserialize<GarminGear[]>(userGearsUrl, cancellationToken);
    }

    public Task<GarminGear[]> GetActivityGears(long activityId, CancellationToken cancellationToken = default)
    {
        string activityGearsUrl = $"{GearUrl}filterGear?activityId={activityId}";

        return _context.GetAndDeserialize<GarminGear[]>(activityGearsUrl, cancellationToken);
    }

    #endregion

    #region Owner

    public async Task<GarminSocialProfile> GetSocialProfile(CancellationToken cancellationToken = default)
    {
        if (_context.Profile is null)
        {
            _context.Profile = await _context.GetAndDeserialize<GarminSocialProfile>(UserProfileUrl, cancellationToken);
        }

        return _context.Profile;
    }

    public Task<GarminUserSettings> GetUserSettings(CancellationToken cancellationToken = default)
    {
        return _context.GetAndDeserialize<GarminUserSettings>(UserSettingsUrl, cancellationToken);
    }

    public Task<GarminPersonalRecord[]> GetPersonalRecord(string ownerDisplayName,
        CancellationToken cancellationToken = default)
    {
        var personalRecordsUrl = $"{PersonalRecordUrl}prs/{ownerDisplayName}";

        return _context.GetAndDeserialize<GarminPersonalRecord[]>(personalRecordsUrl, cancellationToken);
    }

    #endregion

    #region Wellness

    public async Task<GarminStepsData[]> GetWellnessStepsData(DateTime date,
        CancellationToken cancellationToken = default)
    {
        var profile = await GetSocialProfile();

        return await _context.GetAndDeserialize<GarminStepsData[]>(
            $"{UserSummaryChartUrl}{profile.DisplayName}?date={date:yyyy-MM-dd}", cancellationToken);
    }

    public async Task<GarminStats> GetUserSummary(DateTime date, CancellationToken cancellationToken = default)
    {
        var profile = await GetSocialProfile();

        return await _context.GetAndDeserialize<GarminStats>(
            $"{UserSummaryUrl}{profile.DisplayName}?calendarDate={date:yyy-MM-dd}", cancellationToken);
    }

    public async Task<GarminHr> GetWellnessHeartRates(DateTime date, CancellationToken cancellationToken = default)
    {
        var profile = await GetSocialProfile();

        return await _context.GetAndDeserialize<GarminHr>(
            $"{HeartRatesUrl}{profile.DisplayName}?date={date:yyyy-MM-dd}", cancellationToken);
    }

    public async Task<GarminSleepData> GetWellnessSleepData(DateTime date,
        CancellationToken cancellationToken = default)
    {
        var profile = await GetSocialProfile();

        return await _context.GetAndDeserialize<GarminSleepData>(
            $"{SleepDataUrl}{profile.DisplayName}?date={date:yyyy-MM-dd}", cancellationToken);
    }

    public Task<GarminBodyComposition> GetBodyComposition(DateTime startDate, DateTime endDate,
        CancellationToken cancellationToken = default)
    {
        var bodyCompositionUrl =
            $"{BodyCompositionUrl}?startDate={startDate:yyyy-MM-dd}&endDate={endDate:yyyy-MM-dd}";

        return _context.GetAndDeserialize<GarminBodyComposition>(bodyCompositionUrl, cancellationToken);
    }

    public Task<GarminHydrationData> GetHydrationData(DateTime date, CancellationToken cancellationToken = default)
    {
        var hydrationUrl = $"{HydrationDataUrl}{date:yyyy-MM-dd}";

        return _context.GetAndDeserialize<GarminHydrationData>(hydrationUrl, cancellationToken);
    }

    #endregion

    #region Workouts

    public Task<GarminWorkout> GetWorkout(long workoutId, CancellationToken cancellationToken = default)
    {
        var workoutUrl = $"{WorkoutUrl}{workoutId}";

        return _context.GetAndDeserialize<GarminWorkout>(workoutUrl, cancellationToken);
    }

    public Task<GarminWorkoutTypes> GetWorkoutTypes(CancellationToken cancellationToken = default)
    {
        var workoutUrl = $"{WorkoutUrl}types";

        return _context.GetAndDeserialize<GarminWorkoutTypes>(workoutUrl, cancellationToken);
    }

    public Task<GarminWorkout[]> GetWorkouts(WorkoutsParameters parameters,
        CancellationToken cancellationToken = default)
    {
        var workoutsUrl = $"{WorkoutsUrl}?{parameters.ToQueryParams()}";

        return _context.GetAndDeserialize<GarminWorkout[]>(workoutsUrl, cancellationToken);
    }

    #endregion

    #region Reports

    public Task<GarminReportHrvStatus> GetReportHrvStatus(DateTime startDate, DateTime endDate,
        CancellationToken cancellationToken = default)
    {
        var hrvUrl =
            $"{ReportHrvStatusUrl}{startDate:yyyy-MM-dd}/{endDate:yyyy-MM-dd}";

        return _context.GetAndDeserialize<GarminReportHrvStatus>(hrvUrl, cancellationToken);
    }

    #endregion
}