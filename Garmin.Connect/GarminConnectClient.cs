using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Garmin.Connect.Models;

namespace Garmin.Connect
{
    public class GarminConnectClient : IGarminConnectClient
    {
        private readonly GarminConnectContext _context;

        private const string UserSummaryUrl = "/proxy/usersummary-service/usersummary/daily/";
        private const string UserSummaryChartUrl = "/proxy/wellness-service/wellness/dailySummaryChart/";
        private const string HeartRatesUrl = "/proxy/wellness-service/wellness/dailyHeartRate/";
        private const string SleepDataUrl = "/proxy/wellness-service/wellness/dailySleepData/";
        private const string BodyCompositionUrl = "/proxy/weight-service/weight/daterangesnapshot";
        private const string ActivitiesUrl = "/proxy/activitylist-service/activities/search/activities";
        private const string HydrationDataUrl = "/proxy/usersummary-service/usersummary/hydration/daily/";
        private const string ActivityUrl = "/proxy/activity-service/activity/";
        private const string PersonalRecordUrl = "/proxy/personalrecord-service/personalrecord/";
        private const string TcxDownloadUrl = "/proxy/download-service/export/tcx/activity/";
        private const string GpxDownloadUrl = "/proxy/download-service/export/gpx/activity/";
        private const string KmlDownloadUrl = "/proxy/download-service/export/kml/activity/";
        private const string FitDownloadUrl = "/proxy/download-service/files/activity/";
        private const string CsvDownloadUrl = "/proxy/download-service/export/csv/activity/";
        private const string DeviceListUrl = "/proxy/device-service/deviceregistration/devices";
        private const string DeviceServiceUrl = "/proxy/device-service/deviceservice/";

        public GarminConnectClient(GarminConnectContext context)
        {
            _context = context;
        }

        public Task<GarminActivity[]> GetActivities(int start, int limit)
        {
            var activitiesUrl = $"{ActivitiesUrl}?start={start}&limit={limit}";

            return _context.WrapTryRetry<GarminActivity[]>(_ => activitiesUrl);
        }

        public Task<GarminDevice[]> GetDevices()
        {
            return _context.WrapTryRetry<GarminDevice[]>(_ => DeviceListUrl);
        }

        public Task<GarminStepsData[]> GetWellnessStepsData(DateTime date)
        {
            return _context.WrapTryRetry<GarminStepsData[]>(displayName =>
                $"{UserSummaryChartUrl}{displayName}?date={date:yyyy-MM-dd}");
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

                var activities = await _context.WrapTryRetry<GarminActivity[]>(_ => activitiesUrl);

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

        public async Task<GarminUserPreferences> GetPreferences()
        {
            await _context.ReLoginIfExpired();

            return _context.Preferences;
        }

        public async Task<GarminSocialProfile> GetSocialProfile()
        {
            await _context.ReLoginIfExpired();

            return _context.Profile;
        }

        public Task<GarminStats> GetUserSummary(DateTime date)
        {
            return _context.WrapTryRetry<GarminStats>(displayName =>
                $"{UserSummaryUrl}{displayName}?calendarDate={date:yyy-MM-dd}");
        }

        public Task<GarminHr> GetWellnessHeartRates(DateTime date)
        {
            return _context.WrapTryRetry<GarminHr>(displayName =>
                $"{HeartRatesUrl}{displayName}?date={date:yyyy-MM-dd}");
        }

        public Task<GarminSleepData> GetWellnessSleepData(DateTime date)
        {
            return _context.WrapTryRetry<GarminSleepData>(displayName =>
                $"{SleepDataUrl}{displayName}?date={date:yyyy-MM-dd}");
        }

        public Task<GarminBodyComposition> GetBodyComposition(DateTime startDate, DateTime endDate)
        {
            var bodyCompositionUrl =
                $"{BodyCompositionUrl}?startDate={startDate:yyyy-MM-dd}&endDate={endDate:yyyy-MM-dd}";

            return _context.WrapTryRetry<GarminBodyComposition>(_ => bodyCompositionUrl);
        }

        public Task<GarminDeviceSettings> GetDeviceSettings(long deviceId)
        {
            var devicesUrl = $"{DeviceServiceUrl}device-info/settings/{deviceId}";

            return _context.WrapTryRetry<GarminDeviceSettings>(_ => devicesUrl);
        }

        public Task<GarminHydrationData> GetHydrationData(DateTime date)
        {
            var hydrationUrl = $"{HydrationDataUrl}{date:yyyy-MM-dd}";

            return _context.WrapTryRetry<GarminHydrationData>(_ => hydrationUrl);
        }

        public Task<GarminExcerciseSets> GetActivityExcerciseSets(long activityId)
        {
            var exerciseSetsUrl = $"{ActivityUrl}{activityId}";

            return _context.WrapTryRetry<GarminExcerciseSets>(_ => exerciseSetsUrl);
        }

        public Task<GarminActivitySplits> GetActivitySplits(long activityId)
        {
            var splitsUrl = $"{ActivityUrl}{activityId}/splits";

            return _context.WrapTryRetry<GarminActivitySplits>(_ => splitsUrl);
        }

        public Task<GarminSplitSummary> GetActivitySplitSummaries(long activityId)
        {
            var splitSummariesUrl = $"{ActivityUrl}{activityId}/split_summaries";

            return _context.WrapTryRetry<GarminSplitSummary>(_ => splitSummariesUrl);
        }

        public Task<GarminActivityWeather> GetActivityWeather(long activityId)
        {
            var activityWeatherUrl = $"{ActivityUrl}{activityId}/weather";

            return _context.WrapTryRetry<GarminActivityWeather>(_ => activityWeatherUrl);
        }

        public Task<GarminHrTimeInZones[]> GetActivityHrInTimezones(long activityId)
        {
            var activityHrTimezoneUrl = $"{ActivityUrl}{activityId}/hrTimeInZones";

            return _context.WrapTryRetry<GarminHrTimeInZones[]>(_ => activityHrTimezoneUrl);
        }

        public Task<GarminActivityDetails> GetActivityDetails(long activityId, int maxChartSize,
            int maxPolylineSize = 4000)
        {
            var queryParams = $"maxChartSize={maxChartSize}&maxPolylineSize={maxPolylineSize}";
            var detailsUrl = $"{ActivityUrl}{activityId}/details?{queryParams}";

            return _context.WrapTryRetry<GarminActivityDetails>(_ => detailsUrl);
        }

        public Task<GarminPersonalRecord[]> GetPersonalRecord(string ownerDisplayName)
        {
            var personalRecordsUrl = $"{PersonalRecordUrl}prs/{ownerDisplayName}";

            return _context.WrapTryRetry<GarminPersonalRecord[]>(_ => personalRecordsUrl);
        }

        public Task<GarminDeviceLastUsed> GetDeviceLastUsed()
        {
            var deviceLastUsedUrl = $"{DeviceServiceUrl}mylastused";

            return _context.WrapTryRetry<GarminDeviceLastUsed>(_ => deviceLastUsedUrl);
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

            var response = await _context.GetAsync(url);

            return await response.Content.ReadAsByteArrayAsync();
        }
    }
}