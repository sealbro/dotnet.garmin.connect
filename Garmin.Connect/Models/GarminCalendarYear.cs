using System;
using System.Text.Json.Serialization;
using Garmin.Connect.Converters;

namespace Garmin.Connect.Models;

public record GarminCalendarYear
{
    [JsonPropertyName("startDayOfJanuary")]
    public int StartDayOfJanuary { get; init; }

    [JsonPropertyName("leapYear")]
    public bool LeapYear { get; init; }

    [JsonPropertyName("yearItems")]
    public GarminYearItem[] YearItems { get; init; }

    [JsonPropertyName("yearSummaries")]
    public GarminYearSummary[] YearSummaries { get; init; }
}

public record GarminYearItem
{
    [JsonPropertyName("date")]
    [JsonConverter(typeof(DateOnlyConverter))]
    public DateOnly Date { get; init; }

    [JsonPropertyName("display")]
    public long Display { get; init; }
}

public record GarminYearSummary
{
    [JsonPropertyName("activityTypeId")]
    public long ActivityTypeId { get; init; }

    [JsonPropertyName("numberOfActivities")]
    public int NumberOfActivities { get; init; }

    [JsonPropertyName("totalDistance")]
    public double TotalDistance { get; init; }

    [JsonPropertyName("totalDuration")]
    public double TotalDuration { get; init; }

    [JsonPropertyName("totalCalories")]
    public double TotalCalories { get; init; }
}
