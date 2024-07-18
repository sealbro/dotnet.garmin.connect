using System;
using System.Text.Json.Serialization;

namespace Garmin.Connect.Models;

public record GarminBodyComposition
{
    [JsonPropertyName("startDate")]
    public DateTime StartDate { get; init; }

    [JsonPropertyName("endDate")]
    public DateTime EndDate { get; init; }

    [JsonPropertyName("dateWeightList")]
    public GarminDateWeight[] DateWeightList { get; init; }

    [JsonPropertyName("totalAverage")]
    public GarminTotalAverage TotalAverage { get; init; }
}

public record GarminTotalAverage
{
    [JsonPropertyName("from")]
    public long From { get; init; }

    [JsonPropertyName("until")]
    public long Until { get; init; }

    [JsonPropertyName("weight")]
    public double Weight { get; init; }

    [JsonPropertyName("bmi")]
    public double Bmi { get; init; }

    [JsonPropertyName("bodyFat")]
    public double BodyFat { get; init; }

    [JsonPropertyName("bodyWater")]
    public double BodyWater { get; init; }

    [JsonPropertyName("boneMass")]
    public double BoneMass { get; init; }

    [JsonPropertyName("muscleMass")]
    public double MuscleMass { get; init; }

    [JsonPropertyName("physiqueRating")]
    public double PhysiqueRating { get; init; }

    [JsonPropertyName("visceralFat")]
    public double VisceralFat { get; init; }

    [JsonPropertyName("metabolicAge")]
    public double MetabolicAge { get; init; }
}

public record GarminDateWeight
{
    [JsonPropertyName("samplePk")]
    public long SamplePk { get; init; }

    [JsonPropertyName("date")]
    public long Date { get; init; }

    [JsonPropertyName("calendarDate")]
    public DateTime CalendarDate { get; init; }

    [JsonPropertyName("weight")]
    public double Weight { get; init; }

    [JsonPropertyName("bmi")]
    public double Bmi { get; init; }

    [JsonPropertyName("bodyFat")]
    public double BodyFat { get; init; }

    [JsonPropertyName("bodyWater")]
    public double BodyWater { get; init; }

    [JsonPropertyName("boneMass")]
    public long BoneMass { get; init; }

    [JsonPropertyName("muscleMass")]
    public long MuscleMass { get; init; }

    [JsonPropertyName("physiqueRating")]
    public double PhysiqueRating { get; init; }

    [JsonPropertyName("visceralFat")]
    public double VisceralFat { get; init; }

    [JsonPropertyName("metabolicAge")]
    public double MetabolicAge { get; init; }

    [JsonPropertyName("sourceType")]
    public string SourceType { get; init; }

    [JsonPropertyName("timestampGMT")]
    public long TimestampGmt { get; init; }

    [JsonPropertyName("weightDelta")]
    public double WeightDelta { get; init; }
}