using System;
using System.Text.Json.Serialization;

namespace Garmin.Connect.Models;

public record GarminStats
{
    [JsonPropertyName("userProfileId")]
    public long UserProfileId { get; init; }

    [JsonPropertyName("totalKilocalories")]
    public double TotalKilocalories { get; init; }

    [JsonPropertyName("activeKilocalories")]
    public double ActiveKilocalories { get; init; }

    [JsonPropertyName("bmrKilocalories")]
    public double BmrKilocalories { get; init; }

    [JsonPropertyName("wellnessKilocalories")]
    public double WellnessKilocalories { get; init; }

    [JsonPropertyName("burnedKilocalories")]
    public object BurnedKilocalories { get; init; }

    [JsonPropertyName("consumedKilocalories")]
    public double ConsumedKilocalories { get; init; }

    [JsonPropertyName("remainingKilocalories")]
    public double RemainingKilocalories { get; init; }

    [JsonPropertyName("totalSteps")]
    public long TotalSteps { get; init; }

    [JsonPropertyName("netCalorieGoal")]
    public long NetCalorieGoal { get; init; }

    [JsonPropertyName("totalDistanceMeters")]
    public long TotalDistanceMeters { get; init; }

    [JsonPropertyName("wellnessDistanceMeters")]
    public long WellnessDistanceMeters { get; init; }

    [JsonPropertyName("wellnessActiveKilocalories")]
    public double WellnessActiveKilocalories { get; init; }

    [JsonPropertyName("netRemainingKilocalories")]
    public double NetRemainingKilocalories { get; init; }

    [JsonPropertyName("userDailySummaryId")]
    public long UserDailySummaryId { get; init; }

    [JsonPropertyName("calendarDate")]
    public DateTime CalendarDate { get; init; }

    [JsonPropertyName("rule")]
    public Rule Rule { get; init; }

    [JsonPropertyName("uuid")]
    public string Uuid { get; init; }

    [JsonPropertyName("dailyStepGoal")]
    public long DailyStepGoal { get; init; }

    [JsonPropertyName("wellnessStartTimeGmt")]
    public DateTime WellnessStartTimeGmt { get; init; }

    [JsonPropertyName("wellnessStartTimeLocal")]
    public DateTime WellnessStartTimeLocal { get; init; }

    [JsonPropertyName("wellnessEndTimeGmt")]
    public DateTime WellnessEndTimeGmt { get; init; }

    [JsonPropertyName("wellnessEndTimeLocal")]
    public DateTime WellnessEndTimeLocal { get; init; }

    [JsonPropertyName("durationInMilliseconds")]
    public long DurationInMilliseconds { get; init; }

    [JsonPropertyName("wellnessDescription")]
    public object WellnessDescription { get; init; }

    [JsonPropertyName("highlyActiveSeconds")]
    public long HighlyActiveSeconds { get; init; }

    [JsonPropertyName("activeSeconds")]
    public long ActiveSeconds { get; init; }

    [JsonPropertyName("sedentarySeconds")]
    public long SedentarySeconds { get; init; }

    [JsonPropertyName("sleepingSeconds")]
    public long SleepingSeconds { get; init; }

    [JsonPropertyName("includesWellnessData")]
    public bool IncludesWellnessData { get; init; }

    [JsonPropertyName("includesActivityData")]
    public bool IncludesActivityData { get; init; }

    [JsonPropertyName("includesCalorieConsumedData")]
    public bool IncludesCalorieConsumedData { get; init; }

    [JsonPropertyName("privacyProtected")]
    public bool PrivacyProtected { get; init; }

    [JsonPropertyName("moderateIntensityMinutes")]
    public long ModerateIntensityMinutes { get; init; }

    [JsonPropertyName("vigorousIntensityMinutes")]
    public long VigorousIntensityMinutes { get; init; }

    [JsonPropertyName("floorsAscendedInMeters")]
    public double FloorsAscendedInMeters { get; init; }

    [JsonPropertyName("floorsDescendedInMeters")]
    public double FloorsDescendedInMeters { get; init; }

    [JsonPropertyName("floorsAscended")]
    public double FloorsAscended { get; init; }

    [JsonPropertyName("floorsDescended")]
    public double FloorsDescended { get; init; }

    [JsonPropertyName("intensityMinutesGoal")]
    public long IntensityMinutesGoal { get; init; }

    [JsonPropertyName("userFloorsAscendedGoal")]
    public long UserFloorsAscendedGoal { get; init; }

    [JsonPropertyName("minHeartRate")]
    public long MinHeartRate { get; init; }

    [JsonPropertyName("maxHeartRate")]
    public long MaxHeartRate { get; init; }

    [JsonPropertyName("restingHeartRate")]
    public long RestingHeartRate { get; init; }

    [JsonPropertyName("lastSevenDaysAvgRestingHeartRate")]
    public long LastSevenDaysAvgRestingHeartRate { get; init; }

