using System;
using System.Text.Json.Serialization;
using Garmin.Connect.Converters;

namespace Garmin.Connect.Models;

public record GarminWorkout
{
    [JsonPropertyName("workoutId")]
    public long WorkoutId { get; init; }

    [JsonPropertyName("ownerId")]
    public long OwnerId { get; init; }

    [JsonPropertyName("workoutName")]
    public string WorkoutName { get; init; }

    [JsonPropertyName("description")]
    public string Description { get; init; }

    [JsonPropertyName("updateDate")]
    [JsonConverter(typeof(DateTimeConverter))]
    public DateTime UpdateDate { get; init; }

    [JsonPropertyName("createdDate")]
    [JsonConverter(typeof(DateTimeConverter))]
    public DateTime CreatedDate { get; init; }

    [JsonPropertyName("sportType")]
    public GarminSportType SportType { get; init; }

    [JsonPropertyName("trainingPlanId")]
    public object TrainingPlanId { get; init; }

    [JsonPropertyName("author")]
    public GarminAuthor Author { get; init; }

    [JsonPropertyName("estimatedDurationInSecs")]
    public long EstimatedDurationInSecs { get; init; }

    [JsonPropertyName("estimatedDistanceInMeters")]
    public double EstimatedDistanceInMeters { get; init; }

    [JsonPropertyName("estimateType")]
    public object EstimateType { get; init; }

    [JsonPropertyName("poolLength")]
    public double PoolLength { get; init; }

    [JsonPropertyName("poolLengthUnit")]
    public GarminUnit PoolLengthUnit { get; init; }

    [JsonPropertyName("workoutProvider")]
    public string WorkoutProvider { get; init; }

    [JsonPropertyName("workoutSourceId")]
    public string WorkoutSourceId { get; init; }

    [JsonPropertyName("consumer")]
    public string Consumer { get; init; }

    [JsonPropertyName("atpPlanId")]
    public long? AtpPlanId { get; init; }

    [JsonPropertyName("workoutNameI18nKey")]
    public string WorkoutNameI18NKey { get; init; }

    [JsonPropertyName("descriptionI18nKey")]
    public string DescriptionI18NKey { get; init; }

    [JsonPropertyName("estimatedDistanceUnit")]
    public GarminUnit EstimatedDistanceUnit { get; init; }

    [JsonPropertyName("shared")]
    public bool Shared { get; init; }

    [JsonPropertyName("estimated")]
    public bool Estimated { get; init; }

    [JsonPropertyName("avgTrainingSpeed")]
    public double AvgTrainingSpeed { get; init; }

    [JsonPropertyName("subSportType")]
    public object SubSportType { get; init; }

    [JsonPropertyName("sharedWithUsers")]
    public object SharedWithUsers { get; init; }

    [JsonPropertyName("workoutSegments")]
    public GarminWorkoutSegment[] WorkoutSegments { get; init; }

    [JsonPropertyName("uploadTimestamp")]
    public object UploadTimestamp { get; init; }
}

public record GarminAuthor
{
    [JsonPropertyName("userProfilePk")]
    public long? UserProfilePk { get; init; }

    [JsonPropertyName("displayName")]
    public string DisplayName { get; init; }

    [JsonPropertyName("fullName")]
    public string FullName { get; init; }

    [JsonPropertyName("profileImgNameLarge")]
    public string ProfileImgNameLarge { get; init; }

    [JsonPropertyName("profileImgNameMedium")]
    public string ProfileImgNameMedium { get; init; }

    [JsonPropertyName("profileImgNameSmall")]
    public string ProfileImgNameSmall { get; init; }

    [JsonPropertyName("userPro")]
    public bool UserPro { get; init; }

    [JsonPropertyName("vivokidUser")]
    public bool VivokidUser { get; init; }
}

public record GarminUnit
{
    [JsonPropertyName("unitId")]
    public long? UnitId { get; init; }

    [JsonPropertyName("unitKey")]
    public string UnitKey { get; init; }

    [JsonPropertyName("factor")]
    public double? Factor { get; init; }
}

public record GarminSportType
{
    [JsonPropertyName("sportTypeId")]
    public long SportTypeId { get; init; }

    [JsonPropertyName("sportTypeKey")]
    public string SportTypeKey { get; init; }

    [JsonPropertyName("displayOrder")]
    public long DisplayOrder { get; init; }
}