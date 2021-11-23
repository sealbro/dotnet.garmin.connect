using System;
using System.Text.Json.Serialization;

namespace Garmin.Connect.Models;

public record GarminHydrationData
{
    [JsonPropertyName("userId")]
    public long UserId { get; init; }

    [JsonPropertyName("calendarDate")]
    public DateTime CalendarDate { get; init; }

    [JsonPropertyName("valueInML")]
    public object ValueInMl { get; init; }

    [JsonPropertyName("goalInML")]
    public double GoalInMl { get; init; }

    [JsonPropertyName("dailyAverageinML")]
    public object DailyAverageinMl { get; init; }

    [JsonPropertyName("lastEntryTimestampLocal")]
    public object LastEntryTimestampLocal { get; init; }

    [JsonPropertyName("sweatLossInML")]
    public object SweatLossInMl { get; init; }

    [JsonPropertyName("activityIntakeInML")]
    public object ActivityIntakeInMl { get; init; }
}