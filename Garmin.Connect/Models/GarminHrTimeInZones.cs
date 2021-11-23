using System.Text.Json.Serialization;

namespace Garmin.Connect.Models;

public record GarminHrTimeInZones
{
    [JsonPropertyName("zoneNumber")]
    public long ZoneNumber { get; init; }

    [JsonPropertyName("secsInZone")]
    public double SecsInZone { get; init; }

    [JsonPropertyName("zoneLowBoundary")]
    public long ZoneLowBoundary { get; init; }
}