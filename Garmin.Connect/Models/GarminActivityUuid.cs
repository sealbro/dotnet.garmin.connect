using System.Text.Json.Serialization;

namespace Garmin.Connect.Models;

public record GarminActivityUuid
{
    [JsonPropertyName("uuid")]
    public string Uuid { get; init; }
}