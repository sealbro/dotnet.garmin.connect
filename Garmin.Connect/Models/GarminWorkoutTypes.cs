using System.Text.Json.Serialization;

namespace Garmin.Connect.Models;

public record GarminWorkoutTypes
{
    [JsonPropertyName("workoutStepTypes")]
    public WorkoutStepType[] WorkoutStepTypes { get; init; }

    [JsonPropertyName("workoutSportTypes")]
    public WorkoutSportType[] WorkoutSportTypes { get; init; }

    [JsonPropertyName("workoutConditionTypes")]
    public WorkoutConditionType[] WorkoutConditionTypes { get; init; }

    [JsonPropertyName("workoutIntensityTypes")]
    public WorkoutIntensityType[] WorkoutIntensityTypes { get; init; }

    [JsonPropertyName("workoutTargetTypes")]
    public WorkoutTargetType[] WorkoutTargetTypes { get; init; }

    [JsonPropertyName("workoutEquipmentTypes")]
    public WorkoutEquipmentType[] WorkoutEquipmentTypes { get; init; }

    [JsonPropertyName("workoutStrokeTypes")]
    public WorkoutStrokeType[] WorkoutStrokeTypes { get; init; }

    [JsonPropertyName("workoutSwimInstructionTypes")]
    public WorkoutSwimInstructionType[] WorkoutSwimInstructionTypes { get; init; }

    [JsonPropertyName("workoutDrillTypes")]
    public WorkoutDrillType[] WorkoutDrillTypes { get; init; }
}

public record WorkoutConditionType
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

public record WorkoutDrillType
{
    [JsonPropertyName("drillTypeId")]
    public long DrillTypeId { get; init; }

    [JsonPropertyName("drillTypeKey")]
    public string DrillTypeKey { get; init; }

    [JsonPropertyName("displayOrder")]
    public long DisplayOrder { get; init; }
}

public record WorkoutEquipmentType
{
    [JsonPropertyName("equipmentTypeId")]
    public long EquipmentTypeId { get; init; }

    [JsonPropertyName("equipmentTypeKey")]
    public string EquipmentTypeKey { get; init; }

    [JsonPropertyName("displayOrder")]
    public long DisplayOrder { get; init; }
}

public record WorkoutIntensityType
{
    [JsonPropertyName("intensityTypeId")]
    public long IntensityTypeId { get; init; }

    [JsonPropertyName("intensityTypeKey")]
    public string IntensityTypeKey { get; init; }

    [JsonPropertyName("displayOrder")]
    public long DisplayOrder { get; init; }
}

public record WorkoutSportType
{
    [JsonPropertyName("sportTypeId")]
    public long SportTypeId { get; init; }

    [JsonPropertyName("sportTypeKey")]
    public string SportTypeKey { get; init; }

    [JsonPropertyName("displayOrder")]
    public long DisplayOrder { get; init; }
}

public record WorkoutStepType
{
    [JsonPropertyName("stepTypeId")]
    public long StepTypeId { get; init; }

    [JsonPropertyName("stepTypeKey")]
    public string StepTypeKey { get; init; }

    [JsonPropertyName("displayOrder")]
    public long DisplayOrder { get; init; }
}

public record WorkoutStrokeType
{
    [JsonPropertyName("strokeTypeId")]
    public long StrokeTypeId { get; init; }

    [JsonPropertyName("strokeTypeKey")]
    public string StrokeTypeKey { get; init; }

    [JsonPropertyName("displayOrder")]
    public long DisplayOrder { get; init; }
}

public record WorkoutSwimInstructionType
{
    [JsonPropertyName("swimInstructionTypeId")]
    public long SwimInstructionTypeId { get; init; }

    [JsonPropertyName("swimInstructionTypeKey")]
    public string SwimInstructionTypeKey { get; init; }

    [JsonPropertyName("displayOrder")]
    public long DisplayOrder { get; init; }
}

public record WorkoutTargetType
{
    [JsonPropertyName("workoutTargetTypeId")]
    public long WorkoutTargetTypeId { get; init; }

    [JsonPropertyName("workoutTargetTypeKey")]
    public string WorkoutTargetTypeKey { get; init; }

    [JsonPropertyName("displayOrder")]
    public long DisplayOrder { get; init; }
}