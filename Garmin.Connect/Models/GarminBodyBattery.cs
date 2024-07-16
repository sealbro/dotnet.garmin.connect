using System;
using System.Text.Json.Serialization;

namespace Garmin.Connect.Models;

public record GarminBodyBatteryData
{
	[JsonPropertyName("date")]
	public DateTime Date { get; set; }

	[JsonPropertyName("charged")]
	public long Charged { get; set; }

	[JsonPropertyName("drained")]
	public long Drained { get; set; }

	[JsonPropertyName("startTimestampGMT")]
	public DateTime StartTimestampGmt { get; set; }

	[JsonPropertyName("endTimestampGMT")]
	public DateTime EndTimestampGmt { get; set; }

	[JsonPropertyName("startTimestampLocal")]
	public DateTime StartTimestampLocal { get; set; }

	[JsonPropertyName("endTimestampLocal")]
	public DateTime EndTimestampLocal { get; set; }

	[JsonPropertyName("bodyBatteryValuesArray")]
	public long[][] BodyBatteryValuesArray { get; set; }

	[JsonPropertyName("bodyBatteryValueDescriptorDTOList")]
	public BodyBatteryValueDescriptorDtoList[] BodyBatteryValueDescriptorDtoList { get; set; }

	[JsonPropertyName("bodyBatteryDynamicFeedbackEvent")]
	public BodyBatteryDynamicFeedbackEvent BodyBatteryDynamicFeedbackEvent { get; set; }

	[JsonPropertyName("bodyBatteryActivityEvent")]
	public BodyBatteryActivityEvent[] BodyBatteryActivityEvent { get; set; }

	[JsonPropertyName("endOfDayBodyBatteryDynamicFeedbackEvent")]
	public BodyBatteryDynamicFeedbackEvent EndOfDayBodyBatteryDynamicFeedbackEvent { get; set; }
}

public record BodyBatteryActivityEvent
{
	[JsonPropertyName("eventType")]
	public string EventType { get; set; }

	[JsonPropertyName("eventStartTimeGmt")]
	public DateTime EventStartTimeGmt { get; set; }

	[JsonPropertyName("timezoneOffset")]
	public long TimezoneOffset { get; set; }

	[JsonPropertyName("durationInMilliseconds")]
	public long DurationInMilliseconds { get; set; }

	[JsonPropertyName("bodyBatteryImpact")]
	public long BodyBatteryImpact { get; set; }

	[JsonPropertyName("feedbackType")]
	public string FeedbackType { get; set; }

	[JsonPropertyName("shortFeedback")]
	public string ShortFeedback { get; set; }
}

public record BodyBatteryDynamicFeedbackEvent
{
	[JsonPropertyName("eventTimestampGmt")]
	public DateTime EventTimestampGmt { get; set; }

	[JsonPropertyName("bodyBatteryLevel")]
	public string BodyBatteryLevel { get; set; }

	[JsonPropertyName("feedbackShortType")]
	public string FeedbackShortType { get; set; }

	[JsonPropertyName("feedbackLongType")]
	public string FeedbackLongType { get; set; }
}

public record BodyBatteryValueDescriptorDtoList
{
	[JsonPropertyName("bodyBatteryValueDescriptorIndex")]
	public long BodyBatteryValueDescriptorIndex { get; set; }

	[JsonPropertyName("bodyBatteryValueDescriptorKey")]
	public string BodyBatteryValueDescriptorKey { get; set; }
}