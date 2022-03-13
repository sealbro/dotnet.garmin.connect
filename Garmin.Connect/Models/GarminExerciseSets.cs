using System;
using System.Text.Json.Serialization;

namespace Garmin.Connect.Models;

public record GarminExerciseSets
{
    [JsonPropertyName("activityId")]
    public long ActivityId { get; init; }

    [JsonPropertyName("activityUUID")]
    public GarminActivityUuid ActivityUuid { get; init; }

    [JsonPropertyName("activityName")]
    public string ActivityName { get; init; }

    [JsonPropertyName("userProfileId")]
    public long UserProfileId { get; init; }

    [JsonPropertyName("isMultiSportParent")]
    public bool IsMultiSportParent { get; init; }

    [JsonPropertyName("activityTypeDTO")]
    public ActivityTypeDto ActivityTypeDto { get; init; }

    [JsonPropertyName("eventTypeDTO")]
    public EventTypeDto EventTypeDto { get; init; }

    [JsonPropertyName("accessControlRuleDTO")]
    public AccessControlRuleDto AccessControlRuleDto { get; init; }

    [JsonPropertyName("timeZoneUnitDTO")]
    public TimeZoneUnitDto TimeZoneUnitDto { get; init; }

    [JsonPropertyName("metadataDTO")]
    public MetadataDto MetadataDto { get; init; }

    [JsonPropertyName("summaryDTO")]
    public SummaryDto SummaryDto { get; init; }

    [JsonPropertyName("connectIQMeasurements")]
    public GarminConnectIqMeasurement[] ConnectIqMeasurements { get; init; }

    [JsonPropertyName("locationName")]
    public string LocationName { get; init; }
}

public record AccessControlRuleDto
{
    [JsonPropertyName("typeId")]
    public long TypeId { get; init; }

    [JsonPropertyName("typeKey")]
    public string TypeKey { get; init; }
}

public record ActivityTypeDto
{
    [JsonPropertyName("typeId")]
    public long TypeId { get; init; }

    [JsonPropertyName("typeKey")]
    public string TypeKey { get; init; }

    [JsonPropertyName("parentTypeId")]
    public long ParentTypeId { get; init; }

    [JsonPropertyName("isHidden")]
    public bool IsHidden { get; init; }

    [JsonPropertyName("sortOrder")]
    public object SortOrder { get; init; }

    [JsonPropertyName("restricted")]
    public bool Restricted { get; init; }

    [JsonPropertyName("trimmable")]
    public bool Trimmable { get; init; }
}

public record EventTypeDto
{
    [JsonPropertyName("typeId")]
    public long TypeId { get; init; }

    [JsonPropertyName("typeKey")]
    public string TypeKey { get; init; }

    [JsonPropertyName("sortOrder")]
    public long SortOrder { get; init; }
}

public record MetadataDto
{
    [JsonPropertyName("isOriginal")]
    public bool IsOriginal { get; init; }

    [JsonPropertyName("deviceApplicationInstallationId")]
    public long DeviceApplicationInstallationId { get; init; }

    [JsonPropertyName("agentApplicationInstallationId")]
    public string AgentApplicationInstallationId { get; init; }

    [JsonPropertyName("agentString")]
    public string AgentString { get; init; }

    [JsonPropertyName("fileFormat")]
    public FileFormat FileFormat { get; init; }

    [JsonPropertyName("associatedCourseId")]
    public string AssociatedCourseId { get; init; }

    [JsonPropertyName("lastUpdateDate")]
    public DateTime LastUpdateDate { get; init; }

    [JsonPropertyName("uploadedDate")]
    public DateTime UploadedDate { get; init; }

    [JsonPropertyName("videoUrl")]
    public string VideoUrl { get; init; }

    [JsonPropertyName("hasPolyline")]
    public bool HasPolyline { get; init; }

    [JsonPropertyName("hasChartData")]
    public bool HasChartData { get; init; }

    [JsonPropertyName("hasHrTimeInZones")]
    public bool HasHrTimeInZones { get; init; }

    [JsonPropertyName("hasPowerTimeInZones")]
    public bool HasPowerTimeInZones { get; init; }

    [JsonPropertyName("userInfoDto")]
    public UserInfoDto UserInfoDto { get; init; }

    [JsonPropertyName("childIds")]
    public object[] ChildIds { get; init; }

    [JsonPropertyName("childActivityTypes")]
    public object[] ChildActivityTypes { get; init; }

