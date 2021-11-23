using System.Text.Json.Serialization;

namespace Garmin.Connect.Models;

public record GarminSplitSummary
{
    [JsonPropertyName("activityId")]
    public long ActivityId { get; init; }

    [JsonPropertyName("activityUUID")]
    public GarminActivityUuid ActivityUuid { get; init; }

    [JsonPropertyName("splitSummaries")]
    public object[] SplitSummaries { get; init; }
}