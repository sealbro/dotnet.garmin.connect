using System;
using System.Text.Json.Serialization;

namespace Garmin.Connect.Models
{
    public class GarminHydrationData
    {
        [JsonPropertyName("userId")]
        public long UserId { get; set; }

        [JsonPropertyName("calendarDate")]
        public DateTime CalendarDate { get; set; }

        [JsonPropertyName("valueInML")]
        public object ValueInMl { get; set; }

        [JsonPropertyName("goalInML")]
        public double GoalInMl { get; set; }

        [JsonPropertyName("dailyAverageinML")]
        public object DailyAverageinMl { get; set; }

        [JsonPropertyName("lastEntryTimestampLocal")]
        public object LastEntryTimestampLocal { get; set; }

        [JsonPropertyName("sweatLossInML")]
        public object SweatLossInMl { get; set; }

        [JsonPropertyName("activityIntakeInML")]
        public object ActivityIntakeInMl { get; set; }
    }
}