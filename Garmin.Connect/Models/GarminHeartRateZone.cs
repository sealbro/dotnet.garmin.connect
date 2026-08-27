using System.Text.Json.Serialization;

namespace Garmin.Connect.Models;

public record GarminHeartRateZone
{
    [JsonPropertyName("trainingMethod")]
    public string TrainingMethod { get; init; }

    [JsonPropertyName("restingHeartRateUsed")]
    public double? RestingHeartRateUsed { get; init; }

    [JsonPropertyName("lactateThresholdHeartRateUsed")]
    public double LactateThresholdHeartRateUsed { get; init; }

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

    [JsonPropertyName("maxHeartRateUsed")]
    public double MaxHeartRateUsed { get; init; }

    [JsonPropertyName("restingHrAutoUpdateUsed")]
    public bool RestingHrAutoUpdateUsed { get; init; }

    [JsonPropertyName("sport")]
    public string Sport { get; init; }

    [JsonPropertyName("changeState")]
    public string ChangeState { get; init; }
}
