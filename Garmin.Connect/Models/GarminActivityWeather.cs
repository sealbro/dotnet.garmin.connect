using System;
using System.Text.Json.Serialization;
using Garmin.Connect.Converters;

namespace Garmin.Connect.Models;

public record GarminActivityWeather
{
    [JsonPropertyName("issueDate")]
    [JsonConverter(typeof(DateTimeConverter))]
    public DateTime IssueDate { get; init; }

    [JsonPropertyName("temp")]
    public long Temp { get; init; }

    [JsonPropertyName("apparentTemp")]
    public long ApparentTemp { get; init; }

    [JsonPropertyName("dewPoint")]
    public long DewPoint { get; init; }

    [JsonPropertyName("relativeHumidity")]
    public long RelativeHumidity { get; init; }

    [JsonPropertyName("windDirection")]
    public long WindDirection { get; init; }

    [JsonPropertyName("windDirectionCompassPoint")]
    public string WindDirectionCompassPoint { get; init; }

    [JsonPropertyName("windSpeed")]
    public long WindSpeed { get; init; }

    [JsonPropertyName("windGust")]
    public string WindGust { get; init; }

    [JsonPropertyName("latitude")]
    public double Latitude { get; init; }

    [JsonPropertyName("longitude")]
    public double Longitude { get; init; }

    [JsonPropertyName("weatherStationDTO")]
    public WeatherStationDto WeatherStationDto { get; init; }

    [JsonPropertyName("weatherTypeDTO")]
    public WeatherTypeDto WeatherTypeDto { get; init; }
}

public record WeatherStationDto
{
    [JsonPropertyName("id")]
    public string Id { get; init; }

    [JsonPropertyName("name")]
    public string Name { get; init; }

    [JsonPropertyName("timezone")]
    public string Timezone { get; init; }
}

public record WeatherTypeDto
{
    [JsonPropertyName("weatherTypePk")]
    public string WeatherTypePk { get; init; }

    [JsonPropertyName("desc")]
    public string Desc { get; init; }

    [JsonPropertyName("image")]
    public string Image { get; init; }
}