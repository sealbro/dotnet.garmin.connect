using System;
using System.Text.Json.Serialization;
using Garmin.Connect.Converters;

namespace Garmin.Connect.Models;

public record GarminActivity
{
    [JsonPropertyName("activityId")]
    public long ActivityId { get; init; }

    [JsonPropertyName("activityName")]
    public string ActivityName { get; init; }

    [JsonPropertyName("description")]
    public string Description { get; init; }

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

    [JsonPropertyName("comments")]
    public string Comments { get; init; }

    [JsonPropertyName("parentId")]
    public string ParentId { get; init; }

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

    [JsonPropertyName("ownerId")]
    public long OwnerId { get; init; }

    [JsonPropertyName("ownerDisplayName")]
    public string OwnerDisplayName { get; init; }

    [JsonPropertyName("ownerFullName")]
    public string OwnerFullName { get; init; }

    [JsonPropertyName("ownerProfileImageUrlSmall")]
    public string OwnerProfileImageUrlSmall { get; init; }

    [JsonPropertyName("ownerProfileImageUrlMedium")]
    public string OwnerProfileImageUrlMedium { get; init; }

    [JsonPropertyName("ownerProfileImageUrlLarge")]
    public string OwnerProfileImageUrlLarge { get; init; }

    [JsonPropertyName("calories")]
    public double Calories { get; init; }

    [JsonPropertyName("averageHR")]
    public double AverageHr { get; init; }

    [JsonPropertyName("maxHR")]
    public double MaxHr { get; init; }

    [JsonPropertyName("averageRunningCadenceInStepsPerMinute")]
    public double AverageRunningCadenceInStepsPerMinute { get; init; }

    [JsonPropertyName("maxRunningCadenceInStepsPerMinute")]
    public double MaxRunningCadenceInStepsPerMinute { get; init; }

    [JsonPropertyName("averageBikingCadenceInRevPerMinute")]
    public double AverageBikingCadenceInRevPerMinute { get; init; }

    [JsonPropertyName("maxBikingCadenceInRevPerMinute")]
    public double MaxBikingCadenceInRevPerMinute { get; init; }

    [JsonPropertyName("averageSwimCadenceInStrokesPerMinute")]
    public double AverageSwimCadenceInStrokesPerMinute { get; init; }

    [JsonPropertyName("maxSwimCadenceInStrokesPerMinute")]
    public double MaxSwimCadenceInStrokesPerMinute { get; init; }

    [JsonPropertyName("averageSwolf")]
    public double AverageSwolf { get; init; }

    [JsonPropertyName("activeLengths")]
    public double ActiveLengths { get; init; }

    [JsonPropertyName("steps")]
    public int Steps { get; init; }

    [JsonPropertyName("conversationUuid")]
    public object ConversationUuid { get; init; }

    [JsonPropertyName("conversationPk")]
    public object ConversationPk { get; init; }

    [JsonPropertyName("numberOfActivityLikes")]
    public int NumberOfActivityLikes { get; init; }

    [JsonPropertyName("numberOfActivityComments")]
    public int NumberOfActivityComments { get; init; }

    [JsonPropertyName("likedByUser")]
    public int LikedByUser { get; init; }

    [JsonPropertyName("commentedByUser")]
    public object CommentedByUser { get; init; }

    [JsonPropertyName("activityLikeDisplayNames")]
    public object ActivityLikeDisplayNames { get; init; }

    [JsonPropertyName("activityLikeFullNames")]
    public object ActivityLikeFullNames { get; init; }

    [JsonPropertyName("activityLikeProfileImageUrls")]
    public object ActivityLikeProfileImageUrls { get; init; }

    [JsonPropertyName("requestorRelationship")]
    public object RequestorRelationship { get; init; }

    [JsonPropertyName("userRoles")]
    public string[] UserRoles { get; init; }

    [JsonPropertyName("privacy")]
    public Privacy Privacy { get; init; }

