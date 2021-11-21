using System.Text.Json.Serialization;

namespace Garmin.Connect.Models;

public class GarminHrTimeInZones
{
    [JsonPropertyName("zoneNumber")]
    public long ZoneNumber { get; set; }

    [JsonPropertyName("secsInZone")]
    public double SecsInZone { get; set; }

    [JsonPropertyName("zoneLowBoundary")]
    public long ZoneLowBoundary { get; set; }
}