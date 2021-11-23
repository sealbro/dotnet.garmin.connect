using System.Text.Json.Serialization;

namespace Garmin.Connect.Models;

public record GarminDeviceLastUsed
{
    [JsonPropertyName("userDeviceId")]
    public long UserDeviceId { get; init; }

    [JsonPropertyName("userProfileNumber")]
    public long UserProfileNumber { get; init; }

    [JsonPropertyName("applicationNumber")]
    public long ApplicationNumber { get; init; }

    [JsonPropertyName("lastUsedDeviceApplicationKey")]
    public string LastUsedDeviceApplicationKey { get; init; }

    [JsonPropertyName("lastUsedDeviceName")]
    public string LastUsedDeviceName { get; init; }

    [JsonPropertyName("lastUsedDeviceUploadTime")]
    public long LastUsedDeviceUploadTime { get; init; }

    [JsonPropertyName("imageUrl")]
    public string ImageUrl { get; init; }

    [JsonPropertyName("released")]
    public bool Released { get; init; }
}