    [JsonPropertyName("userPro")]
    public bool UserPro { get; init; }

    [JsonPropertyName("courseId")]
    public object CourseId { get; init; }

    [JsonPropertyName("poolLength")]
    public object PoolLength { get; init; }

    [JsonPropertyName("unitOfPoolLength")]
    public object UnitOfPoolLength { get; init; }

    [JsonPropertyName("hasVideo")]
    public bool HasVideo { get; init; }

    [JsonPropertyName("videoUrl")]
    public string VideoUrl { get; init; }

    [JsonPropertyName("timeZoneId")]
    public long TimeZoneId { get; init; }

    [JsonPropertyName("beginTimestamp")]
    public long BeginTimestamp { get; init; }

    [JsonPropertyName("sportTypeId")]
    public long SportTypeId { get; init; }

    [JsonPropertyName("avgPower")]
    public double AvgPower { get; init; }

    [JsonPropertyName("maxPower")]
    public double MaxPower { get; init; }

    [JsonPropertyName("aerobicTrainingEffect")]
    public double AerobicTrainingEffect { get; init; }

    [JsonPropertyName("anaerobicTrainingEffect")]
    public double AnaerobicTrainingEffect { get; init; }

    [JsonPropertyName("strokes")]
    public double Strokes { get; init; }

    [JsonPropertyName("normPower")]
    public double NormPower { get; init; }

    [JsonPropertyName("leftBalance")]
    public double LeftBalance { get; init; }

    [JsonPropertyName("rightBalance")]
    public double RightBalance { get; init; }

    [JsonPropertyName("avgLeftBalance")]
    public double AvgLeftBalance { get; init; }

    [JsonPropertyName("max20MinPower")]
    public double Max20MinPower { get; init; }

    [JsonPropertyName("avgVerticalOscillation")]
    public double AvgVerticalOscillation { get; init; }

    [JsonPropertyName("avgGroundContactTime")]
    public double AvgGroundContactTime { get; init; }

    [JsonPropertyName("avgStrideLength")]
    public double AvgStrideLength { get; init; }

    [JsonPropertyName("avgFractionalCadence")]
    public double AvgFractionalCadence { get; init; }

    [JsonPropertyName("maxFractionalCadence")]
    public double MaxFractionalCadence { get; init; }

    [JsonPropertyName("trainingStressScore")]
    public double TrainingStressScore { get; init; }

    [JsonPropertyName("intensityFactor")]
    public double IntensityFactor { get; init; }

    [JsonPropertyName("vO2MaxValue")]
    public double VO2MaxValue { get; init; }

    [JsonPropertyName("avgVerticalRatio")]
    public double AvgVerticalRatio { get; init; }

    [JsonPropertyName("avgGroundContactBalance")]
    public double AvgGroundContactBalance { get; init; }

    [JsonPropertyName("lactateThresholdBpm")]
    public double LactateThresholdBpm { get; init; }

    [JsonPropertyName("lactateThresholdSpeed")]
    public double LactateThresholdSpeed { get; init; }

    [JsonPropertyName("maxFtp")]
    public double MaxFtp { get; init; }

    [JsonPropertyName("avgStrokeDistance")]
    public double AvgStrokeDistance { get; init; }

    [JsonPropertyName("avgStrokeCadence")]
    public double AvgStrokeCadence { get; init; }

    [JsonPropertyName("maxStrokeCadence")]
    public double MaxStrokeCadence { get; init; }

    [JsonPropertyName("workoutId")]
    public double WorkoutId { get; init; }

    [JsonPropertyName("avgStrokes")]
    public double AvgStrokes { get; init; }

    [JsonPropertyName("minStrokes")]
    public double MinStrokes { get; init; }

    [JsonPropertyName("deviceId")]
    public long DeviceId { get; init; }

    [JsonPropertyName("minTemperature")]
    public double MinTemperature { get; init; }

