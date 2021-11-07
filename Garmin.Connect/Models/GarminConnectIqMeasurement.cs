using System.Text.Json.Serialization;

namespace Garmin.Connect.Models
{
    public class GarminConnectIqMeasurement
    {
        [JsonPropertyName("appID")]
        public string AppId { get; set; }

        [JsonPropertyName("developerFieldNumber")]
        public long DeveloperFieldNumber { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }
    }
}