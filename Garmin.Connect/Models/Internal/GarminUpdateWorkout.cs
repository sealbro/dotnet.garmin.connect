using System;
using System.Text.Json.Serialization;
using Garmin.Connect.Converters;

namespace Garmin.Connect.Models.Internal;

internal record struct GarminUpdateWorkout
{
    [JsonPropertyName("workoutId")]
    public long WorkoutId { get; init; }

    [JsonPropertyName("ownerId")]
    public long OwnerId { get; init; }

    [JsonPropertyName("workoutName")]
    public string WorkoutName { get; init; }

    [JsonPropertyName("description")]
    public string Description { get; init; }

    [JsonPropertyName("updatedDate")]
    [JsonConverter(typeof(DateTimeConverter))]
    public DateTime UpdatedDate { get; init; }

    [JsonPropertyName("createdDate")]
    [JsonConverter(typeof(DateTimeConverter))]
    public DateTime CreatedDate { get; init; }

    [JsonPropertyName("sportType")]
    public GarminSportType SportType { get; init; }

    [JsonPropertyName("subSportType")]
    public object SubSportType { get; init; }

    [JsonPropertyName("trainingPlanId")]
    public object TrainingPlanId { get; init; }

    [JsonPropertyName("author")]
    public GarminAuthor Author { get; init; }

    [JsonPropertyName("sharedWithUsers")]
    public object SharedWithUsers { get; init; }

    [JsonPropertyName("workoutSegments")]
    public GarminWorkoutSegment[] WorkoutSegments { get; init; }

    [JsonPropertyName("poolLength")]
    public double? PoolLength { get; init; }

    [JsonPropertyName("poolLengthUnit")]
    public GarminUnit PoolLengthUnit { get; init; }

    [JsonPropertyName("locale")]
    public object Locale { get; init; }

    [JsonPropertyName("workoutProvider")]
    public string WorkoutProvider { get; init; }

    [JsonPropertyName("workoutSourceId")]
    public string WorkoutSourceId { get; init; }

    [JsonPropertyName("uploadTimestamp")]
    public object UploadTimestamp { get; init; }

    [JsonPropertyName("atpPlanId")]
    public long? AtpPlanId { get; init; }

    [JsonPropertyName("consumer")]
    public string Consumer { get; init; }

    [JsonPropertyName("consumerName")]
    public string ConsumerName { get; init; }

    [JsonPropertyName("consumerImageURL")]
    public string ConsumerImageUrl { get; init; }

    [JsonPropertyName("consumerWebsiteURL")]
    public string ConsumerWebsiteUrl { get; init; }

    [JsonPropertyName("workoutNameI18nKey")]
    public string WorkoutNameI18NKey { get; init; }

    [JsonPropertyName("descriptionI18nKey")]
    public string DescriptionI18NKey { get; init; }

    [JsonPropertyName("avgTrainingSpeed")]
    public double AvgTrainingSpeed { get; init; }

    [JsonPropertyName("estimateType")]
    public object EstimateType { get; init; }

    [JsonPropertyName("estimatedDistanceUnit")]
    public GarminUnit EstimatedDistanceUnit { get; init; }

    [JsonPropertyName("shared")]
    public bool Shared { get; init; }

    [JsonPropertyName("estimatedDurationInSecs")]
    public long EstimatedDurationInSecs { get; init; }

    [JsonPropertyName("estimatedDistanceInMeters")]
    public double EstimatedDistanceInMeters { get; init; }
    
    public static GarminUpdateWorkout From(GarminWorkout workout) => new()
        {
            WorkoutId = workout.WorkoutId,
            OwnerId = workout.OwnerId,
            WorkoutName = workout.WorkoutName,
            Description = workout.Description,
            UpdatedDate = DateTime.Now,
            CreatedDate = workout.CreatedDate,
            SportType = workout.SportType,
            SubSportType = workout.SubSportType,
            TrainingPlanId = workout.TrainingPlanId,
            Author = workout.Author,
            SharedWithUsers = workout.SharedWithUsers,
            WorkoutSegments = workout.WorkoutSegments,
            PoolLength = workout.PoolLength,
            PoolLengthUnit = workout.PoolLengthUnit,
            WorkoutProvider = workout.WorkoutProvider,
            WorkoutSourceId = workout.WorkoutSourceId,
            UploadTimestamp = workout.UploadTimestamp,
            AtpPlanId = workout.AtpPlanId,
            Consumer = workout.Consumer,
            ConsumerName = workout.Consumer,
            WorkoutNameI18NKey = workout.WorkoutNameI18NKey,
            DescriptionI18NKey = workout.DescriptionI18NKey,
            AvgTrainingSpeed = workout.AvgTrainingSpeed,
            EstimateType = workout.EstimateType,
            EstimatedDistanceUnit = workout.EstimatedDistanceUnit,
            Shared = workout.Shared,
            EstimatedDurationInSecs = workout.EstimatedDurationInSecs,
            EstimatedDistanceInMeters = workout.EstimatedDistanceInMeters,
            Locale = null,
            ConsumerImageUrl = null,
            ConsumerWebsiteUrl = null,
        };
}
