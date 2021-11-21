using System.Text.Json.Serialization;

namespace Garmin.Connect.Models;

public class GarminActivityUuid
{
    [JsonPropertyName("uuid")]
    public string Uuid { get; set; }
}