    [JsonPropertyName("maxTemperature")]
    public double MaxTemperature { get; init; }

    [JsonPropertyName("minElevation")]
    public double MinElevation { get; init; }

    [JsonPropertyName("maxElevation")]
    public double MaxElevation { get; init; }

    [JsonPropertyName("avgDoubleCadence")]
    public double AvgDoubleCadence { get; init; }

    [JsonPropertyName("maxDoubleCadence")]
    public double MaxDoubleCadence { get; init; }

    [JsonPropertyName("summarizedExerciseSets")]
    public object SummarizedExerciseSets { get; init; }

    [JsonPropertyName("maxDepth")]
    public double MaxDepth { get; init; }

    [JsonPropertyName("avgDepth")]
    public double AvgDepth { get; init; }

    [JsonPropertyName("surfaceInterval")]
    public object SurfaceInterval { get; init; }

    [JsonPropertyName("startN2")]
    public object StartN2 { get; init; }

    [JsonPropertyName("endN2")]
    public object EndN2 { get; init; }

    [JsonPropertyName("startCns")]
    public object StartCns { get; init; }

    [JsonPropertyName("endCns")]
    public object EndCns { get; init; }

    [JsonPropertyName("summarizedDiveInfo")]
    public SummarizedDiveInfo SummarizedDiveInfo { get; init; }

    [JsonPropertyName("activityLikeAuthors")]
    public object ActivityLikeAuthors { get; init; }

    [JsonPropertyName("avgVerticalSpeed")]
    public double AvgVerticalSpeed { get; init; }

    [JsonPropertyName("maxVerticalSpeed")]
    public double MaxVerticalSpeed { get; init; }

    [JsonPropertyName("floorsClimbed")]
    public object FloorsClimbed { get; init; }

    [JsonPropertyName("floorsDescended")]
    public object FloorsDescended { get; init; }

    [JsonPropertyName("manufacturer")]
    public string Manufacturer { get; init; }

    [JsonPropertyName("diveNumber")]
    public object DiveNumber { get; init; }

    [JsonPropertyName("locationName")]
    public string LocationName { get; init; }

    [JsonPropertyName("bottomTime")]
    public object BottomTime { get; init; }

    [JsonPropertyName("lapCount")]
    public long LapCount { get; init; }

    [JsonPropertyName("endLatitude")]
    public double EndLatitude { get; init; }

    [JsonPropertyName("endLongitude")]
    public double EndLongitude { get; init; }

    [JsonPropertyName("minAirSpeed")]
    public double MinAirSpeed { get; init; }

    [JsonPropertyName("maxAirSpeed")]
    public double MaxAirSpeed { get; init; }

    [JsonPropertyName("avgAirSpeed")]
    public double AvgAirSpeed { get; init; }

    [JsonPropertyName("avgWindYawAngle")]
    public double AvgWindYawAngle { get; init; }

    [JsonPropertyName("minCda")]
    public double MinCda { get; init; }

    [JsonPropertyName("maxCda")]
    public double MaxCda { get; init; }

    [JsonPropertyName("avgCda")]
    public double AvgCda { get; init; }

    [JsonPropertyName("avgWattsPerCda")]
    public double AvgWattsPerCda { get; init; }

    [JsonPropertyName("flow")]
    public object Flow { get; init; }

    [JsonPropertyName("grit")]
    public object Grit { get; init; }

    [JsonPropertyName("jumpCount")]
    public object JumpCount { get; init; }

    [JsonPropertyName("caloriesEstimated")]
    public object CaloriesEstimated { get; init; }

    [JsonPropertyName("caloriesConsumed")]
    public object CaloriesConsumed { get; init; }

    [JsonPropertyName("waterEstimated")]
    public object WaterEstimated { get; init; }

    [JsonPropertyName("waterConsumed")]
    public object WaterConsumed { get; init; }

    [JsonPropertyName("maxAvgPower_1")]
    public double MaxAvgPower1 { get; init; }

