using System.Text.Json.Serialization;

namespace Garmin.Connect.Models;

public record GarminPowerZone
{
    [JsonPropertyName("sport")]
    public string Sport { get; init; }

    [JsonPropertyName("functionalThresholdPower")]
    public double FunctionalThresholdPower { get; init; }

    [JsonPropertyName("zone1Floor")]
    public double Zone1Floor { get; init; }

    [JsonPropertyName("zone2Floor")]
    public double Zone2Floor { get; init; }

    [JsonPropertyName("zone3Floor")]
    public double Zone3Floor { get; init; }

    [JsonPropertyName("zone4Floor")]
    public double Zone4Floor { get; init; }

    [JsonPropertyName("zone5Floor")]
    public double Zone5Floor { get; init; }

    [JsonPropertyName("zone6Floor")]
    public double Zone6Floor { get; init; }

    [JsonPropertyName("zone7Floor")]
    public double Zone7Floor { get; init; }
}
