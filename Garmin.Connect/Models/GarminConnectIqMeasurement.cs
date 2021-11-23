using System.Text.Json.Serialization;

namespace Garmin.Connect.Models;

public record GarminConnectIqMeasurement
{
    [JsonPropertyName("appID")]
    public string AppId { get; init; }

    [JsonPropertyName("developerFieldNumber")]
    public long DeveloperFieldNumber { get; init; }

    [JsonPropertyName("value")]
    public string Value { get; init; }
}