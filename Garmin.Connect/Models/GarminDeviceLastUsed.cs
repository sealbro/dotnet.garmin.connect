using System.Text.Json.Serialization;

namespace Garmin.Connect.Models
{
    public class GarminDeviceLastUsed
    {
        [JsonPropertyName("userDeviceId")]
        public long UserDeviceId { get; set; }

        [JsonPropertyName("userProfileNumber")]
        public long UserProfileNumber { get; set; }

        [JsonPropertyName("applicationNumber")]
        public long ApplicationNumber { get; set; }

        [JsonPropertyName("lastUsedDeviceApplicationKey")]
        public string LastUsedDeviceApplicationKey { get; set; }

        [JsonPropertyName("lastUsedDeviceName")]
        public string LastUsedDeviceName { get; set; }

        [JsonPropertyName("lastUsedDeviceUploadTime")]
        public long LastUsedDeviceUploadTime { get; set; }

        [JsonPropertyName("imageUrl")]
        public string ImageUrl { get; set; }

        [JsonPropertyName("released")]
        public bool Released { get; set; }
    }
}