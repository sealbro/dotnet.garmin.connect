using System;
using System.Text.Json.Serialization;

namespace Garmin.Connect.Models
{
    public record GarminHrvSummaries
    {
        [JsonPropertyName("hrvSummaries")]
        public GarminHrvSummary[] HrvSummaries { get; init; }
        [JsonPropertyName("userProfilePk")]
        public long UserProfilePk { get; init; }
    }

    public record GarminHrvSummary
    {
        [JsonPropertyName("calendarDate")]
        public DateTime CalendarDate { get; init; }

        [JsonPropertyName("weeklyAvg")]
        public int WeeklyAvg { get; init; }

        [JsonPropertyName("lastNightAvg")]
        public int LastNightAvg { get; init; }

        [JsonPropertyName("lastNight5MinHigh")]
        public int LastNight5MinHigh { get; init; }
        [JsonPropertyName("baseline")]
        public GarminHrvBaseline Baseline { get; init; }
        [JsonPropertyName("status")]
        public string Status { get; init; }

        [JsonPropertyName("feedbackPhrase")]
        public string FeedbackPhrase { get; init; }
        [JsonPropertyName("createTimeStamp")]
        public DateTime CreateTimeStamp { get; init; }
    }

    public record GarminHrvBaseline
    {
        [JsonPropertyName("lowUpper")]
        public int LowUpper { get; init; }

        [JsonPropertyName("balancedLow")]
        public int BalancedLow { get; init; }

        [JsonPropertyName("balancedUpper")]
        public int BalancedUpper { get; init; }

        [JsonPropertyName("markerValue")]
        public double MarkerValue { get; init; }
    }
}
