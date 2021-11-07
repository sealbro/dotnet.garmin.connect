using System;
using System.Text.Json.Serialization;

namespace Garmin.Connect.Models
{
    public class GarminStats
    {
        [JsonPropertyName("userProfileId")]
        public long UserProfileId { get; set; }

        [JsonPropertyName("totalKilocalories")]
        public double TotalKilocalories { get; set; }

        [JsonPropertyName("activeKilocalories")]
        public double ActiveKilocalories { get; set; }

        [JsonPropertyName("bmrKilocalories")]
        public double BmrKilocalories { get; set; }

        [JsonPropertyName("wellnessKilocalories")]
        public double WellnessKilocalories { get; set; }

        [JsonPropertyName("burnedKilocalories")]
        public object BurnedKilocalories { get; set; }

        [JsonPropertyName("consumedKilocalories")]
        public double ConsumedKilocalories { get; set; }

        [JsonPropertyName("remainingKilocalories")]
        public double RemainingKilocalories { get; set; }

        [JsonPropertyName("totalSteps")]
        public long TotalSteps { get; set; }

        [JsonPropertyName("netCalorieGoal")]
        public long NetCalorieGoal { get; set; }

        [JsonPropertyName("totalDistanceMeters")]
        public long TotalDistanceMeters { get; set; }

        [JsonPropertyName("wellnessDistanceMeters")]
        public long WellnessDistanceMeters { get; set; }

        [JsonPropertyName("wellnessActiveKilocalories")]
        public double WellnessActiveKilocalories { get; set; }

        [JsonPropertyName("netRemainingKilocalories")]
        public double NetRemainingKilocalories { get; set; }

        [JsonPropertyName("userDailySummaryId")]
        public long UserDailySummaryId { get; set; }

        [JsonPropertyName("calendarDate")]
        public DateTimeOffset CalendarDate { get; set; }

        [JsonPropertyName("rule")]
        public Rule Rule { get; set; }

        [JsonPropertyName("uuid")]
        public string Uuid { get; set; }

        [JsonPropertyName("dailyStepGoal")]
        public long DailyStepGoal { get; set; }

        [JsonPropertyName("wellnessStartTimeGmt")]
        public DateTimeOffset WellnessStartTimeGmt { get; set; }

        [JsonPropertyName("wellnessStartTimeLocal")]
        public DateTimeOffset WellnessStartTimeLocal { get; set; }

        [JsonPropertyName("wellnessEndTimeGmt")]
        public DateTimeOffset WellnessEndTimeGmt { get; set; }

        [JsonPropertyName("wellnessEndTimeLocal")]
        public DateTimeOffset WellnessEndTimeLocal { get; set; }

        [JsonPropertyName("durationInMilliseconds")]
        public long DurationInMilliseconds { get; set; }

        [JsonPropertyName("wellnessDescription")]
        public object WellnessDescription { get; set; }

        [JsonPropertyName("highlyActiveSeconds")]
        public long HighlyActiveSeconds { get; set; }

        [JsonPropertyName("activeSeconds")]
        public long ActiveSeconds { get; set; }

        [JsonPropertyName("sedentarySeconds")]
        public long SedentarySeconds { get; set; }

        [JsonPropertyName("sleepingSeconds")]
        public long SleepingSeconds { get; set; }

        [JsonPropertyName("includesWellnessData")]
        public bool IncludesWellnessData { get; set; }

        [JsonPropertyName("includesActivityData")]
        public bool IncludesActivityData { get; set; }

        [JsonPropertyName("includesCalorieConsumedData")]
        public bool IncludesCalorieConsumedData { get; set; }

        [JsonPropertyName("privacyProtected")]
        public bool PrivacyProtected { get; set; }

        [JsonPropertyName("moderateIntensityMinutes")]
        public long ModerateIntensityMinutes { get; set; }

        [JsonPropertyName("vigorousIntensityMinutes")]
        public long VigorousIntensityMinutes { get; set; }

        [JsonPropertyName("floorsAscendedInMeters")]
        public double FloorsAscendedInMeters { get; set; }

        [JsonPropertyName("floorsDescendedInMeters")]
        public double FloorsDescendedInMeters { get; set; }

        [JsonPropertyName("floorsAscended")]
        public double FloorsAscended { get; set; }

        [JsonPropertyName("floorsDescended")]
        public double FloorsDescended { get; set; }

        [JsonPropertyName("intensityMinutesGoal")]
        public long IntensityMinutesGoal { get; set; }

        [JsonPropertyName("userFloorsAscendedGoal")]
        public long UserFloorsAscendedGoal { get; set; }

        [JsonPropertyName("minHeartRate")]
        public long MinHeartRate { get; set; }

        [JsonPropertyName("maxHeartRate")]
        public long MaxHeartRate { get; set; }

        [JsonPropertyName("restingHeartRate")]
        public long RestingHeartRate { get; set; }

