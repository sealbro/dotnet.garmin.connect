using System;
using System.Text.Json.Serialization;
using Garmin.Connect.Converters;

namespace Garmin.Connect.Models;

public record GarminWeightRange
{
    [JsonPropertyName("dailyWeightSummaries")]
    public GarminWeightDailyWeightSummary[] DailyWeightSummaries { get; init; }

    [JsonPropertyName("totalAverage")]
    public GarminWeightTotalAverage TotalAverage { get; init; }
}

public record GarminWeightDailyWeightSummary
{
    [JsonPropertyName("summaryDate")]
    [JsonConverter(typeof(DateOnlyConverter))]
    public DateOnly SummaryDate { get; init; }

    [JsonPropertyName("numOfWeightEntries")]
    public long NumOfWeightEntries { get; init; }

    [JsonPropertyName("minWeight")]
    public double MinWeight { get; init; }

    [JsonPropertyName("maxWeight")]
    public double MaxWeight { get; init; }

    [JsonPropertyName("latestWeight")]
    public GarminWeightMeasurement LatestWeight { get; init; }

    [JsonPropertyName("allWeightMetrics")]
    public GarminWeightMeasurement[] AllWeightMetrics { get; init; }
}

public record GarminWeightIdentifier
{
    [JsonPropertyName("samplePk")]
    public long SamplePk { get; init; }

    [JsonPropertyName("calendarDate")]
    [JsonConverter(typeof(DateOnlyConverter))]
    public DateOnly CalendarDate { get; init; }
}

public record GarminWeightMeasurement : GarminWeightIdentifier
{
    [JsonPropertyName("date")]
    public long Date { get; init; }

    [JsonPropertyName("weight")]
    public double Weight { get; init; }

    [JsonPropertyName("bmi")]
    public double? Bmi { get; init; }

    [JsonPropertyName("bodyFat")]
    public double? BodyFat { get; init; }

    [JsonPropertyName("bodyWater")]
    public double? BodyWater { get; init; }

    [JsonPropertyName("boneMass")]
    public long? BoneMass { get; init; }

    [JsonPropertyName("muscleMass")]
    public long? MuscleMass { get; init; }

    [JsonPropertyName("physiqueRating")]
    public object PhysiqueRating { get; init; }

    [JsonPropertyName("visceralFat")]
    public object VisceralFat { get; init; }

    [JsonPropertyName("metabolicAge")]
    public object MetabolicAge { get; init; }

    [JsonPropertyName("sourceType")]
    public string SourceType { get; init; }

    [JsonPropertyName("timestampGMT")]
    public long TimestampGmt { get; init; }

    [JsonPropertyName("weightDelta")]
    public double? WeightDelta { get; init; }
}

public record GarminWeightTotalAverage
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
    public long BoneMass { get; init; }

    [JsonPropertyName("muscleMass")]
    public long MuscleMass { get; init; }

    [JsonPropertyName("physiqueRating")]
    public object PhysiqueRating { get; init; }

    [JsonPropertyName("visceralFat")]
    public object VisceralFat { get; init; }

    [JsonPropertyName("metabolicAge")]
    public object MetabolicAge { get; init; }
}