    [JsonPropertyName("maxAvgPower_2")]
    public double MaxAvgPower2 { get; init; }

    [JsonPropertyName("maxAvgPower_5")]
    public double MaxAvgPower5 { get; init; }

    [JsonPropertyName("maxAvgPower_10")]
    public double MaxAvgPower10 { get; init; }

    [JsonPropertyName("maxAvgPower_20")]
    public double MaxAvgPower20 { get; init; }

    [JsonPropertyName("maxAvgPower_30")]
    public double MaxAvgPower30 { get; init; }

    [JsonPropertyName("maxAvgPower_60")]
    public double MaxAvgPower60 { get; init; }

    [JsonPropertyName("maxAvgPower_120")]
    public double MaxAvgPower120 { get; init; }

    [JsonPropertyName("maxAvgPower_300")]
    public double MaxAvgPower300 { get; init; }

    [JsonPropertyName("maxAvgPower_600")]
    public double MaxAvgPower600 { get; init; }

    [JsonPropertyName("maxAvgPower_1200")]
    public double MaxAvgPower1200 { get; init; }

    [JsonPropertyName("maxAvgPower_1800")]
    public double MaxAvgPower1800 { get; init; }

    [JsonPropertyName("maxAvgPower_3600")]
    public double MaxAvgPower3600 { get; init; }

    [JsonPropertyName("maxAvgPower_7200")]
    public double MaxAvgPower7200 { get; init; }

    [JsonPropertyName("maxAvgPower_18000")]
    public double MaxAvgPower18000 { get; init; }

    [JsonPropertyName("excludeFromPowerCurveReports")]
    public bool ExcludeFromPowerCurveReports { get; init; }

    [JsonPropertyName("totalSets")]
    public double TotalSets { get; init; }

    [JsonPropertyName("activeSets")]
    public double ActiveSets { get; init; }

    [JsonPropertyName("totalReps")]
    public double TotalReps { get; init; }

    [JsonPropertyName("minRespirationRate")]
    public double MinRespirationRate { get; init; }

    [JsonPropertyName("maxRespirationRate")]
    public double MaxRespirationRate { get; init; }

    [JsonPropertyName("avgRespirationRate")]
    public double AvgRespirationRate { get; init; }

    [JsonPropertyName("trainingEffectLabel")]
    public object TrainingEffectLabel { get; init; }

    [JsonPropertyName("activityTrainingLoad")]
    public double ActivityTrainingLoad { get; init; }

    [JsonPropertyName("avgFlow")]
    public double AvgFlow { get; init; }

    [JsonPropertyName("avgGrit")]
    public double AvgGrit { get; init; }

    [JsonPropertyName("minActivityLapDuration")]
    public double MinActivityLapDuration { get; init; }

    [JsonPropertyName("avgStress")]
    public double AvgStress { get; init; }

    [JsonPropertyName("startStress")]
    public double StartStress { get; init; }

    [JsonPropertyName("endStress")]
    public double EndStress { get; init; }

    [JsonPropertyName("differenceStress")]
    public object DifferenceStress { get; init; }

    [JsonPropertyName("maxStress")]
    public double MaxStress { get; init; }

    [JsonPropertyName("aerobicTrainingEffectMessage")]
    public object AerobicTrainingEffectMessage { get; init; }

    [JsonPropertyName("anaerobicTrainingEffectMessage")]
    public object AnaerobicTrainingEffectMessage { get; init; }

    [JsonPropertyName("splitSummaries")]
    public SplitSummary[] SplitSummaries { get; init; }

    [JsonPropertyName("hasSplits")]
    public bool HasSplits { get; init; }

    [JsonPropertyName("moderateIntensityMinutes")]
    public long ModerateIntensityMinutes { get; init; }

    [JsonPropertyName("vigorousIntensityMinutes")]
    public long VigorousIntensityMinutes { get; init; }

