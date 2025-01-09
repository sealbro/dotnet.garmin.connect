using System;
using System.Text.Json.Serialization;
using Garmin.Connect.Converters;

namespace Garmin.Connect.Models.Internal;

internal record GarminBloodPressureRequest
{
    [JsonPropertyName("version")]
    public object Version { get; init; }

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

    [JsonPropertyName("measurementTimestampGMT")]
    [JsonConverter(typeof(DateTimeConverter))]
    public DateTime MeasurementTimestampGmt { get; init; }

    [JsonPropertyName("category")]
    public object Category { get; init; }

    [JsonPropertyName("categoryName")]
    public object CategoryName { get; init; }
}