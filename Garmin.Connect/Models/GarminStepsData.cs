using System;
using System.Text.Json.Serialization;

namespace Garmin.Connect.Models;

public class GarminStepsData
{
    [JsonPropertyName("startGMT")]
    public DateTime StartGmt { get; set; }

    [JsonPropertyName("endGMT")]
    public DateTime EndGmt { get; set; }

    [JsonPropertyName("steps")]
    public long Steps { get; set; }

    [JsonPropertyName("primaryActivityLevel")]
    public string PrimaryActivityLevel { get; set; }

    /// <summary>
    /// [active, sedentary, sleeping]
    /// </summary>
    [JsonPropertyName("activityLevelConstant")]
    public bool ActivityLevelConstant { get; set; }
}