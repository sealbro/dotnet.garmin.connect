using System;
using System.Text.Json.Serialization;
using Garmin.Connect.Converters;

namespace Garmin.Connect.Models;

public record GarminSpo2Data
{
    [JsonPropertyName("userProfilePK")]
    public long UserProfilePk { get; init; }

    [JsonPropertyName("calendarDate")]
    [JsonConverter(typeof(DateOnlyConverter))]
    public DateOnly CalendarDate { get; init; }

    [JsonPropertyName("startTimestampGMT")]
    [JsonConverter(typeof(DateTimeConverter))]
    public DateTime StartTimestampGmt { get; init; }

    [JsonPropertyName("endTimestampGMT")]
    [JsonConverter(typeof(DateTimeConverter))]
    public DateTime EndTimestampGmt { get; init; }

    [JsonPropertyName("startTimestampLocal")]
    [JsonConverter(typeof(DateTimeConverter))]
    public DateTime StartTimestampLocal { get; init; }

    [JsonPropertyName("endTimestampLocal")]
    [JsonConverter(typeof(DateTimeConverter))]
    public DateTime EndTimestampLocal { get; init; }

    [JsonPropertyName("averageSpO2")]
    public double? AverageSpo2 { get; init; }

    [JsonPropertyName("lowestSpO2")]
    public double? LowestSpo2 { get; init; }

    [JsonPropertyName("lastSevenDaysAvgSpO2")]
    public double? LastSevenDaysAvgSpo2 { get; init; }

    [JsonPropertyName("latestSpO2")]
    public double? LatestSpo2 { get; init; }

    [JsonPropertyName("latestSpO2TimestampGMT")]
    [JsonConverter(typeof(DateTimeConverter))]
    public DateTime LatestSpo2TimestampGmt { get; init; }

    [JsonPropertyName("latestSpO2TimestampLocal")]
    [JsonConverter(typeof(DateTimeConverter))]
    public DateTime LatestSpo2TimestampLocal { get; init; }

    [JsonPropertyName("avgSleepSpO2")]
    public double? AvgSleepSpo2 { get; init; }

    [JsonPropertyName("avgTomorrowSleepSpO2")]
    public double? AvgTomorrowSleepSpo2 { get; init; }
}