    [JsonPropertyName("maxBottomTime")]
    public object MaxBottomTime { get; init; }

    [JsonPropertyName("hasSeedFirstbeatProfile")]
    public object HasSeedFirstbeatProfile { get; init; }

    [JsonPropertyName("purposeful")]
    public bool Purposeful { get; init; }

    [JsonPropertyName("favorite")]
    public bool Favorite { get; init; }

    [JsonPropertyName("pr")]
    public bool Pr { get; init; }

    [JsonPropertyName("autoCalcCalories")]
    public bool AutoCalcCalories { get; init; }

    [JsonPropertyName("atpActivity")]
    public bool AtpActivity { get; init; }

    [JsonPropertyName("manualActivity")]
    public bool ManualActivity { get; init; }

    [JsonPropertyName("elevationCorrected")]
    public bool ElevationCorrected { get; init; }

    [JsonPropertyName("decoDive")]
    public bool DecoDive { get; init; }

    [JsonPropertyName("parent")]
    public bool Parent { get; init; }
}

public record ActivityType
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

    [JsonPropertyName("trimmable")]
    public bool Trimmable { get; init; }

    [JsonPropertyName("restricted")]
    public bool Restricted { get; init; }
}

public record EventType
{
    [JsonPropertyName("typeId")]
    public long TypeId { get; init; }

    [JsonPropertyName("typeKey")]
    public string TypeKey { get; init; }

    [JsonPropertyName("sortOrder")]
    public long SortOrder { get; init; }
}

public record Privacy
{
    [JsonPropertyName("typeId")]
    public long TypeId { get; init; }

    [JsonPropertyName("typeKey")]
    public string TypeKey { get; init; }
}

public record SplitSummary
{
    [JsonPropertyName("noOfSplits")]
    public object NoOfSplits { get; init; }

    [JsonPropertyName("maxGradeValue")]
    public object MaxGradeValue { get; init; }

    [JsonPropertyName("totalAscent")]
    public double TotalAscent { get; init; }

    [JsonPropertyName("duration")]
    public double Duration { get; init; }

    [JsonPropertyName("splitType")]
    public string SplitType { get; init; }

    [JsonPropertyName("numClimbSends")]
    public double NumClimbSends { get; init; }

    [JsonPropertyName("maxElevationGain")]
    public double MaxElevationGain { get; init; }

    [JsonPropertyName("averageElevationGain")]
    public double AverageElevationGain { get; init; }

    [JsonPropertyName("maxDistance")]
    public double MaxDistance { get; init; }

    [JsonPropertyName("distance")]
    public double Distance { get; init; }

    [JsonPropertyName("averageSpeed")]
    public double AverageSpeed { get; init; }

    [JsonPropertyName("maxSpeed")]
    public double MaxSpeed { get; init; }

    [JsonPropertyName("mode")]
    public object Mode { get; init; }

    [JsonPropertyName("numFalls")]
    public long NumFalls { get; init; }
}

public record SummarizedDiveInfo
{
    [JsonPropertyName("weight")]
    public double Weight { get; init; }

    [JsonPropertyName("weightUnit")]
    public object WeightUnit { get; init; }

    [JsonPropertyName("visibility")]
    public object Visibility { get; init; }

    [JsonPropertyName("visibilityUnit")]
    public object VisibilityUnit { get; init; }

    [JsonPropertyName("surfaceCondition")]
    public object SurfaceCondition { get; init; }

    [JsonPropertyName("current")]
    public object Current { get; init; }

    [JsonPropertyName("waterType")]
    public object WaterType { get; init; }

    [JsonPropertyName("waterDensity")]
    public object WaterDensity { get; init; }

    [JsonPropertyName("summarizedDiveGases")]
    public object[] SummarizedDiveGases { get; init; }

    [JsonPropertyName("totalSurfaceTime")]
    public object TotalSurfaceTime { get; init; }
}