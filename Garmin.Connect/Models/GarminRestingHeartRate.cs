using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Garmin.Connect.Converters;

namespace Garmin.Connect.Models;

public record GarminRestingHeartRate
{
    [JsonPropertyName("userProfileId")]
    public long UserProfileId { get; init; }

    [JsonPropertyName("statisticsStartDate")]
    [JsonConverter(typeof(DateOnlyConverter))]
    public DateOnly StatisticsStartDate { get; init; }

    [JsonPropertyName("statisticsEndDate")]
    [JsonConverter(typeof(DateOnlyConverter))]
    public DateOnly StatisticsEndDate { get; init; }

    [JsonPropertyName("allMetrics")]
    public GarminRestingHeartRateMetrics AllMetrics { get; init; }
}

public record GarminRestingHeartRateMetrics
{
    [JsonPropertyName("metricsMap")]
    public Dictionary<string, GarminRestingHeartRateEntry[]> MetricsMap { get; init; }
}

public record GarminRestingHeartRateEntry
{
    [JsonPropertyName("value")]
    public double Value { get; init; }

    [JsonPropertyName("calendarDate")]
    [JsonConverter(typeof(DateOnlyConverter))]
    public DateOnly CalendarDate { get; init; }
}
