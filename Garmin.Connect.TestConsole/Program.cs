using System;
using System.Threading.Tasks;
using Garmin.Connect;
using Garmin.Connect.Auth;

namespace SmartHouse.TestConsole
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            var desplayName = "";
            var login = "";
            var password = "";
            var activityId = "7750630617";
            var deviceId = "3357095888";

            var dateTime = DateTime.Now.AddDays(-1);


            IGarminConnectClient garmin =
                new GarminConnectClient(new GarminConnectContext(new BasicAuthParameters(login, password)));

            var downloadActivity = await garmin.DownloadActivity(activityId);
            var garminDeviceLastUsed = await garmin.GetDeviceLastUsed();
            var personalRecords = await garmin.GetPersonalRecord(desplayName);
            var garminHrTimeInZonesArray = await garmin.GetActivityHrInTimezones(activityId);
            var garminActivitySplits = await garmin.GetActivitySplits(activityId);
            var garminActivityWeather = await garmin.GetActivityWeather(activityId);
            var garminExcerciseSets = await garmin.GetActivityExcerciseSets(activityId);
            var garminActivityDetails = await garmin.GetActivityDetails(activityId, 50, 50);
            var activitySplitSummaries = await garmin.GetActivitySplitSummaries(activityId);
            var garminDeviceSettings = await garmin.GetDeviceSettings(deviceId);
            var garminBodyComposition = await garmin.GetBodyComposition(DateTime.Now.AddDays(-1), DateTime.Now);
            var garminHydrationData = await garmin.GetHydrationData(DateTime.Now.AddDays(-1));
            var wellnessHeartRates = await garmin.GetWellnessHeartRates(dateTime);
            var wellnessSleepData = await garmin.GetWellnessSleepData(dateTime);
            var activityExcerciseSets = await garmin.GetActivityExcerciseSets(activityId);
            var userSummary = await garmin.GetUserSummary(dateTime);
            var activitiesByDate =
                await garmin.GetActivitiesByDate(DateTime.Now.AddDays(-7), DateTime.Now.AddDays(-2), "running");
            var garminActivities = await garmin.GetActivities(1, 1);
            var garminDevices = await garmin.GetDevices();
            var wellnessStepsData = await garmin.GetWellnessStepsData(dateTime);
        }
    }
}