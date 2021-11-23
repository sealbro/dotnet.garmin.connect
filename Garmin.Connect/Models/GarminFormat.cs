using System.Text.Json.Serialization;

namespace Garmin.Connect.Models;

public record GarminFormat
{
    [JsonPropertyName("formatId")]
    public long FormatId { get; init; }

    [JsonPropertyName("formatKey")]
    public string FormatKey { get; init; }

    [JsonPropertyName("minFraction")]
    public long MinFraction { get; init; }

    [JsonPropertyName("maxFraction")]
    public long MaxFraction { get; init; }

    [JsonPropertyName("groupingUsed")]
    public bool GroupingUsed { get; init; }

    [JsonPropertyName("displayFormat")]
    public string DisplayFormat { get; init; }
}