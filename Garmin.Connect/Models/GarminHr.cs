using System;
using System.Text.Json.Serialization;

namespace Garmin.Connect.Models;

public record GarminHr
{
    [JsonPropertyName("userProfilePK")]
    public long UserProfilePk { get; init; }

    [JsonPropertyName("calendarDate")]
    public DateTime CalendarDate { get; init; }

    [JsonPropertyName("startTimestampGMT")]
    public DateTime StartTimestampGmt { get; init; }

    [JsonPropertyName("endTimestampGMT")]
    public DateTime EndTimestampGmt { get; init; }

    [JsonPropertyName("startTimestampLocal")]
    public DateTime StartTimestampLocal { get; init; }

    [JsonPropertyName("endTimestampLocal")]
    public DateTime EndTimestampLocal { get; init; }

    [JsonPropertyName("maxHeartRate")]
    public long MaxHeartRate { get; init; }

    [JsonPropertyName("minHeartRate")]
    public long MinHeartRate { get; init; }

    [JsonPropertyName("restingHeartRate")]
    public long RestingHeartRate { get; init; }

    [JsonPropertyName("lastSevenDaysAvgRestingHeartRate")]
    public long LastSevenDaysAvgRestingHeartRate { get; init; }

    [JsonPropertyName("heartRateValueDescriptors")]
    public HeartRateValueDescriptor[] HeartRateValueDescriptors { get; init; }

    [JsonPropertyName("heartRateValues")]
    public long[][] HeartRateValues { get; init; }
}

public record HeartRateValueDescriptor
{
    [JsonPropertyName("key")]
    public string Key { get; init; }

    [JsonPropertyName("index")]
    public long Index { get; init; }
}