    [JsonPropertyName("sensors")]
    public Sensor[] Sensors { get; init; }

    [JsonPropertyName("activityImages")]
    public string[] ActivityImages { get; init; }

    [JsonPropertyName("manufacturer")]
    public string Manufacturer { get; init; }

    [JsonPropertyName("diveNumber")]
    public object DiveNumber { get; init; }

    [JsonPropertyName("lapCount")]
    public long LapCount { get; init; }

    [JsonPropertyName("associatedWorkoutId")]
    public object AssociatedWorkoutId { get; init; }

    [JsonPropertyName("isAtpActivity")]
    public object IsAtpActivity { get; init; }

    [JsonPropertyName("deviceMetaDataDTO")]
    public DeviceMetaDataDto DeviceMetaDataDto { get; init; }

    [JsonPropertyName("hasIntensityIntervals")]
    public bool HasIntensityIntervals { get; init; }

    [JsonPropertyName("hasSplits")]
    public bool HasSplits { get; init; }

    [JsonPropertyName("eBikeMaxAssistModes")]
    public object EBikeMaxAssistModes { get; init; }

    [JsonPropertyName("eBikeBatteryUsage")]
    public object EBikeBatteryUsage { get; init; }

    [JsonPropertyName("eBikeBatteryRemaining")]
    public object EBikeBatteryRemaining { get; init; }

    [JsonPropertyName("eBikeAssistModeInfoDTOList")]
    public object EBikeAssistModeInfoDtoList { get; init; }

    [JsonPropertyName("calendarEventInfo")]
    public object CalendarEventInfo { get; init; }

    [JsonPropertyName("manualActivity")]
    public bool ManualActivity { get; init; }

    [JsonPropertyName("autoCalcCalories")]
    public bool AutoCalcCalories { get; init; }

    [JsonPropertyName("personalRecord")]
    public bool PersonalRecord { get; init; }

    [JsonPropertyName("gcj02")]
    public bool Gcj02 { get; init; }

    [JsonPropertyName("favorite")]
    public bool Favorite { get; init; }

    [JsonPropertyName("trimmed")]
    public bool Trimmed { get; init; }

    [JsonPropertyName("elevationCorrected")]
    public bool ElevationCorrected { get; init; }
}

public record DeviceMetaDataDto
{
    [JsonPropertyName("deviceId")]
    public string DeviceId { get; init; }

    [JsonPropertyName("deviceTypePk")]
    public long DeviceTypePk { get; init; }

    [JsonPropertyName("deviceVersionPk")]
    public long DeviceVersionPk { get; init; }
}

public record FileFormat
{
    [JsonPropertyName("formatId")]
    public long FormatId { get; init; }

    [JsonPropertyName("formatKey")]
    public string FormatKey { get; init; }
}

public record Sensor
{
    [JsonPropertyName("manufacturer")]
    public string Manufacturer { get; init; }

    [JsonPropertyName("serialNumber")]
    public long SerialNumber { get; init; }

    [JsonPropertyName("sku")]
    public string Sku { get; init; }

    [JsonPropertyName("sourceType")]
    public string SourceType { get; init; }

    [JsonPropertyName("antplusDeviceType")]
    public string AntplusDeviceType { get; init; }

    [JsonPropertyName("softwareVersion")]
    public double SoftwareVersion { get; init; }

    [JsonPropertyName("batteryStatus")]
    public string BatteryStatus { get; init; }
}

public record UserInfoDto
{
    [JsonPropertyName("userProfilePk")]
    public long UserProfilePk { get; init; }

    [JsonPropertyName("displayname")]
    public string Displayname { get; init; }

    [JsonPropertyName("fullname")]
    public string Fullname { get; init; }

    [JsonPropertyName("profileImageUrlLarge")]
    public string ProfileImageUrlLarge { get; init; }

    [JsonPropertyName("profileImageUrlMedium")]
    public string ProfileImageUrlMedium { get; init; }

    [JsonPropertyName("profileImageUrlSmall")]
    public string ProfileImageUrlSmall { get; init; }

    [JsonPropertyName("userPro")]
    public bool UserPro { get; init; }
}

public record SummaryDto
{
    [JsonPropertyName("startTimeLocal")]
    public DateTime StartTimeLocal { get; init; }

    [JsonPropertyName("startTimeGMT")]
    public DateTime StartTimeGmt { get; init; }

