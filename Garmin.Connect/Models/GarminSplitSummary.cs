using System;
using System.Text.Json.Serialization;
using Garmin.Connect.Converters;

namespace Garmin.Connect.Models;

public record GarminSplitSummary
{
    [JsonPropertyName("activityId")]
    public long ActivityId { get; init; }

    [JsonPropertyName("activityName")]
    public string ActivityName { get; init; }

    [JsonPropertyName("startTimeLocal")]
    [JsonConverter(typeof(DateTimeConverter))]
    public DateTime StartTimeLocal { get; init; }

    [JsonPropertyName("startTimeGMT")]
    [JsonConverter(typeof(DateTimeConverter))]
    public DateTime StartTimeGmt { get; init; }

    [JsonPropertyName("activityType")]
    public ActivityType ActivityType { get; init; }

    [JsonPropertyName("eventType")]
    public EventType EventType { get; init; }

    [JsonPropertyName("distance")]
    public double Distance { get; init; }

    [JsonPropertyName("duration")]
    public double Duration { get; init; }

    [JsonPropertyName("elapsedDuration")]
    public double ElapsedDuration { get; init; }

    [JsonPropertyName("movingDuration")]
    public double MovingDuration { get; init; }

    [JsonPropertyName("elevationGain")]
    public double ElevationGain { get; init; }

    [JsonPropertyName("elevationLoss")]
    public double ElevationLoss { get; init; }

    [JsonPropertyName("averageSpeed")]
    public double AverageSpeed { get; init; }

    [JsonPropertyName("maxSpeed")]
    public double MaxSpeed { get; init; }

    [JsonPropertyName("startLatitude")]
    public double StartLatitude { get; init; }

    [JsonPropertyName("startLongitude")]
    public double StartLongitude { get; init; }

    [JsonPropertyName("hasPolyline")]
    public bool HasPolyline { get; init; }

    [JsonPropertyName("hasImages")]
    public bool HasImages { get; init; }

    [JsonPropertyName("ownerId")]
    public long OwnerId { get; init; }

    [JsonPropertyName("ownerDisplayName")]
    public string OwnerDisplayName { get; init; }

    [JsonPropertyName("ownerFullName")]
    public string OwnerFullName { get; init; }

    [JsonPropertyName("ownerProfileImageUrlSmall")]
    public Uri OwnerProfileImageUrlSmall { get; init; }

    [JsonPropertyName("ownerProfileImageUrlMedium")]
    public Uri OwnerProfileImageUrlMedium { get; init; }

    [JsonPropertyName("ownerProfileImageUrlLarge")]
    public Uri OwnerProfileImageUrlLarge { get; init; }

    [JsonPropertyName("calories")]
    public long Calories { get; init; }

    [JsonPropertyName("bmrCalories")]
    public long BmrCalories { get; init; }

    [JsonPropertyName("averageHR")]
    public long AverageHr { get; init; }

    [JsonPropertyName("maxHR")]
    public long MaxHr { get; init; }

    [JsonPropertyName("averageRunningCadenceInStepsPerMinute")]
    public double AverageRunningCadenceInStepsPerMinute { get; init; }

    [JsonPropertyName("maxRunningCadenceInStepsPerMinute")]
    public long MaxRunningCadenceInStepsPerMinute { get; init; }

    [JsonPropertyName("steps")]
    public long Steps { get; init; }

    [JsonPropertyName("userRoles")]
    public string[] UserRoles { get; init; }

    [JsonPropertyName("privacy")]
    public Privacy Privacy { get; init; }

    [JsonPropertyName("userPro")]
    public bool UserPro { get; init; }

    [JsonPropertyName("hasVideo")]
    public bool HasVideo { get; init; }

    [JsonPropertyName("timeZoneId")]
    public long TimeZoneId { get; init; }

    [JsonPropertyName("beginTimestamp")]
    public long BeginTimestamp { get; init; }

    [JsonPropertyName("sportTypeId")]
    public long SportTypeId { get; init; }

    [JsonPropertyName("aerobicTrainingEffect")]
    public double AerobicTrainingEffect { get; init; }

    [JsonPropertyName("anaerobicTrainingEffect")]
    public long AnaerobicTrainingEffect { get; init; }

    [JsonPropertyName("avgStrideLength")]
    public double AvgStrideLength { get; init; }

    [JsonPropertyName("vO2MaxValue")]
    public long VO2MaxValue { get; init; }

    [JsonPropertyName("deviceId")]
    public long DeviceId { get; init; }

    [JsonPropertyName("minTemperature")]
    public long MinTemperature { get; init; }

    [JsonPropertyName("maxTemperature")]
    public long MaxTemperature { get; init; }

    [JsonPropertyName("minElevation")]
    public double MinElevation { get; init; }

    [JsonPropertyName("maxElevation")]
    public double MaxElevation { get; init; }

    [JsonPropertyName("maxDoubleCadence")]
    public long MaxDoubleCadence { get; init; }

    [JsonPropertyName("summarizedDiveInfo")]
    public SummarizedDiveInfo SummarizedDiveInfo { get; init; }

    [JsonPropertyName("maxVerticalSpeed")]
    public double MaxVerticalSpeed { get; init; }

    [JsonPropertyName("manufacturer")]
    public string Manufacturer { get; init; }

    [JsonPropertyName("locationName")]
    public string LocationName { get; init; }

    [JsonPropertyName("lapCount")]
    public long LapCount { get; init; }

    [JsonPropertyName("endLatitude")]
    public double EndLatitude { get; init; }

    [JsonPropertyName("endLongitude")]
    public double EndLongitude { get; init; }

    [JsonPropertyName("waterEstimated")]
    public long WaterEstimated { get; init; }

    [JsonPropertyName("trainingEffectLabel")]
    public string TrainingEffectLabel { get; init; }

    [JsonPropertyName("activityTrainingLoad")]
    public double ActivityTrainingLoad { get; init; }

    [JsonPropertyName("minActivityLapDuration")]
    public double MinActivityLapDuration { get; init; }

    [JsonPropertyName("aerobicTrainingEffectMessage")]
    public string AerobicTrainingEffectMessage { get; init; }

    [JsonPropertyName("anaerobicTrainingEffectMessage")]
    public string AnaerobicTrainingEffectMessage { get; init; }

    [JsonPropertyName("splitSummaries")]
    public object[] SplitSummaries { get; init; }

    [JsonPropertyName("hasSplits")]
    public bool HasSplits { get; init; }

    [JsonPropertyName("moderateIntensityMinutes")]
    public long ModerateIntensityMinutes { get; init; }

    [JsonPropertyName("vigorousIntensityMinutes")]
    public long VigorousIntensityMinutes { get; init; }

    [JsonPropertyName("elevationCorrected")]
    public bool ElevationCorrected { get; init; }

    [JsonPropertyName("atpActivity")]
    public bool AtpActivity { get; init; }

    [JsonPropertyName("parent")]
    public bool Parent { get; init; }

    [JsonPropertyName("favorite")]
    public bool Favorite { get; init; }

    [JsonPropertyName("decoDive")]
    public bool DecoDive { get; init; }

    [JsonPropertyName("pr")]
    public bool Pr { get; init; }

    [JsonPropertyName("purposeful")]
    public bool Purposeful { get; init; }

    [JsonPropertyName("manualActivity")]
    public bool ManualActivity { get; init; }

    [JsonPropertyName("autoCalcCalories")]
    public bool AutoCalcCalories { get; init; }
}