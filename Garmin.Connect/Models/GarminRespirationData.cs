using System;
using System.Text.Json.Serialization;
using Garmin.Connect.Converters;

namespace Garmin.Connect.Models;

public record GarminRespirationData
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

    [JsonPropertyName("lowestRespirationValue")]
    public double LowestRespirationValue { get; init; }

    [JsonPropertyName("highestRespirationValue")]
    public double HighestRespirationValue { get; init; }

    [JsonPropertyName("avgWakingRespirationValue")]
    public double AvgWakingRespirationValue { get; init; }

    [JsonPropertyName("avgSleepRespirationValue")]
    public double? AvgSleepRespirationValue { get; init; }

    [JsonPropertyName("avgTomorrowSleepRespirationValue")]
    public double? AvgTomorrowSleepRespirationValue { get; init; }

    [JsonPropertyName("respirationValueDescriptorsDTOList")]
    public GarminRespirationValueDescriptor[] RespirationValueDescriptorsDtoList { get; init; }

    [JsonPropertyName("respirationValuesArray")]
    public double?[][] RespirationValuesArray { get; init; }

    [JsonPropertyName("respirationVersion")]
    public double RespirationVersion { get; init; }
}

public record GarminRespirationValueDescriptor
{
    [JsonPropertyName("index")]
    public long Index { get; init; }

    [JsonPropertyName("key")]
    public string Key { get; init; }
}
