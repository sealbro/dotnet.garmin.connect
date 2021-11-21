using System;
using System.Text.Json.Serialization;

namespace Garmin.Connect.Models;

public class GarminPersonalRecord
{
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("typeId")]
    public long TypeId { get; set; }

    [JsonPropertyName("activityId")]
    public long ActivityId { get; set; }

    [JsonPropertyName("activityName")]
    public string ActivityName { get; set; }

    [JsonPropertyName("activityStartDateTimeInGMT")]
    public long ActivityStartDateTimeInGmt { get; set; }

    [JsonPropertyName("actStartDateTimeInGMTFormatted")]
    public DateTime? ActStartDateTimeInGmtFormatted { get; set; }

    [JsonPropertyName("activityStartDateTimeLocal")]
    public long? ActivityStartDateTimeLocal { get; set; }

    [JsonPropertyName("activityStartDateTimeLocalFormatted")]
    public DateTime? ActivityStartDateTimeLocalFormatted { get; set; }

    [JsonPropertyName("value")]
    public double Value { get; set; }

    [JsonPropertyName("prStartTimeGmt")]
    public long PrStartTimeGmt { get; set; }

    [JsonPropertyName("prStartTimeGmtFormatted")]
    public DateTime PrStartTimeGmtFormatted { get; set; }

    [JsonPropertyName("prStartTimeLocal")]
    public long PrStartTimeLocal { get; set; }

    [JsonPropertyName("prStartTimeLocalFormatted")]
    public DateTime? PrStartTimeLocalFormatted { get; set; }

    [JsonPropertyName("prTypeLabelKey")]
    public string PrTypeLabelKey { get; set; }

    [JsonPropertyName("poolLengthUnit")]
    public PoolLengthUnit PoolLengthUnit { get; set; }
}

public class PoolLengthUnit
{
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("key")]
    public string Key { get; set; }

    [JsonPropertyName("factor")]
    public double Factor { get; set; }
}