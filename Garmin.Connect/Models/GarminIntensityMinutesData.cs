using System;
using System.Text.Json.Serialization;
using Garmin.Connect.Converters;

namespace Garmin.Connect.Models;

public record GarminIntensityMinutesData
{
    [JsonPropertyName("userProfilePK")]
    public long UserProfilePk { get; init; }

    [JsonPropertyName("calendarDate")]
    [JsonConverter(typeof(DateOnlyConverter))]
    public DateOnly CalendarDate { get; init; }

    [JsonPropertyName("startTimestampGMT")]
    [JsonConverter(typeof(DateTimeConverter))]
    public DateTime StartTimestampGmt { get; init; }

    [JsonPropertyName("endTimestampGMT")]
    [JsonConverter(typeof(DateTimeConverter))]
    public DateTime EndTimestampGmt { get; init; }

    [JsonPropertyName("startTimestampLocal")]
    [JsonConverter(typeof(DateTimeConverter))]
    public DateTime StartTimestampLocal { get; init; }

    [JsonPropertyName("endTimestampLocal")]
    [JsonConverter(typeof(DateTimeConverter))]
    public DateTime EndTimestampLocal { get; init; }

    [JsonPropertyName("weeklyModerate")]
    public double WeeklyModerate { get; init; }

    [JsonPropertyName("weeklyVigorous")]
    public double WeeklyVigorous { get; init; }

    [JsonPropertyName("weeklyTotal")]
    public double WeeklyTotal { get; init; }

    [JsonPropertyName("weekGoal")]
    public double WeekGoal { get; init; }

    [JsonPropertyName("startDayMinutes")]
    public double StartDayMinutes { get; init; }

    [JsonPropertyName("endDayMinutes")]
    public double EndDayMinutes { get; init; }

    [JsonPropertyName("moderateMinutes")]
    public double ModerateMinutes { get; init; }

    [JsonPropertyName("vigorousMinutes")]
    public double VigorousMinutes { get; init; }
}
