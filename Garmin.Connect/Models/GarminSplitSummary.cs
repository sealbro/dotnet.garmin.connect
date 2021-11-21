using System.Text.Json.Serialization;

namespace Garmin.Connect.Models;

public class GarminSplitSummary
{
    [JsonPropertyName("activityId")]
    public long ActivityId { get; set; }

    [JsonPropertyName("activityUUID")]
    public GarminActivityUuid ActivityUuid { get; set; }

    [JsonPropertyName("splitSummaries")]
    public object[] SplitSummaries { get; set; }
}