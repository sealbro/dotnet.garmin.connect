using System;
using System.Text.Json.Serialization;
using Garmin.Connect.Converters;

namespace Garmin.Connect.Models
{
    public class GarminActivity
    {
        [JsonPropertyName("activityId")]
        public long ActivityId { get; set; }

        [JsonPropertyName("activityName")]
        public string ActivityName { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("startTimeLocal")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime StartTimeLocal { get; set; }

        [JsonPropertyName("startTimeGMT")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime StartTimeGmt { get; set; }

        [JsonPropertyName("activityType")]
        public ActivityType ActivityType { get; set; }

        [JsonPropertyName("eventType")]
        public EventType EventType { get; set; }

        [JsonPropertyName("comments")]
        public string Comments { get; set; }

        [JsonPropertyName("parentId")]
        public string ParentId { get; set; }

        [JsonPropertyName("distance")]
        public double Distance { get; set; }

        [JsonPropertyName("duration")]
        public double Duration { get; set; }

        [JsonPropertyName("elapsedDuration")]
        public double ElapsedDuration { get; set; }

        [JsonPropertyName("movingDuration")]
        public double MovingDuration { get; set; }

        [JsonPropertyName("elevationGain")]
        public double ElevationGain { get; set; }

        [JsonPropertyName("elevationLoss")]
        public double ElevationLoss { get; set; }

        [JsonPropertyName("averageSpeed")]
        public double AverageSpeed { get; set; }

        [JsonPropertyName("maxSpeed")]
        public double MaxSpeed { get; set; }

        [JsonPropertyName("startLatitude")]
        public double StartLatitude { get; set; }

        [JsonPropertyName("startLongitude")]
        public double StartLongitude { get; set; }

        [JsonPropertyName("hasPolyline")]
        public bool HasPolyline { get; set; }

        [JsonPropertyName("ownerId")]
        public long OwnerId { get; set; }

        [JsonPropertyName("ownerDisplayName")]
        public string OwnerDisplayName { get; set; }

        [JsonPropertyName("ownerFullName")]
        public string OwnerFullName { get; set; }

        [JsonPropertyName("ownerProfileImageUrlSmall")]
        public string OwnerProfileImageUrlSmall { get; set; }

        [JsonPropertyName("ownerProfileImageUrlMedium")]
        public string OwnerProfileImageUrlMedium { get; set; }

        [JsonPropertyName("ownerProfileImageUrlLarge")]
        public string OwnerProfileImageUrlLarge { get; set; }

        [JsonPropertyName("calories")]
        public double Calories { get; set; }

        [JsonPropertyName("averageHR")]
        public double AverageHr { get; set; }

        [JsonPropertyName("maxHR")]
        public double MaxHr { get; set; }

        [JsonPropertyName("averageRunningCadenceInStepsPerMinute")]
        public double AverageRunningCadenceInStepsPerMinute { get; set; }

        [JsonPropertyName("maxRunningCadenceInStepsPerMinute")]
        public double MaxRunningCadenceInStepsPerMinute { get; set; }

        [JsonPropertyName("averageBikingCadenceInRevPerMinute")]
        public double AverageBikingCadenceInRevPerMinute { get; set; }

        [JsonPropertyName("maxBikingCadenceInRevPerMinute")]
        public double MaxBikingCadenceInRevPerMinute { get; set; }

        [JsonPropertyName("averageSwimCadenceInStrokesPerMinute")]
        public double AverageSwimCadenceInStrokesPerMinute { get; set; }

        [JsonPropertyName("maxSwimCadenceInStrokesPerMinute")]
        public double MaxSwimCadenceInStrokesPerMinute { get; set; }

        [JsonPropertyName("averageSwolf")]
        public double AverageSwolf { get; set; }

        [JsonPropertyName("activeLengths")]
        public double ActiveLengths { get; set; }

        [JsonPropertyName("steps")]
        public int Steps { get; set; }

        [JsonPropertyName("conversationUuid")]
        public object ConversationUuid { get; set; }

        [JsonPropertyName("conversationPk")]
        public object ConversationPk { get; set; }

        [JsonPropertyName("numberOfActivityLikes")]
        public int NumberOfActivityLikes { get; set; }

        [JsonPropertyName("numberOfActivityComments")]
        public int NumberOfActivityComments { get; set; }

        [JsonPropertyName("likedByUser")]
        public int LikedByUser { get; set; }

        [JsonPropertyName("commentedByUser")]
        public object CommentedByUser { get; set; }

        [JsonPropertyName("activityLikeDisplayNames")]
        public object ActivityLikeDisplayNames { get; set; }

        [JsonPropertyName("activityLikeFullNames")]
        public object ActivityLikeFullNames { get; set; }

        [JsonPropertyName("activityLikeProfileImageUrls")]
        public object ActivityLikeProfileImageUrls { get; set; }

        [JsonPropertyName("requestorRelationship")]
        public object RequestorRelationship { get; set; }

        [JsonPropertyName("userRoles")]
        public string[] UserRoles { get; set; }

        [JsonPropertyName("privacy")]
        public Privacy Privacy { get; set; }

        [JsonPropertyName("userPro")]
        public bool UserPro { get; set; }

        [JsonPropertyName("courseId")]
        public object CourseId { get; set; }

        [JsonPropertyName("poolLength")]
        public object PoolLength { get; set; }

        [JsonPropertyName("unitOfPoolLength")]
        public object UnitOfPoolLength { get; set; }

        [JsonPropertyName("hasVideo")]
        public bool HasVideo { get; set; }

        [JsonPropertyName("videoUrl")]
        public string VideoUrl { get; set; }

        [JsonPropertyName("timeZoneId")]
        public long TimeZoneId { get; set; }

        [JsonPropertyName("beginTimestamp")]
        public long BeginTimestamp { get; set; }

        [JsonPropertyName("sportTypeId")]
        public long SportTypeId { get; set; }

        [JsonPropertyName("avgPower")]
        public double AvgPower { get; set; }

        [JsonPropertyName("maxPower")]
        public double MaxPower { get; set; }

        [JsonPropertyName("aerobicTrainingEffect")]
        public double AerobicTrainingEffect { get; set; }

        [JsonPropertyName("anaerobicTrainingEffect")]
        public double AnaerobicTrainingEffect { get; set; }

        [JsonPropertyName("strokes")]
        public double Strokes { get; set; }

        [JsonPropertyName("normPower")]
        public double NormPower { get; set; }

        [JsonPropertyName("leftBalance")]
        public double LeftBalance { get; set; }

        [JsonPropertyName("rightBalance")]
        public double RightBalance { get; set; }

        [JsonPropertyName("avgLeftBalance")]
        public double AvgLeftBalance { get; set; }

        [JsonPropertyName("max20MinPower")]
        public double Max20MinPower { get; set; }

        [JsonPropertyName("avgVerticalOscillation")]
        public double AvgVerticalOscillation { get; set; }

        [JsonPropertyName("avgGroundContactTime")]
        public double AvgGroundContactTime { get; set; }

        [JsonPropertyName("avgStrideLength")]
        public double AvgStrideLength { get; set; }

        [JsonPropertyName("avgFractionalCadence")]
        public double AvgFractionalCadence { get; set; }

        [JsonPropertyName("maxFractionalCadence")]
        public double MaxFractionalCadence { get; set; }

        [JsonPropertyName("trainingStressScore")]
        public double TrainingStressScore { get; set; }

        [JsonPropertyName("intensityFactor")]
        public double IntensityFactor { get; set; }

        [JsonPropertyName("vO2MaxValue")]
        public double VO2MaxValue { get; set; }

        [JsonPropertyName("avgVerticalRatio")]
        public double AvgVerticalRatio { get; set; }

        [JsonPropertyName("avgGroundContactBalance")]
        public double AvgGroundContactBalance { get; set; }

        [JsonPropertyName("lactateThresholdBpm")]
        public double LactateThresholdBpm { get; set; }

        [JsonPropertyName("lactateThresholdSpeed")]
        public double LactateThresholdSpeed { get; set; }

        [JsonPropertyName("maxFtp")]
        public double MaxFtp { get; set; }

        [JsonPropertyName("avgStrokeDistance")]
        public double AvgStrokeDistance { get; set; }

        [JsonPropertyName("avgStrokeCadence")]
        public double AvgStrokeCadence { get; set; }

        [JsonPropertyName("maxStrokeCadence")]
        public double MaxStrokeCadence { get; set; }

        [JsonPropertyName("workoutId")]
        public double WorkoutId { get; set; }

        [JsonPropertyName("avgStrokes")]
        public double AvgStrokes { get; set; }

        [JsonPropertyName("minStrokes")]
        public double MinStrokes { get; set; }

        [JsonPropertyName("deviceId")]
        public long DeviceId { get; set; }

        [JsonPropertyName("minTemperature")]
        public double MinTemperature { get; set; }

        [JsonPropertyName("maxTemperature")]
        public double MaxTemperature { get; set; }

        [JsonPropertyName("minElevation")]
        public double MinElevation { get; set; }

        [JsonPropertyName("maxElevation")]
        public double MaxElevation { get; set; }

        [JsonPropertyName("avgDoubleCadence")]
        public double AvgDoubleCadence { get; set; }

        [JsonPropertyName("maxDoubleCadence")]
        public double MaxDoubleCadence { get; set; }

        [JsonPropertyName("summarizedExerciseSets")]
        public object SummarizedExerciseSets { get; set; }

        [JsonPropertyName("maxDepth")]
        public double MaxDepth { get; set; }

        [JsonPropertyName("avgDepth")]
        public double AvgDepth { get; set; }

        [JsonPropertyName("surfaceInterval")]
        public object SurfaceInterval { get; set; }

        [JsonPropertyName("startN2")]
        public object StartN2 { get; set; }

        [JsonPropertyName("endN2")]
        public object EndN2 { get; set; }

        [JsonPropertyName("startCns")]
        public object StartCns { get; set; }

        [JsonPropertyName("endCns")]
        public object EndCns { get; set; }

        [JsonPropertyName("summarizedDiveInfo")]
        public SummarizedDiveInfo SummarizedDiveInfo { get; set; }

        [JsonPropertyName("activityLikeAuthors")]
        public object ActivityLikeAuthors { get; set; }

        [JsonPropertyName("avgVerticalSpeed")]
        public double AvgVerticalSpeed { get; set; }

        [JsonPropertyName("maxVerticalSpeed")]
        public double MaxVerticalSpeed { get; set; }

        [JsonPropertyName("floorsClimbed")]
        public object FloorsClimbed { get; set; }

        [JsonPropertyName("floorsDescended")]
        public object FloorsDescended { get; set; }

        [JsonPropertyName("manufacturer")]
        public string Manufacturer { get; set; }

        [JsonPropertyName("diveNumber")]
        public object DiveNumber { get; set; }

        [JsonPropertyName("locationName")]
        public string LocationName { get; set; }

        [JsonPropertyName("bottomTime")]
        public object BottomTime { get; set; }

        [JsonPropertyName("lapCount")]
        public long LapCount { get; set; }

        [JsonPropertyName("endLatitude")]
        public double EndLatitude { get; set; }

        [JsonPropertyName("endLongitude")]
        public double EndLongitude { get; set; }

        [JsonPropertyName("minAirSpeed")]
        public double MinAirSpeed { get; set; }

        [JsonPropertyName("maxAirSpeed")]
        public double MaxAirSpeed { get; set; }

        [JsonPropertyName("avgAirSpeed")]
        public double AvgAirSpeed { get; set; }

        [JsonPropertyName("avgWindYawAngle")]
        public double AvgWindYawAngle { get; set; }

        [JsonPropertyName("minCda")]
        public double MinCda { get; set; }

        [JsonPropertyName("maxCda")]
        public double MaxCda { get; set; }

        [JsonPropertyName("avgCda")]
        public double AvgCda { get; set; }

        [JsonPropertyName("avgWattsPerCda")]
        public double AvgWattsPerCda { get; set; }

        [JsonPropertyName("flow")]
        public object Flow { get; set; }

        [JsonPropertyName("grit")]
        public object Grit { get; set; }

        [JsonPropertyName("jumpCount")]
        public object JumpCount { get; set; }

        [JsonPropertyName("caloriesEstimated")]
        public object CaloriesEstimated { get; set; }

        [JsonPropertyName("caloriesConsumed")]
        public object CaloriesConsumed { get; set; }

        [JsonPropertyName("waterEstimated")]
        public object WaterEstimated { get; set; }

        [JsonPropertyName("waterConsumed")]
        public object WaterConsumed { get; set; }

        [JsonPropertyName("maxAvgPower_1")]
        public double MaxAvgPower1 { get; set; }

        [JsonPropertyName("maxAvgPower_2")]
        public double MaxAvgPower2 { get; set; }

        [JsonPropertyName("maxAvgPower_5")]
        public double MaxAvgPower5 { get; set; }

        [JsonPropertyName("maxAvgPower_10")]
        public double MaxAvgPower10 { get; set; }

        [JsonPropertyName("maxAvgPower_20")]
        public double MaxAvgPower20 { get; set; }

        [JsonPropertyName("maxAvgPower_30")]
        public double MaxAvgPower30 { get; set; }

        [JsonPropertyName("maxAvgPower_60")]
        public double MaxAvgPower60 { get; set; }

        [JsonPropertyName("maxAvgPower_120")]
        public double MaxAvgPower120 { get; set; }

        [JsonPropertyName("maxAvgPower_300")]
        public double MaxAvgPower300 { get; set; }

        [JsonPropertyName("maxAvgPower_600")]
        public double MaxAvgPower600 { get; set; }

        [JsonPropertyName("maxAvgPower_1200")]
        public double MaxAvgPower1200 { get; set; }

        [JsonPropertyName("maxAvgPower_1800")]
        public double MaxAvgPower1800 { get; set; }

        [JsonPropertyName("maxAvgPower_3600")]
        public double MaxAvgPower3600 { get; set; }

        [JsonPropertyName("maxAvgPower_7200")]
        public double MaxAvgPower7200 { get; set; }

        [JsonPropertyName("maxAvgPower_18000")]
        public double MaxAvgPower18000 { get; set; }

        [JsonPropertyName("excludeFromPowerCurveReports")]
        public bool ExcludeFromPowerCurveReports { get; set; }

        [JsonPropertyName("totalSets")]
        public double TotalSets { get; set; }

        [JsonPropertyName("activeSets")]
        public double ActiveSets { get; set; }

        [JsonPropertyName("totalReps")]
        public double TotalReps { get; set; }

        [JsonPropertyName("minRespirationRate")]
        public double MinRespirationRate { get; set; }

        [JsonPropertyName("maxRespirationRate")]
        public double MaxRespirationRate { get; set; }

        [JsonPropertyName("avgRespirationRate")]
        public double AvgRespirationRate { get; set; }

        [JsonPropertyName("trainingEffectLabel")]
        public object TrainingEffectLabel { get; set; }

        [JsonPropertyName("activityTrainingLoad")]
        public double ActivityTrainingLoad { get; set; }

        [JsonPropertyName("avgFlow")]
        public double AvgFlow { get; set; }

        [JsonPropertyName("avgGrit")]
        public double AvgGrit { get; set; }

        [JsonPropertyName("minActivityLapDuration")]
        public double MinActivityLapDuration { get; set; }

        [JsonPropertyName("avgStress")]
        public double AvgStress { get; set; }

        [JsonPropertyName("startStress")]
        public double StartStress { get; set; }

        [JsonPropertyName("endStress")]
        public double EndStress { get; set; }

        [JsonPropertyName("differenceStress")]
        public object DifferenceStress { get; set; }

        [JsonPropertyName("maxStress")]
        public double MaxStress { get; set; }

        [JsonPropertyName("aerobicTrainingEffectMessage")]
        public object AerobicTrainingEffectMessage { get; set; }

        [JsonPropertyName("anaerobicTrainingEffectMessage")]
        public object AnaerobicTrainingEffectMessage { get; set; }

        [JsonPropertyName("splitSummaries")]
        public SplitSummary[] SplitSummaries { get; set; }

        [JsonPropertyName("hasSplits")]
        public bool HasSplits { get; set; }

        [JsonPropertyName("moderateIntensityMinutes")]
        public long ModerateIntensityMinutes { get; set; }

        [JsonPropertyName("vigorousIntensityMinutes")]
        public long VigorousIntensityMinutes { get; set; }

        [JsonPropertyName("maxBottomTime")]
        public object MaxBottomTime { get; set; }

        [JsonPropertyName("hasSeedFirstbeatProfile")]
        public object HasSeedFirstbeatProfile { get; set; }

        [JsonPropertyName("purposeful")]
        public bool Purposeful { get; set; }

        [JsonPropertyName("favorite")]
        public bool Favorite { get; set; }

        [JsonPropertyName("pr")]
        public bool Pr { get; set; }

        [JsonPropertyName("autoCalcCalories")]
        public bool AutoCalcCalories { get; set; }

        [JsonPropertyName("atpActivity")]
        public bool AtpActivity { get; set; }

        [JsonPropertyName("manualActivity")]
        public bool ManualActivity { get; set; }

        [JsonPropertyName("elevationCorrected")]
        public bool ElevationCorrected { get; set; }

        [JsonPropertyName("decoDive")]
        public bool DecoDive { get; set; }

        [JsonPropertyName("parent")]
        public bool Parent { get; set; }
    }

    public class ActivityType
    {
        [JsonPropertyName("typeId")]
        public long TypeId { get; set; }

        [JsonPropertyName("typeKey")]
        public string TypeKey { get; set; }

        [JsonPropertyName("parentTypeId")]
        public long ParentTypeId { get; set; }

        [JsonPropertyName("isHidden")]
        public bool IsHidden { get; set; }

        [JsonPropertyName("sortOrder")]
        public object SortOrder { get; set; }

        [JsonPropertyName("trimmable")]
        public bool Trimmable { get; set; }

        [JsonPropertyName("restricted")]
        public bool Restricted { get; set; }
    }

    public class EventType
    {
        [JsonPropertyName("typeId")]
        public long TypeId { get; set; }

        [JsonPropertyName("typeKey")]
        public string TypeKey { get; set; }

        [JsonPropertyName("sortOrder")]
        public long SortOrder { get; set; }
    }

    public class Privacy
    {
        [JsonPropertyName("typeId")]
        public long TypeId { get; set; }

        [JsonPropertyName("typeKey")]
        public string TypeKey { get; set; }
    }

    public class SplitSummary
    {
        [JsonPropertyName("noOfSplits")]
        public object NoOfSplits { get; set; }

        [JsonPropertyName("maxGradeValue")]
        public object MaxGradeValue { get; set; }

        [JsonPropertyName("totalAscent")]
        public double TotalAscent { get; set; }

        [JsonPropertyName("duration")]
        public double Duration { get; set; }

        [JsonPropertyName("splitType")]
        public string SplitType { get; set; }

        [JsonPropertyName("numClimbSends")]
        public double NumClimbSends { get; set; }

        [JsonPropertyName("maxElevationGain")]
        public double MaxElevationGain { get; set; }

        [JsonPropertyName("averageElevationGain")]
        public double AverageElevationGain { get; set; }

        [JsonPropertyName("maxDistance")]
        public double MaxDistance { get; set; }

        [JsonPropertyName("distance")]
        public double Distance { get; set; }

        [JsonPropertyName("averageSpeed")]
        public double AverageSpeed { get; set; }

        [JsonPropertyName("maxSpeed")]
        public double MaxSpeed { get; set; }

        [JsonPropertyName("mode")]
        public object Mode { get; set; }

        [JsonPropertyName("numFalls")]
        public long NumFalls { get; set; }
    }

    public class SummarizedDiveInfo
    {
        [JsonPropertyName("weight")]
        public double Weight { get; set; }

        [JsonPropertyName("weightUnit")]
        public object WeightUnit { get; set; }

        [JsonPropertyName("visibility")]
        public object Visibility { get; set; }

        [JsonPropertyName("visibilityUnit")]
        public object VisibilityUnit { get; set; }

        [JsonPropertyName("surfaceCondition")]
        public object SurfaceCondition { get; set; }

        [JsonPropertyName("current")]
        public object Current { get; set; }

        [JsonPropertyName("waterType")]
        public object WaterType { get; set; }

        [JsonPropertyName("waterDensity")]
        public object WaterDensity { get; set; }

        [JsonPropertyName("summarizedDiveGases")]
        public object[] SummarizedDiveGases { get; set; }

        [JsonPropertyName("totalSurfaceTime")]
        public object TotalSurfaceTime { get; set; }
    }
}