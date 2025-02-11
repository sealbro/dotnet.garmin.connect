using System;
using System.Text.Json.Serialization;
using Garmin.Connect.Converters;

namespace Garmin.Connect.Models.Internal;

internal record GarminWeightRequest
{
    [JsonPropertyName("dateTimestamp")]
    [JsonConverter(typeof(DateTimeConverter))]
    public DateTime DateTimestamp { get; init; }

    [JsonPropertyName("gmtTimestamp")]
    [JsonConverter(typeof(DateTimeConverter))]
    public DateTime GmtTimestamp { get; init; }

    [JsonPropertyName("unitKey")]
    public string UnitKey { get; init; }

    [JsonPropertyName("value")]
    public double Value { get; init; }
}