    [JsonPropertyName("startLatitude")]
    public double StartLatitude { get; init; }

    [JsonPropertyName("startLongitude")]
    public double StartLongitude { get; init; }

    [JsonPropertyName("distance")]
    public double Distance { get; init; }

    [JsonPropertyName("duration")]
    public double Duration { get; init; }

    [JsonPropertyName("movingDuration")]
    public double MovingDuration { get; init; }

    [JsonPropertyName("elapsedDuration")]
    public double ElapsedDuration { get; init; }

    [JsonPropertyName("elevationGain")]
    public double ElevationGain { get; init; }

    [JsonPropertyName("elevationLoss")]
    public double ElevationLoss { get; init; }

    [JsonPropertyName("maxElevation")]
    public double MaxElevation { get; init; }

    [JsonPropertyName("minElevation")]
    public double MinElevation { get; init; }

    [JsonPropertyName("averageSpeed")]
    public double AverageSpeed { get; init; }

    [JsonPropertyName("averageMovingSpeed")]
    public double AverageMovingSpeed { get; init; }

    [JsonPropertyName("maxSpeed")]
    public double MaxSpeed { get; init; }

    [JsonPropertyName("calories")]
    public double Calories { get; init; }

    [JsonPropertyName("averageHR")]
    public double AverageHr { get; init; }

    [JsonPropertyName("maxHR")]
    public double MaxHr { get; init; }

    [JsonPropertyName("averageRunCadence")]
    public double AverageRunCadence { get; init; }

    [JsonPropertyName("maxRunCadence")]
    public double MaxRunCadence { get; init; }

    [JsonPropertyName("averageTemperature")]
    public double AverageTemperature { get; init; }

    [JsonPropertyName("maxTemperature")]
    public double MaxTemperature { get; init; }

    [JsonPropertyName("minTemperature")]
    public double MinTemperature { get; init; }

    [JsonPropertyName("groundContactTime")]
    public double GroundContactTime { get; init; }

    [JsonPropertyName("groundContactBalanceLeft")]
    public double GroundContactBalanceLeft { get; init; }

    [JsonPropertyName("strideLength")]
    public double StrideLength { get; init; }

    [JsonPropertyName("verticalOscillation")]
    public double VerticalOscillation { get; init; }

    [JsonPropertyName("trainingEffect")]
    public double TrainingEffect { get; init; }

    [JsonPropertyName("anaerobicTrainingEffect")]
    public double AnaerobicTrainingEffect { get; init; }

    [JsonPropertyName("aerobicTrainingEffectMessage")]
    public string AerobicTrainingEffectMessage { get; init; }

    [JsonPropertyName("anaerobicTrainingEffectMessage")]
    public string AnaerobicTrainingEffectMessage { get; init; }

    [JsonPropertyName("verticalRatio")]
    public double VerticalRatio { get; init; }

    [JsonPropertyName("endLatitude")]
    public double EndLatitude { get; init; }

    [JsonPropertyName("endLongitude")]
    public double EndLongitude { get; init; }

    [JsonPropertyName("maxVerticalSpeed")]
    public double MaxVerticalSpeed { get; init; }

    [JsonPropertyName("waterEstimated")]
    public double WaterEstimated { get; init; }

    [JsonPropertyName("minRespirationRate")]
    public double MinRespirationRate { get; init; }

    [JsonPropertyName("maxRespirationRate")]
    public double MaxRespirationRate { get; init; }

    [JsonPropertyName("avgRespirationRate")]
    public double AvgRespirationRate { get; init; }

    [JsonPropertyName("trainingEffectLabel")]
    public string TrainingEffectLabel { get; init; }

    [JsonPropertyName("activityTrainingLoad")]
    public double ActivityTrainingLoad { get; init; }

    [JsonPropertyName("minActivityLapDuration")]
    public double MinActivityLapDuration { get; init; }

    [JsonPropertyName("moderateIntensityMinutes")]
    public long ModerateIntensityMinutes { get; init; }

    [JsonPropertyName("vigorousIntensityMinutes")]
    public long VigorousIntensityMinutes { get; init; }
}

public record TimeZoneUnitDto
{
    [JsonPropertyName("unitId")]
    public long UnitId { get; init; }

    [JsonPropertyName("unitKey")]
    public string UnitKey { get; init; }

    [JsonPropertyName("factor")]
    public double Factor { get; init; }

    [JsonPropertyName("timeZone")]
    public string TimeZone { get; init; }
}