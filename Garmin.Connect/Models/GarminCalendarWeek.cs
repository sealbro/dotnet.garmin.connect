using System;
using System.Text.Json.Serialization;
using Garmin.Connect.Converters;

namespace Garmin.Connect.Models;

public record GarminCalendarWeek
{
    [JsonPropertyName("startDate")]
    [JsonConverter(typeof(DateOnlyConverter))]
    public DateOnly StartDate { get; init; }

    [JsonPropertyName("endDate")]
    [JsonConverter(typeof(DateOnlyConverter))]
    public DateOnly EndDate { get; init; }

    [JsonPropertyName("numOfDaysInMonth")]
    public int NumOfDaysInMonth { get; init; }

    [JsonPropertyName("calendarItems")]
    public GarminCalendarItem[] CalendarItems { get; init; }
}
