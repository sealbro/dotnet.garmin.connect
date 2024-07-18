using System;
using System.Text.Json.Serialization;

namespace Garmin.Connect.Models;

public record GarminBodyBatteryData
{
    [JsonPropertyName("date")]
    public DateTime Date { get; init; }

    [JsonPropertyName("charged")]
    public long Charged { get; init; }

    [JsonPropertyName("drained")]
    public long Drained { get; init; }

    [JsonPropertyName("startTimestampGMT")]
    public DateTime StartTimestampGmt { get; init; }

    [JsonPropertyName("endTimestampGMT")]
    public DateTime EndTimestampGmt { get; init; }

    [JsonPropertyName("startTimestampLocal")]
    public DateTime StartTimestampLocal { get; init; }

    [JsonPropertyName("endTimestampLocal")]
    public DateTime EndTimestampLocal { get; init; }

    [JsonPropertyName("bodyBatteryValuesArray")]
    public long[][] BodyBatteryValuesArray { get; init; }

    [JsonPropertyName("bodyBatteryValueDescriptorDTOList")]
    public BodyBatteryValueDescriptorDtoList[] BodyBatteryValueDescriptorDtoList { get; init; }

    [JsonPropertyName("bodyBatteryDynamicFeedbackEvent")]
    public BodyBatteryDynamicFeedbackEvent BodyBatteryDynamicFeedbackEvent { get; init; }

    [JsonPropertyName("bodyBatteryActivityEvent")]
    public BodyBatteryActivityEvent[] BodyBatteryActivityEvent { get; init; }

    [JsonPropertyName("endOfDayBodyBatteryDynamicFeedbackEvent")]
    public BodyBatteryDynamicFeedbackEvent EndOfDayBodyBatteryDynamicFeedbackEvent { get; init; }
}

public record BodyBatteryActivityEvent
{
    [JsonPropertyName("eventType")]
    public string EventType { get; init; }

    [JsonPropertyName("eventStartTimeGmt")]
    public DateTime EventStartTimeGmt { get; init; }

    [JsonPropertyName("timezoneOffset")]
    public long TimezoneOffset { get; init; }

    [JsonPropertyName("durationInMilliseconds")]
    public long DurationInMilliseconds { get; init; }

    [JsonPropertyName("bodyBatteryImpact")]
    public long BodyBatteryImpact { get; init; }

    [JsonPropertyName("feedbackType")]
    public string FeedbackType { get; init; }

    [JsonPropertyName("shortFeedback")]
    public string ShortFeedback { get; init; }
}

public record BodyBatteryDynamicFeedbackEvent
{
    [JsonPropertyName("eventTimestampGmt")]
    public DateTime EventTimestampGmt { get; init; }

    [JsonPropertyName("bodyBatteryLevel")]
    public string BodyBatteryLevel { get; init; }

    [JsonPropertyName("feedbackShortType")]
    public string FeedbackShortType { get; init; }

    [JsonPropertyName("feedbackLongType")]
    public string FeedbackLongType { get; init; }
}

public record BodyBatteryValueDescriptorDtoList
{
    [JsonPropertyName("bodyBatteryValueDescriptorIndex")]
    public long BodyBatteryValueDescriptorIndex { get; init; }

    [JsonPropertyName("bodyBatteryValueDescriptorKey")]
    public string BodyBatteryValueDescriptorKey { get; init; }
}