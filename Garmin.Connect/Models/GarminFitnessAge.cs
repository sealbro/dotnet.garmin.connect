using System;
using System.Text.Json.Serialization;
using Garmin.Connect.Converters;

namespace Garmin.Connect.Models;

public record GarminFitnessAge
{
    [JsonPropertyName("chronologicalAge")]
    public double ChronologicalAge { get; init; }

    [JsonPropertyName("fitnessAge")]
    public double FitnessAge { get; init; }

    [JsonPropertyName("achievableFitnessAge")]
    public double AchievableFitnessAge { get; init; }

    [JsonPropertyName("previousFitnessAge")]
    public double PreviousFitnessAge { get; init; }

    [JsonPropertyName("components")]
    public GarminFitnessAgeComponents Components { get; init; }

    [JsonPropertyName("lastUpdated")]
    [JsonConverter(typeof(DateTimeConverter))]
    public DateTime LastUpdated { get; init; }
}

public record GarminFitnessAgeComponents
{
    [JsonPropertyName("vigorousDaysAvg")]
    public GarminFitnessAgeVigorousDaysAvg VigorousDaysAvg { get; init; }

    [JsonPropertyName("rhr")]
    public GarminFitnessAgeRhr Rhr { get; init; }

    [JsonPropertyName("vigorousMinutesAvg")]
    public GarminFitnessAgeVigorousMinutesAvg VigorousMinutesAvg { get; init; }

    [JsonPropertyName("bmi")]
    public GarminFitnessAgeBmi Bmi { get; init; }
}

public record GarminFitnessAgeVigorousDaysAvg
{
    [JsonPropertyName("value")]
    public double Value { get; init; }

    [JsonPropertyName("targetValue")]
    public double TargetValue { get; init; }

    [JsonPropertyName("potentialAge")]
    public double PotentialAge { get; init; }

    [JsonPropertyName("priority")]
    public double Priority { get; init; }

    [JsonPropertyName("stale")]
    public bool Stale { get; init; }

    [JsonPropertyName("numOfWeeksForIm")]
    public double NumOfWeeksForIm { get; init; }
}

public record GarminFitnessAgeRhr
{
    [JsonPropertyName("value")]
    public double Value { get; init; }

    [JsonPropertyName("stale")]
    public bool Stale { get; init; }
}

public record GarminFitnessAgeVigorousMinutesAvg
{
    [JsonPropertyName("value")]
    public double Value { get; init; }

    [JsonPropertyName("stale")]
    public bool Stale { get; init; }

    [JsonPropertyName("numOfWeeksForIm")]
    public double NumOfWeeksForIm { get; init; }
}

public record GarminFitnessAgeBmi
{
    [JsonPropertyName("value")]
    public double Value { get; init; }

    [JsonPropertyName("targetValue")]
    public double TargetValue { get; init; }

    [JsonPropertyName("improvementValue")]
    public double ImprovementValue { get; init; }

    [JsonPropertyName("potentialAge")]
    public double PotentialAge { get; init; }

    [JsonPropertyName("priority")]
    public double Priority { get; init; }

    [JsonPropertyName("stale")]
    public bool Stale { get; init; }

    [JsonPropertyName("lastMeasurementDate")]
    [JsonConverter(typeof(DateOnlyConverter))]
    public DateOnly LastMeasurementDate { get; init; }
}
