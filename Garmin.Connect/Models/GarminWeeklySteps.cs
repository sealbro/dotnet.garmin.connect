using System;
using System.Text.Json.Serialization;
using Garmin.Connect.Converters;

namespace Garmin.Connect.Models;

public record GarminWeeklySteps
{
    [JsonPropertyName("calendarDate")]
    [JsonConverter(typeof(DateOnlyConverter))]
    public DateOnly CalendarDate { get; init; }

    [JsonPropertyName("values")]
    public GarminWeeklyStepsValues Values { get; init; }
}

public record GarminWeeklyStepsValues
{
    [JsonPropertyName("totalSteps")]
    public double TotalSteps { get; init; }

    [JsonPropertyName("averageSteps")]
    public double AverageSteps { get; init; }

    [JsonPropertyName("wellnessDataDaysCount")]
    public double WellnessDataDaysCount { get; init; }

    [JsonPropertyName("averageDistance")]
    public double AverageDistance { get; init; }

    [JsonPropertyName("totalDistance")]
    public double TotalDistance { get; init; }
}
