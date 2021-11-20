using System.Text.Json.Serialization;

namespace Garmin.Connect.Models;

public class GarminFormat
{
    [JsonPropertyName("formatId")]
    public long FormatId { get; set; }

    [JsonPropertyName("formatKey")]
    public string FormatKey { get; set; }

    [JsonPropertyName("minFraction")]
    public long MinFraction { get; set; }

    [JsonPropertyName("maxFraction")]
    public long MaxFraction { get; set; }

    [JsonPropertyName("groupingUsed")]
    public bool GroupingUsed { get; set; }

    [JsonPropertyName("displayFormat")]
    public string DisplayFormat { get; set; }
}