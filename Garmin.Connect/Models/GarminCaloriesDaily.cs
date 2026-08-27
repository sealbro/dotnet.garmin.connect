using System;
using System.Text.Json.Serialization;
using Garmin.Connect.Converters;

namespace Garmin.Connect.Models;

public record GarminCaloriesDaily
{
    [JsonPropertyName("calendarDate")]
    [JsonConverter(typeof(DateOnlyConverter))]
    public DateOnly CalendarDate { get; init; }

    [JsonPropertyName("values")]
    public GarminCaloriesDailyValues Values { get; init; }
}

public record GarminCaloriesDailyValues
{
    [JsonPropertyName("restingCalories")]
    public double RestingCalories { get; init; }

    [JsonPropertyName("totalCalories")]
    public double TotalCalories { get; init; }

    [JsonPropertyName("activeCalories")]
    public double ActiveCalories { get; init; }
}
