using System.Text.Json.Serialization;

namespace Garmin.Connect.Models;

public class GarminActivityWeather
{
        [JsonPropertyName("issueDate")]
        public string IssueDate { get; set; }

        [JsonPropertyName("temp")]
        public long Temp { get; set; }

        [JsonPropertyName("apparentTemp")]
        public long ApparentTemp { get; set; }

        [JsonPropertyName("dewPoint")]
        public long DewPoint { get; set; }

        [JsonPropertyName("relativeHumidity")]
        public long RelativeHumidity { get; set; }

        [JsonPropertyName("windDirection")]
        public long WindDirection { get; set; }

        [JsonPropertyName("windDirectionCompassPoint")]
        public string WindDirectionCompassPoint { get; set; }

        [JsonPropertyName("windSpeed")]
        public long WindSpeed { get; set; }

        [JsonPropertyName("windGust")]
        public string WindGust { get; set; }

        [JsonPropertyName("latitude")]
        public double Latitude { get; set; }

        [JsonPropertyName("longitude")]
        public double Longitude { get; set; }

        [JsonPropertyName("weatherStationDTO")]
        public WeatherStationDto WeatherStationDto { get; set; }

        [JsonPropertyName("weatherTypeDTO")]
        public WeatherTypeDto WeatherTypeDto { get; set; }
}

public class WeatherStationDto
{
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("timezone")]
        public string Timezone { get; set; }
}

public class WeatherTypeDto
{
        [JsonPropertyName("weatherTypePk")]
        public string WeatherTypePk { get; set; }

        [JsonPropertyName("desc")]
        public string Desc { get; set; }

        [JsonPropertyName("image")]
        public string Image { get; set; }
}