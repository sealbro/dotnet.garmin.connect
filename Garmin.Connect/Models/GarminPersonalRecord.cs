using System;
using System.Text.Json.Serialization;

namespace Garmin.Connect.Models;

public record GarminPersonalRecord
{
    [JsonPropertyName("id")]
    public long Id { get; init; }

    [JsonPropertyName("typeId")]
    public long TypeId { get; init; }

    [JsonPropertyName("activityId")]
    public long ActivityId { get; init; }

    [JsonPropertyName("activityName")]
    public string ActivityName { get; init; }

    [JsonPropertyName("activityStartDateTimeInGMT")]
    public long ActivityStartDateTimeInGmt { get; init; }

    [JsonPropertyName("actStartDateTimeInGMTFormatted")]
    public DateTime? ActStartDateTimeInGmtFormatted { get; init; }

    [JsonPropertyName("activityStartDateTimeLocal")]
    public long? ActivityStartDateTimeLocal { get; init; }

    [JsonPropertyName("activityStartDateTimeLocalFormatted")]
    public DateTime? ActivityStartDateTimeLocalFormatted { get; init; }

    [JsonPropertyName("value")]
    public double Value { get; init; }

    [JsonPropertyName("prStartTimeGmt")]
    public long PrStartTimeGmt { get; init; }

    [JsonPropertyName("prStartTimeGmtFormatted")]
    public DateTime PrStartTimeGmtFormatted { get; init; }

    [JsonPropertyName("prStartTimeLocal")]
    public long PrStartTimeLocal { get; init; }

    [JsonPropertyName("prStartTimeLocalFormatted")]
    public DateTime? PrStartTimeLocalFormatted { get; init; }

    [JsonPropertyName("prTypeLabelKey")]
    public string PrTypeLabelKey { get; init; }

    [JsonPropertyName("poolLengthUnit")]
    public PoolLengthUnit PoolLengthUnit { get; init; }
}

public record PoolLengthUnit
{
    [JsonPropertyName("id")]
    public long Id { get; init; }

    [JsonPropertyName("key")]
    public string Key { get; init; }

    [JsonPropertyName("factor")]
    public double Factor { get; init; }
}