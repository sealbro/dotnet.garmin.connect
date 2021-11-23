using System;
using System.Text.Json.Serialization;

namespace Garmin.Connect.Models;

public record GarminStepsData
{
    [JsonPropertyName("startGMT")]
    public DateTime StartGmt { get; init; }

    [JsonPropertyName("endGMT")]
    public DateTime EndGmt { get; init; }

    [JsonPropertyName("steps")]
    public long Steps { get; init; }

    [JsonPropertyName("primaryActivityLevel")]
    public string PrimaryActivityLevel { get; init; }

    /// <summary>
    /// [active, sedentary, sleeping]
    /// </summary>
    [JsonPropertyName("activityLevelConstant")]
    public bool ActivityLevelConstant { get; init; }
}