    [JsonPropertyName("source")]
    public string Source { get; init; }

    [JsonPropertyName("averageStressLevel")]
    public long AverageStressLevel { get; init; }

    [JsonPropertyName("maxStressLevel")]
    public long MaxStressLevel { get; init; }

    [JsonPropertyName("stressDuration")]
    public long StressDuration { get; init; }

    [JsonPropertyName("restStressDuration")]
    public long RestStressDuration { get; init; }

    [JsonPropertyName("activityStressDuration")]
    public long ActivityStressDuration { get; init; }

    [JsonPropertyName("uncategorizedStressDuration")]
    public long UncategorizedStressDuration { get; init; }

    [JsonPropertyName("totalStressDuration")]
    public long TotalStressDuration { get; init; }

    [JsonPropertyName("lowStressDuration")]
    public long LowStressDuration { get; init; }

    [JsonPropertyName("mediumStressDuration")]
    public long MediumStressDuration { get; init; }

    [JsonPropertyName("highStressDuration")]
    public long HighStressDuration { get; init; }

    [JsonPropertyName("stressPercentage")]
    public double StressPercentage { get; init; }

    [JsonPropertyName("restStressPercentage")]
    public double RestStressPercentage { get; init; }

    [JsonPropertyName("activityStressPercentage")]
    public double ActivityStressPercentage { get; init; }

    [JsonPropertyName("uncategorizedStressPercentage")]
    public double UncategorizedStressPercentage { get; init; }

    [JsonPropertyName("lowStressPercentage")]
    public double LowStressPercentage { get; init; }

    [JsonPropertyName("mediumStressPercentage")]
    public double MediumStressPercentage { get; init; }

    [JsonPropertyName("highStressPercentage")]
    public double HighStressPercentage { get; init; }

    [JsonPropertyName("stressQualifier")]
    public string StressQualifier { get; init; }

    [JsonPropertyName("measurableAwakeDuration")]
    public long MeasurableAwakeDuration { get; init; }

    [JsonPropertyName("measurableAsleepDuration")]
    public long MeasurableAsleepDuration { get; init; }

    [JsonPropertyName("lastSyncTimestampGMT")]
    public object LastSyncTimestampGmt { get; init; }

    [JsonPropertyName("minAvgHeartRate")]
    public long MinAvgHeartRate { get; init; }

    [JsonPropertyName("maxAvgHeartRate")]
    public long MaxAvgHeartRate { get; init; }

    [JsonPropertyName("bodyBatteryChargedValue")]
    public long BodyBatteryChargedValue { get; init; }

    [JsonPropertyName("bodyBatteryDrainedValue")]
    public long BodyBatteryDrainedValue { get; init; }

    [JsonPropertyName("bodyBatteryHighestValue")]
    public long BodyBatteryHighestValue { get; init; }

    [JsonPropertyName("bodyBatteryLowestValue")]
    public long BodyBatteryLowestValue { get; init; }

    [JsonPropertyName("bodyBatteryMostRecentValue")]
    public long BodyBatteryMostRecentValue { get; init; }

    [JsonPropertyName("bodyBatteryVersion")]
    public double BodyBatteryVersion { get; init; }

    [JsonPropertyName("abnormalHeartRateAlertsCount")]
    public object AbnormalHeartRateAlertsCount { get; init; }

    [JsonPropertyName("averageSpo2")]
    public object AverageSpo2 { get; init; }

    [JsonPropertyName("lowestSpo2")]
    public object LowestSpo2 { get; init; }

    [JsonPropertyName("latestSpo2")]
    public object LatestSpo2 { get; init; }

    [JsonPropertyName("latestSpo2ReadingTimeGmt")]
    public object LatestSpo2ReadingTimeGmt { get; init; }

    [JsonPropertyName("latestSpo2ReadingTimeLocal")]
    public object LatestSpo2ReadingTimeLocal { get; init; }

    [JsonPropertyName("averageMonitoringEnvironmentAltitude")]
    public double AverageMonitoringEnvironmentAltitude { get; init; }

    [JsonPropertyName("avgWakingRespirationValue")]
    public double AvgWakingRespirationValue { get; init; }

    [JsonPropertyName("highestRespirationValue")]
    public double HighestRespirationValue { get; init; }

    [JsonPropertyName("lowestRespirationValue")]
    public double LowestRespirationValue { get; init; }

    [JsonPropertyName("latestRespirationValue")]
    public double LatestRespirationValue { get; init; }

    [JsonPropertyName("latestRespirationTimeGMT")]
    public DateTime LatestRespirationTimeGmt { get; init; }
}

public record Rule
{
    [JsonPropertyName("typeId")]
    public long TypeId { get; init; }

    [JsonPropertyName("typeKey")]
    public string TypeKey { get; init; }
}