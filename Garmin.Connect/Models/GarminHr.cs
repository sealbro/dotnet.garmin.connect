using System;
using System.Text.Json.Serialization;

namespace Garmin.Connect.Models
{
    public class GarminHr
    {
        [JsonPropertyName("userProfilePK")]
        public long UserProfilePk { get; set; }

        [JsonPropertyName("calendarDate")]
        public DateTime CalendarDate { get; set; }

        [JsonPropertyName("startTimestampGMT")]
        public DateTime StartTimestampGmt { get; set; }

        [JsonPropertyName("endTimestampGMT")]
        public DateTime EndTimestampGmt { get; set; }

        [JsonPropertyName("startTimestampLocal")]
        public DateTime StartTimestampLocal { get; set; }

        [JsonPropertyName("endTimestampLocal")]
        public DateTime EndTimestampLocal { get; set; }

        [JsonPropertyName("maxHeartRate")]
        public long MaxHeartRate { get; set; }

        [JsonPropertyName("minHeartRate")]
        public long MinHeartRate { get; set; }

        [JsonPropertyName("restingHeartRate")]
        public long RestingHeartRate { get; set; }

        [JsonPropertyName("lastSevenDaysAvgRestingHeartRate")]
        public long LastSevenDaysAvgRestingHeartRate { get; set; }

        [JsonPropertyName("heartRateValueDescriptors")]
        public HeartRateValueDescriptor[] HeartRateValueDescriptors { get; set; }

        [JsonPropertyName("heartRateValues")]
        public long[][] HeartRateValues { get; set; }
    }

    public class HeartRateValueDescriptor
    {
        [JsonPropertyName("key")]
        public string Key { get; set; }

        [JsonPropertyName("index")]
        public long Index { get; set; }
    }
}