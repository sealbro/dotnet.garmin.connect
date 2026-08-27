using System;
using System.Text.Json.Serialization;
using Garmin.Connect.Converters;

namespace Garmin.Connect.Models;

public record GarminAllDayEvent
{
    [JsonPropertyName("userProfilePk")]
    public long UserProfilePk { get; init; }

    [JsonPropertyName("deviceId")]
    public long DeviceId { get; init; }

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

    [JsonPropertyName("duration")]
    public double Duration { get; init; }

    [JsonPropertyName("activityType")]
    public string ActivityType { get; init; }

    [JsonPropertyName("activitySubType")]
    public string ActivitySubType { get; init; }
}
