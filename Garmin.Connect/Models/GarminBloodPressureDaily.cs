using System;
using System.Text.Json.Serialization;
using Garmin.Connect.Converters;

namespace Garmin.Connect.Models;

public record GarminBloodPressureDaily
{
    [JsonPropertyName("startDate")]
    [JsonConverter(typeof(DateOnlyConverter))]
    public DateOnly StartDate { get; init; }

    [JsonPropertyName("endDate")]
    [JsonConverter(typeof(DateOnlyConverter))]
    public DateOnly EndDate { get; init; }

    [JsonPropertyName("bloodPressureMeasurements")]
    public GarminBloodPressureMeasurement[] BloodPressureMeasurements { get; init; }

    [JsonPropertyName("totalMeasurementCount")]
    public object TotalMeasurementCount { get; init; }

    [JsonPropertyName("elevatedMeasurementCount")]
    public object ElevatedMeasurementCount { get; init; }
}

public record GarminBloodPressureIdentifier
{
    [JsonPropertyName("version")]
    public long Version { get; init; }
    
    [JsonPropertyName("measurementTimestampGMT")]
    [JsonConverter(typeof(DateTimeConverter))]
    public DateTime MeasurementTimestampGmt { get; init; }
}

public record GarminBloodPressureMeasurement: GarminBloodPressureIdentifier
{
    [JsonPropertyName("systolic")]
    public long Systolic { get; init; }

    [JsonPropertyName("diastolic")]
    public long Diastolic { get; init; }

    [JsonPropertyName("pulse")]
    public long Pulse { get; init; }

    [JsonPropertyName("multiMeasurement")]
    public bool MultiMeasurement { get; init; }

    [JsonPropertyName("notes")]
    public string Notes { get; init; }

    [JsonPropertyName("sourceType")]
    public string SourceType { get; init; }

    [JsonPropertyName("measurementTimestampLocal")]
    [JsonConverter(typeof(DateTimeConverter))]
    public DateTime MeasurementTimestampLocal { get; init; }

    [JsonPropertyName("category")]
    public string Category { get; init; }

    [JsonPropertyName("categoryName")]
    public string CategoryName { get; init; }
}