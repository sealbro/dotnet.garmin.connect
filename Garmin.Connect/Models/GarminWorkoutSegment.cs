using System.Text.Json.Serialization;

namespace Garmin.Connect.Models;

public record GarminWorkoutSegment
{
    [JsonPropertyName("segmentOrder")]
    public long SegmentOrder { get; init; }

    [JsonPropertyName("sportType")]
    public GarminSportType SportType { get; init; }

    [JsonPropertyName("workoutSteps")]
    public GarminWorkoutStep[] WorkoutSteps { get; init; }
}

public record GarminWorkoutStep
{
    [JsonPropertyName("type")]
    public string Type { get; init; }

    [JsonPropertyName("stepId")]
    public long StepId { get; init; }

    [JsonPropertyName("stepOrder")]
    public long StepOrder { get; init; }

    [JsonPropertyName("stepType")]
    public GarminWorkoutStepType StepType { get; init; }

    [JsonPropertyName("childStepId")]
    public object ChildStepId { get; init; }

    [JsonPropertyName("description")]
    public object Description { get; init; }

    [JsonPropertyName("endCondition")]
    public GarminWorkoutEndCondition EndCondition { get; init; }

    [JsonPropertyName("endConditionValue")]
    public double? EndConditionValue { get; init; }

    [JsonPropertyName("preferredEndConditionUnit")]
    public object PreferredEndConditionUnit { get; init; }

    [JsonPropertyName("endConditionCompare")]
    public object EndConditionCompare { get; init; }

    [JsonPropertyName("targetType")]
    public GarminWorkoutTargetType TargetType { get; init; }

    [JsonPropertyName("targetValueOne")]
    public double? TargetValueOne { get; init; }

    [JsonPropertyName("targetValueTwo")]
    public double? TargetValueTwo { get; init; }

    [JsonPropertyName("targetValueUnit")]
    public object TargetValueUnit { get; init; }

    [JsonPropertyName("zoneNumber")]
    public long? ZoneNumber { get; init; }

    [JsonPropertyName("secondaryTargetType")]
    public object SecondaryTargetType { get; init; }

    [JsonPropertyName("secondaryTargetValueOne")]
    public object SecondaryTargetValueOne { get; init; }

    [JsonPropertyName("secondaryTargetValueTwo")]
    public object SecondaryTargetValueTwo { get; init; }

    [JsonPropertyName("secondaryTargetValueUnit")]
    public object SecondaryTargetValueUnit { get; init; }

    [JsonPropertyName("secondaryZoneNumber")]
    public object SecondaryZoneNumber { get; init; }

    [JsonPropertyName("endConditionZone")]
    public object EndConditionZone { get; init; }

    [JsonPropertyName("strokeType")]
    public GarminWorkoutStrokeType StrokeType { get; init; }

    [JsonPropertyName("equipmentType")]
    public GarminWorkoutEquipmentType EquipmentType { get; init; }

    [JsonPropertyName("category")]
    public object Category { get; init; }

    [JsonPropertyName("exerciseName")]
    public object ExerciseName { get; init; }

    [JsonPropertyName("workoutProvider")]
    public object WorkoutProvider { get; init; }

    [JsonPropertyName("providerExerciseSourceId")]
    public object ProviderExerciseSourceId { get; init; }

    [JsonPropertyName("weightValue")]
    public object WeightValue { get; init; }

    [JsonPropertyName("weightUnit")]
    public object WeightUnit { get; init; }
}

public record GarminWorkoutEndCondition
{
    [JsonPropertyName("conditionTypeId")]
    public long ConditionTypeId { get; init; }

    [JsonPropertyName("conditionTypeKey")]
    public string ConditionTypeKey { get; init; }

    [JsonPropertyName("displayOrder")]
    public long DisplayOrder { get; init; }

    [JsonPropertyName("displayable")]
    public bool Displayable { get; init; }
}

public record GarminWorkoutEquipmentType
{
    [JsonPropertyName("equipmentTypeId")]
    public long EquipmentTypeId { get; init; }

    [JsonPropertyName("equipmentTypeKey")]
    public object EquipmentTypeKey { get; init; }

    [JsonPropertyName("displayOrder")]
    public long DisplayOrder { get; init; }
}

public record GarminWorkoutStepType
{
    [JsonPropertyName("stepTypeId")]
    public long StepTypeId { get; init; }

    [JsonPropertyName("stepTypeKey")]
    public string StepTypeKey { get; init; }

    [JsonPropertyName("displayOrder")]
    public long DisplayOrder { get; init; }
}

public record GarminWorkoutStrokeType
{
    [JsonPropertyName("strokeTypeId")]
    public long StrokeTypeId { get; init; }

    [JsonPropertyName("strokeTypeKey")]
    public object StrokeTypeKey { get; init; }

    [JsonPropertyName("displayOrder")]
    public long DisplayOrder { get; init; }
}

public record GarminWorkoutTargetType
{
    [JsonPropertyName("workoutTargetTypeId")]
    public long WorkoutTargetTypeId { get; init; }

    [JsonPropertyName("workoutTargetTypeKey")]
    public string WorkoutTargetTypeKey { get; init; }

    [JsonPropertyName("displayOrder")]
    public long DisplayOrder { get; init; }
}