        [JsonPropertyName("lastSevenDaysAvgRestingHeartRate")]
        public long LastSevenDaysAvgRestingHeartRate { get; set; }

        [JsonPropertyName("source")]
        public string Source { get; set; }

        [JsonPropertyName("averageStressLevel")]
        public long AverageStressLevel { get; set; }

        [JsonPropertyName("maxStressLevel")]
        public long MaxStressLevel { get; set; }

        [JsonPropertyName("stressDuration")]
        public long StressDuration { get; set; }

        [JsonPropertyName("restStressDuration")]
        public long RestStressDuration { get; set; }

        [JsonPropertyName("activityStressDuration")]
        public long ActivityStressDuration { get; set; }

        [JsonPropertyName("uncategorizedStressDuration")]
        public long UncategorizedStressDuration { get; set; }

        [JsonPropertyName("totalStressDuration")]
        public long TotalStressDuration { get; set; }

        [JsonPropertyName("lowStressDuration")]
        public long LowStressDuration { get; set; }

        [JsonPropertyName("mediumStressDuration")]
        public long MediumStressDuration { get; set; }

        [JsonPropertyName("highStressDuration")]
        public long HighStressDuration { get; set; }

        [JsonPropertyName("stressPercentage")]
        public double StressPercentage { get; set; }

        [JsonPropertyName("restStressPercentage")]
        public double RestStressPercentage { get; set; }

        [JsonPropertyName("activityStressPercentage")]
        public double ActivityStressPercentage { get; set; }

        [JsonPropertyName("uncategorizedStressPercentage")]
        public double UncategorizedStressPercentage { get; set; }

        [JsonPropertyName("lowStressPercentage")]
        public double LowStressPercentage { get; set; }

        [JsonPropertyName("mediumStressPercentage")]
        public double MediumStressPercentage { get; set; }

        [JsonPropertyName("highStressPercentage")]
        public double HighStressPercentage { get; set; }

        [JsonPropertyName("stressQualifier")]
        public string StressQualifier { get; set; }

        [JsonPropertyName("measurableAwakeDuration")]
        public long MeasurableAwakeDuration { get; set; }

        [JsonPropertyName("measurableAsleepDuration")]
        public long MeasurableAsleepDuration { get; set; }

        [JsonPropertyName("lastSyncTimestampGMT")]
        public object LastSyncTimestampGmt { get; set; }

        [JsonPropertyName("minAvgHeartRate")]
        public long MinAvgHeartRate { get; set; }

        [JsonPropertyName("maxAvgHeartRate")]
        public long MaxAvgHeartRate { get; set; }

        [JsonPropertyName("bodyBatteryChargedValue")]
        public long BodyBatteryChargedValue { get; set; }

        [JsonPropertyName("bodyBatteryDrainedValue")]
        public long BodyBatteryDrainedValue { get; set; }

        [JsonPropertyName("bodyBatteryHighestValue")]
        public long BodyBatteryHighestValue { get; set; }

        [JsonPropertyName("bodyBatteryLowestValue")]
        public long BodyBatteryLowestValue { get; set; }

        [JsonPropertyName("bodyBatteryMostRecentValue")]
        public long BodyBatteryMostRecentValue { get; set; }

        [JsonPropertyName("bodyBatteryVersion")]
        public double BodyBatteryVersion { get; set; }

        [JsonPropertyName("abnormalHeartRateAlertsCount")]
        public object AbnormalHeartRateAlertsCount { get; set; }

        [JsonPropertyName("averageSpo2")]
        public object AverageSpo2 { get; set; }

        [JsonPropertyName("lowestSpo2")]
        public object LowestSpo2 { get; set; }

        [JsonPropertyName("latestSpo2")]
        public object LatestSpo2 { get; set; }

        [JsonPropertyName("latestSpo2ReadingTimeGmt")]
        public object LatestSpo2ReadingTimeGmt { get; set; }

        [JsonPropertyName("latestSpo2ReadingTimeLocal")]
        public object LatestSpo2ReadingTimeLocal { get; set; }

        [JsonPropertyName("averageMonitoringEnvironmentAltitude")]
        public double AverageMonitoringEnvironmentAltitude { get; set; }

        [JsonPropertyName("avgWakingRespirationValue")]
        public double AvgWakingRespirationValue { get; set; }

        [JsonPropertyName("highestRespirationValue")]
        public double HighestRespirationValue { get; set; }

        [JsonPropertyName("lowestRespirationValue")]
        public double LowestRespirationValue { get; set; }

        [JsonPropertyName("latestRespirationValue")]
        public double LatestRespirationValue { get; set; }

        [JsonPropertyName("latestRespirationTimeGMT")]
        public DateTimeOffset LatestRespirationTimeGmt { get; set; }
    }

    public class Rule
    {
        [JsonPropertyName("typeId")]
        public long TypeId { get; set; }

        [JsonPropertyName("typeKey")]
        public string TypeKey { get; set; }
    }
}