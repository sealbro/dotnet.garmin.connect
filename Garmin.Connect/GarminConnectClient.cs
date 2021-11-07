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

        private const string UrlUserSummary = "/proxy/usersummary-service/usersummary/daily/";
        private const string UrlUserSummaryChart = "/proxy/wellness-service/wellness/dailySummaryChart/";
        private const string UrlHeartRates = "/proxy/wellness-service/wellness/dailyHeartRate/";
        private const string UrlSleepData = "/proxy/wellness-service/wellness/dailySleepData/";
        private const string UrlBodyComposition = "/proxy/weight-service/weight/daterangesnapshot";
        private const string UrlActivities = "/proxy/activitylist-service/activities/search/activities";
        private const string UrlHydrationData = "/proxy/usersummary-service/usersummary/hydration/daily/";
        private const string UrlActivity = "/proxy/activity-service/activity/";
        private const string UrlPersonalRecord = "/proxy/personalrecord-service/personalrecord/";
        private const string UrlTcxDownload = "/proxy/download-service/export/tcx/activity/";
        private const string UrlGpxDownload = "/proxy/download-service/export/gpx/activity/";
        private const string UrlKmlDownload = "/proxy/download-service/export/kml/activity/";
        private const string UrlFitDownload = "/proxy/download-service/files/activity/";
        private const string UrlCsvDownload = "/proxy/download-service/export/csv/activity/";
        private const string UrlDeviceList = "/proxy/device-service/deviceregistration/devices";
        private const string UrlDeviceService = "/proxy/device-service/deviceservice/";

        public GarminConnectClient(GarminConnectContext context)
        {
            _context = context;
        }

        public Task<GarminActivity[]> GetActivities(int start, int limit)
        {
            var activitiesUrl = $"{UrlActivities}?start={start}&limit={limit}";

            return _context.WrapTryRetry<GarminActivity[]>(_ => activitiesUrl);
        }

        public Task<GarminDevice[]> GetDevices()
        {
            return _context.WrapTryRetry<GarminDevice[]>(_ => UrlDeviceList);
        }

        public Task<GarminStepsData[]> GetWellnessStepsData(DateTime date)
        {
            return _context.WrapTryRetry<GarminStepsData[]>(displayName =>
                $"{UrlUserSummaryChart}{displayName}?date={date:yyyy-MM-dd}");
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
                    $"{UrlActivities}?startDate={startDate:yyyy-MM-dd}&endDate={endDate:yyyy-MM-dd}&start={start}&limit={limit}{activitySlug}";

                var activities = await _context.WrapTryRetry<GarminActivity[]>(_ => activitiesUrl);

                if (activities != null && activities.Any())
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
                $"{UrlUserSummary}{displayName}?calendarDate={date:yyy-MM-dd}");
        }

        public Task<GarminHr> GetWellnessHeartRates(DateTime date)
        {
            return _context.WrapTryRetry<GarminHr>(displayName =>
                $"{UrlHeartRates}{displayName}?date={date:yyyy-MM-dd}");
        }

        public Task<GarminSleepData> GetWellnessSleepData(DateTime date)
        {
            return _context.WrapTryRetry<GarminSleepData>(displayName =>
                $"{UrlSleepData}{displayName}?date={date:yyyy-MM-dd}");
        }

        public Task<GarminBodyComposition> GetBodyComposition(DateTime startDate, DateTime endDate)
        {
            var bodyCompositionUrl =
                $"{UrlBodyComposition}?startDate={startDate:yyyy-MM-dd}&endDate={endDate:yyyy-MM-dd}";

            return _context.WrapTryRetry<GarminBodyComposition>(_ => bodyCompositionUrl);
        }

        public Task<GarminDeviceSettings> GetDeviceSettings(string deviceId)
        {
            var devicesUrl = $"{UrlDeviceService}device-info/settings/{deviceId}";

            return _context.WrapTryRetry<GarminDeviceSettings>(_ => devicesUrl);
        }

        public Task<GarminHydrationData> GetHydrationData(DateTime date)
        {
            var hydrationUrl = $"{UrlHydrationData}{date:yyyy-MM-dd}";

            return _context.WrapTryRetry<GarminHydrationData>(_ => hydrationUrl);
        }

        public Task<GarminExcerciseSets> GetActivityExcerciseSets(string activityId)
        {
            var exerciseSetsUrl = $"{UrlActivity}{activityId}";

            return _context.WrapTryRetry<GarminExcerciseSets>(_ => exerciseSetsUrl);
        }

        public Task<GarminActivitySplits> GetActivitySplits(string activityId)
        {
            var splitsUrl = $"{UrlActivity}{activityId}/splits";

            return _context.WrapTryRetry<GarminActivitySplits>(_ => splitsUrl);
        }

        public Task<GarminSplitSummary> GetActivitySplitSummaries(string activityId)
        {
            var splitSummariesUrl = $"{UrlActivity}{activityId}/split_summaries";

            return _context.WrapTryRetry<GarminSplitSummary>(_ => splitSummariesUrl);
        }

        public Task<GarminActivityWeather> GetActivityWeather(string activityId)
        {
            var activityWeatherUrl = $"{UrlActivity}{activityId}/weather";

            return _context.WrapTryRetry<GarminActivityWeather>(_ => activityWeatherUrl);
        }

        public Task<GarminHrTimeInZones[]> GetActivityHrInTimezones(string activityId)
        {
            var activityHrTimezoneUrl = $"{UrlActivity}{activityId}/hrTimeInZones";

            return _context.WrapTryRetry<GarminHrTimeInZones[]>(_ => activityHrTimezoneUrl);
        }

        public Task<GarminActivityDetails> GetActivityDetails(string activityId, int maxChartSize, int maxPolylineSize)
        {
            var queryParams = $"maxChartSize={maxChartSize}&maxPolylineSize={maxPolylineSize}";
            var detailsUrl = $"{UrlActivity}{activityId}/details?{queryParams}";

            return _context.WrapTryRetry<GarminActivityDetails>(_ => detailsUrl);
        }

        public Task<GarminPersonalRecord[]> GetPersonalRecord(string ownerDisplayName)
        {
            var personalRecordsUrl = $"{UrlPersonalRecord}prs/{ownerDisplayName}";

            return _context.WrapTryRetry<GarminPersonalRecord[]>(_ => personalRecordsUrl);
        }

        public Task<GarminDeviceLastUsed> GetDeviceLastUsed()
        {
            var deviceLastUsedUrl = $"{UrlDeviceService}mylastused";

            return _context.WrapTryRetry<GarminDeviceLastUsed>(_ => deviceLastUsedUrl);
        }

        public async Task<byte[]> DownloadActivity(string activityId, ActivityDownloadFormat format)
        {
            var urls = new Dictionary<ActivityDownloadFormat, string>
            {
                {
                    ActivityDownloadFormat.ORIGINAL,
                    $"{UrlFitDownload}{activityId}"
                },
                {
                    ActivityDownloadFormat.TCX,
                    $"{UrlTcxDownload}{activityId}"
                },
                {
                    ActivityDownloadFormat.GPX,
                    $"{UrlGpxDownload}{activityId}"
                },
                {
                    ActivityDownloadFormat.KML,
                    $"{UrlKmlDownload}{activityId}"
                },
                {
                    ActivityDownloadFormat.CSV,
                    $"{UrlCsvDownload}{activityId}"
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