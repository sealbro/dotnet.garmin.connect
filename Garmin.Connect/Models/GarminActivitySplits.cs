using System;
using System.Text.Json.Serialization;

namespace Garmin.Connect.Models;

public record GarminActivitySplits
{
    [JsonPropertyName("activityId")]
    public long ActivityId { get; init; }

    [JsonPropertyName("lapDTOs")]
    public LapDto[] LapDtOs { get; init; }

    [JsonPropertyName("eventDTOs")]
    public EventDto[] EventDtOs { get; init; }
}

public record EventDto
{
    [JsonPropertyName("startTimeGMT")]
    public DateTime StartTimeGmt { get; init; }

    [JsonPropertyName("startTimeGMTDoubleValue")]
    public double StartTimeGmtDoubleValue { get; init; }

    [JsonPropertyName("sectionTypeDTO")]
    public SectionTypeDto SectionTypeDto { get; init; }
}

public record SectionTypeDto
{
    [JsonPropertyName("id")]
    public long Id { get; init; }

    [JsonPropertyName("key")]
    public string Key { get; init; }

    [JsonPropertyName("sectionTypeKey")]
    public string SectionTypeKey { get; init; }
}

public record LapDto
{
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

    [JsonPropertyName("bmrCalories")]
    public double BmrCalories { get; init; }

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

    [JsonPropertyName("verticalRatio")]
    public double VerticalRatio { get; init; }

    [JsonPropertyName("endLatitude")]
    public double EndLatitude { get; init; }

    [JsonPropertyName("endLongitude")]
    public double EndLongitude { get; init; }

    [JsonPropertyName("maxVerticalSpeed")]
    public double MaxVerticalSpeed { get; init; }

    [JsonPropertyName("maxRespirationRate")]
    public double MaxRespirationRate { get; init; }

    [JsonPropertyName("avgRespirationRate")]
    public double AvgRespirationRate { get; init; }

    [JsonPropertyName("lapIndex")]
    public long LapIndex { get; init; }

    [JsonPropertyName("lengthDTOs")]
    public LengthDto[] LengthDtOs { get; init; }

    [JsonPropertyName("connectIQMeasurement")]
    public GarminConnectIqMeasurement[] ConnectIqMeasurement { get; init; }

    [JsonPropertyName("intensityType")]
    public string IntensityType { get; init; }

    [JsonPropertyName("messageIndex")]
    public long MessageIndex { get; init; }
}

public record LengthDto
{
    [JsonPropertyName("startTimeGMT")]
    public DateTime StartTimeGmt { get; init; }

    [JsonPropertyName("distance")]
    public double Distance { get; init; }

    [JsonPropertyName("duration")]
    public double Duration { get; init; }

    [JsonPropertyName("averageSpeed")]
    public double? AverageSpeed { get; init; }

    [JsonPropertyName("maxSpeed")]
    public double MaxSpeed { get; init; }

    [JsonPropertyName("calories")]
    public double Calories { get; init; }

    [JsonPropertyName("averageHR")]
    public double AverageHr { get; init; }

    [JsonPropertyName("maxHR")]
    public double MaxHr { get; init; }

    [JsonPropertyName("totalNumberOfStrokes")]
    public long? TotalNumberOfStrokes { get; init; }

    [JsonPropertyName("averageSWOLF")]
    public double AverageSwolf { get; init; }

    [JsonPropertyName("lengthIndex")]
    public long LengthIndex { get; init; }

    [JsonPropertyName("swimStroke")]
    public string SwimStroke { get; init; }
}