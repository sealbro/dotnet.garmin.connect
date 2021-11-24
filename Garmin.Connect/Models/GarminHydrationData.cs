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
    public int ValueInMl { get; init; }

    [JsonPropertyName("goalInML")]
    public double GoalInMl { get; init; }

    [JsonPropertyName("dailyAverageinML")]
    public double DailyAverageinMl { get; init; }

    [JsonPropertyName("lastEntryTimestampLocal")]
    public DateTime? LastEntryTimestampLocal { get; init; }

    [JsonPropertyName("sweatLossInML")]
    public double SweatLossInMl { get; init; }

    [JsonPropertyName("activityIntakeInML")]
    public double ActivityIntakeInMl { get; init; }
}