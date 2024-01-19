using System;
using System.Text.Json.Serialization;
using Garmin.Connect.Converters;

namespace Garmin.Connect.Models;

public record GarminCalendarMonth
{
    [JsonPropertyName("startDayOfMonth")]
    public int StartDayOfMonth { get; init; }

    [JsonPropertyName("numOfDaysInMonth")]
    public int NumOfDaysInMonth { get; init; }

    [JsonPropertyName("numOfDaysInPrevMonth")]
    public int NumOfDaysInPrevMonth { get; init; }

    [JsonPropertyName("month")]
    public GarminMonth Month { get; init; }

    [JsonPropertyName("year")]
    public int Year { get; init; }

    [JsonPropertyName("calendarItems")]
    public GarminCalendarItem[] CalendarItems { get; init; }
}

public record GarminCalendarItem
{
    [JsonPropertyName("id")]
    public long Id { get; init; }

    [JsonPropertyName("groupId")]
    public long? GroupId { get; init; }

    [JsonPropertyName("trainingPlanId")]
    public long? TrainingPlanId { get; init; }

    [JsonPropertyName("itemType")]
    public string ItemType { get; init; }

    [JsonPropertyName("activityTypeId")]
    public long? ActivityTypeId { get; init; }

    [JsonPropertyName("wellnessActivityUuid")]
    public string WellnessActivityUuid { get; init; }

    [JsonPropertyName("title")]
    public string Title { get; init; }

    [JsonPropertyName("date")]
    [JsonConverter(typeof(DateOnlyConverter))]
    public DateOnly Date { get; init; }

    [JsonPropertyName("duration")]
    public double? Duration { get; init; }

    [JsonPropertyName("distance")]
    public double? Distance { get; init; }

    [JsonPropertyName("calories")]
    public double? Calories { get; init; }

    [JsonPropertyName("floorsClimbed")]
    public object FloorsClimbed { get; init; }

    [JsonPropertyName("avgRespirationRate")]
    public double? AvgRespirationRate { get; init; }

    [JsonPropertyName("unitOfPoolLength")]
    public GarminUnitOfPoolLength UnitOfPoolLength { get; init; }

    [JsonPropertyName("weight")]
    public double? Weight { get; init; }

    [JsonPropertyName("difference")]
    public double? Difference { get; init; }

    [JsonPropertyName("courseId")]
    public object CourseId { get; init; }

    [JsonPropertyName("courseName")]
    public object CourseName { get; init; }

    [JsonPropertyName("sportTypeKey")]
    public string SportTypeKey { get; init; }

    [JsonPropertyName("url")]
    public string Url { get; init; }

    [JsonPropertyName("isStart")]
    public bool IsStart { get; init; }

    [JsonPropertyName("isRace")]
    public bool IsRace { get; init; }

    [JsonPropertyName("recurrenceId")]
    public object RecurrenceId { get; init; }

    [JsonPropertyName("isParent")]
    public bool? IsParent { get; init; }

    [JsonPropertyName("parentId")]
    public long? ParentId { get; init; }

    [JsonPropertyName("userBadgeId")]
    public long? UserBadgeId { get; init; }

    [JsonPropertyName("badgeCategoryTypeId")]
    public long? BadgeCategoryTypeId { get; init; }

    [JsonPropertyName("badgeCategoryTypeDesc")]
    public string BadgeCategoryTypeDesc { get; init; }

    [JsonPropertyName("badgeAwardedDate")]
    public object BadgeAwardedDate { get; init; }

    [JsonPropertyName("badgeViewed")]
    public object BadgeViewed { get; init; }

    [JsonPropertyName("hideBadge")]
    public object HideBadge { get; init; }

    [JsonPropertyName("startTimestampLocal")]
    [JsonConverter(typeof(DateTimeConverter))]
    public DateTime? StartTimestampLocal { get; init; }

    [JsonPropertyName("eventTimeLocal")]
    public object EventTimeLocal { get; init; }

    [JsonPropertyName("diveNumber")]
    public object DiveNumber { get; init; }

    [JsonPropertyName("maxDepth")]
    public object MaxDepth { get; init; }

    [JsonPropertyName("avgDepth")]
    public object AvgDepth { get; init; }

    [JsonPropertyName("surfaceInterval")]
    public object SurfaceInterval { get; init; }

    [JsonPropertyName("elapsedDuration")]
    public double? ElapsedDuration { get; init; }

    [JsonPropertyName("lapCount")]
    public long? LapCount { get; init; }

    [JsonPropertyName("bottomTime")]
    public object BottomTime { get; init; }

    [JsonPropertyName("atpPlanId")]
    public object AtpPlanId { get; init; }

    [JsonPropertyName("workoutId")]
    public long? WorkoutId { get; init; }

    [JsonPropertyName("protectedWorkoutSchedule")]
    public bool ProtectedWorkoutSchedule { get; init; }

    [JsonPropertyName("activeSets")]
    public object ActiveSets { get; init; }

    [JsonPropertyName("strokes")]
    public double? Strokes { get; init; }

    [JsonPropertyName("noOfSplits")]
    public object NoOfSplits { get; init; }

    [JsonPropertyName("maxGradeValue")]
    public object MaxGradeValue { get; init; }

    [JsonPropertyName("totalAscent")]
    public double? TotalAscent { get; init; }

    [JsonPropertyName("differenceStress")]
    public object DifferenceStress { get; init; }

    [JsonPropertyName("climbDuration")]
    public double? ClimbDuration { get; init; }

    [JsonPropertyName("maxSpeed")]
    public double? MaxSpeed { get; init; }

    [JsonPropertyName("averageHR")]
    public double? AverageHr { get; init; }

    [JsonPropertyName("activeSplitSummaryDuration")]
    public double? ActiveSplitSummaryDuration { get; init; }

    [JsonPropertyName("maxSplitDistance")]
    public long? MaxSplitDistance { get; init; }

    [JsonPropertyName("maxSplitSpeed")]
    public double? MaxSplitSpeed { get; init; }

    [JsonPropertyName("location")]
    public object Location { get; init; }

    [JsonPropertyName("shareableEventUuid")]
    public object ShareableEventUuid { get; init; }

    [JsonPropertyName("splitSummaryMode")]
    public object SplitSummaryMode { get; init; }

    [JsonPropertyName("completionTarget")]
    public object CompletionTarget { get; init; }

    [JsonPropertyName("decoDive")]
    public bool? DecoDive { get; init; }

    [JsonPropertyName("autoCalcCalories")]
    public bool? AutoCalcCalories { get; init; }

    [JsonPropertyName("shareableEvent")]
    public bool ShareableEvent { get; init; }

    [JsonPropertyName("phasedTrainingPlan")]
    public bool? PhasedTrainingPlan { get; init; }

    [JsonPropertyName("primaryEvent")]
    public object PrimaryEvent { get; init; }

    [JsonPropertyName("subscribed")]
    public object Subscribed { get; init; }
}

public record GarminUnitOfPoolLength
{
    [JsonPropertyName("unitId")]
    public long UnitId { get; init; }

    [JsonPropertyName("unitKey")]
    public string UnitKey { get; init; }

    [JsonPropertyName("factor")]
    public double Factor { get; init; }
}