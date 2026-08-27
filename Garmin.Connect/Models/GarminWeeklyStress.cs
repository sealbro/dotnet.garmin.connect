using System;
using System.Text.Json.Serialization;
using Garmin.Connect.Converters;

namespace Garmin.Connect.Models;

public record GarminWeeklyStress
{
    [JsonPropertyName("calendarDate")]
    [JsonConverter(typeof(DateOnlyConverter))]
    public DateOnly CalendarDate { get; init; }

    [JsonPropertyName("value")]
    public double Value { get; init; }
}
