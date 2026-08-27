using System;
using System.Text.Json.Serialization;
using Garmin.Connect.Converters;

namespace Garmin.Connect.Models;

public record GarminAllDayStress
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

    [JsonPropertyName("maxStressLevel")]
    public double MaxStressLevel { get; init; }

    [JsonPropertyName("avgStressLevel")]
    public double AvgStressLevel { get; init; }

    [JsonPropertyName("stressChartValueOffset")]
    public double StressChartValueOffset { get; init; }

    [JsonPropertyName("stressChartYAxisOrigin")]
    public double StressChartYAxisOrigin { get; init; }

    [JsonPropertyName("stressValueDescriptorsDTOList")]
    public GarminStressValueDescriptor[] StressValueDescriptorsDtoList { get; init; }

    [JsonPropertyName("stressValuesArray")]
    public double?[][] StressValuesArray { get; init; }

    [JsonPropertyName("bodyBatteryValueDescriptorsDTOList")]
    public GarminAllDayBodyBatteryValueDescriptor[] BodyBatteryValueDescriptorsDtoList { get; init; }

    /// <summary>
    /// Heterogeneous tuples: [timestampMs, status ("RESET"/null/...), level, version].
    /// </summary>
    [JsonPropertyName("bodyBatteryValuesArray")]
    public object[][] BodyBatteryValuesArray { get; init; }
}

public record GarminStressValueDescriptor
{
    [JsonPropertyName("index")]
    public long Index { get; init; }

    [JsonPropertyName("key")]
    public string Key { get; init; }
}

public record GarminAllDayBodyBatteryValueDescriptor
{
    [JsonPropertyName("bodyBatteryValueDescriptorIndex")]
    public long BodyBatteryValueDescriptorIndex { get; init; }

    [JsonPropertyName("bodyBatteryValueDescriptorKey")]
    public string BodyBatteryValueDescriptorKey { get; init; }
}
