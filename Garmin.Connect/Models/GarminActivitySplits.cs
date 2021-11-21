using System;
using System.Text.Json.Serialization;

namespace Garmin.Connect.Models;

public class GarminActivitySplits
{
    [JsonPropertyName("activityId")]
    public long ActivityId { get; set; }

    [JsonPropertyName("lapDTOs")]
    public LapDto[] LapDtOs { get; set; }

    [JsonPropertyName("eventDTOs")]
    public EventDto[] EventDtOs { get; set; }
}

public class EventDto
{
    [JsonPropertyName("startTimeGMT")]
    public DateTime StartTimeGmt { get; set; }

    [JsonPropertyName("startTimeGMTDoubleValue")]
    public double StartTimeGmtDoubleValue { get; set; }

    [JsonPropertyName("sectionTypeDTO")]
    public SectionTypeDto SectionTypeDto { get; set; }
}

public class SectionTypeDto
{
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("key")]
    public string Key { get; set; }

    [JsonPropertyName("sectionTypeKey")]
    public string SectionTypeKey { get; set; }
}

public class LapDto
{
    [JsonPropertyName("startTimeGMT")]
    public DateTime StartTimeGmt { get; set; }

    [JsonPropertyName("startLatitude")]
    public double StartLatitude { get; set; }

    [JsonPropertyName("startLongitude")]
    public double StartLongitude { get; set; }

    [JsonPropertyName("distance")]
    public double Distance { get; set; }

    [JsonPropertyName("duration")]
    public double Duration { get; set; }

    [JsonPropertyName("movingDuration")]
    public double MovingDuration { get; set; }

    [JsonPropertyName("elapsedDuration")]
    public double ElapsedDuration { get; set; }

    [JsonPropertyName("elevationGain")]
    public double ElevationGain { get; set; }

    [JsonPropertyName("elevationLoss")]
    public double ElevationLoss { get; set; }

    [JsonPropertyName("maxElevation")]
    public double MaxElevation { get; set; }

    [JsonPropertyName("minElevation")]
    public double MinElevation { get; set; }

    [JsonPropertyName("averageSpeed")]
    public double AverageSpeed { get; set; }

    [JsonPropertyName("averageMovingSpeed")]
    public double AverageMovingSpeed { get; set; }

    [JsonPropertyName("maxSpeed")]
    public double MaxSpeed { get; set; }

    [JsonPropertyName("calories")]
    public double Calories { get; set; }

    [JsonPropertyName("bmrCalories")]
    public double BmrCalories { get; set; }

    [JsonPropertyName("averageHR")]
    public double AverageHr { get; set; }

    [JsonPropertyName("maxHR")]
    public double MaxHr { get; set; }

    [JsonPropertyName("averageRunCadence")]
    public double AverageRunCadence { get; set; }

    [JsonPropertyName("maxRunCadence")]
    public double MaxRunCadence { get; set; }

    [JsonPropertyName("averageTemperature")]
    public double AverageTemperature { get; set; }

    [JsonPropertyName("maxTemperature")]
    public double MaxTemperature { get; set; }

    [JsonPropertyName("minTemperature")]
    public double MinTemperature { get; set; }

    [JsonPropertyName("groundContactTime")]
    public double GroundContactTime { get; set; }

    [JsonPropertyName("groundContactBalanceLeft")]
    public double GroundContactBalanceLeft { get; set; }

    [JsonPropertyName("strideLength")]
    public double StrideLength { get; set; }

    [JsonPropertyName("verticalOscillation")]
    public double VerticalOscillation { get; set; }

    [JsonPropertyName("verticalRatio")]
    public double VerticalRatio { get; set; }

    [JsonPropertyName("endLatitude")]
    public double EndLatitude { get; set; }

    [JsonPropertyName("endLongitude")]
    public double EndLongitude { get; set; }

    [JsonPropertyName("maxVerticalSpeed")]
    public double MaxVerticalSpeed { get; set; }

    [JsonPropertyName("maxRespirationRate")]
    public double MaxRespirationRate { get; set; }

    [JsonPropertyName("avgRespirationRate")]
    public double AvgRespirationRate { get; set; }

    [JsonPropertyName("lapIndex")]
    public long LapIndex { get; set; }

    [JsonPropertyName("lengthDTOs")]
    public object[] LengthDtOs { get; set; }

    [JsonPropertyName("connectIQMeasurement")]
    public GarminConnectIqMeasurement[] ConnectIqMeasurement { get; set; }

    [JsonPropertyName("messageIndex")]
    public long MessageIndex { get; set; }
}