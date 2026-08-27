using System;
using System.Text.Json.Serialization;
using Garmin.Connect.Converters;

namespace Garmin.Connect.Models;

public record GarminWeeklyIntensityMinutes
{
    [JsonPropertyName("calendarDate")]
    [JsonConverter(typeof(DateOnlyConverter))]
    public DateOnly CalendarDate { get; init; }

    [JsonPropertyName("weeklyGoal")]
    public double WeeklyGoal { get; init; }

    [JsonPropertyName("moderateValue")]
    public double ModerateValue { get; init; }

    [JsonPropertyName("vigorousValue")]
    public double VigorousValue { get; init; }
}
