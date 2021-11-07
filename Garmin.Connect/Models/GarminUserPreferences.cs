using System.Text.Json.Serialization;

namespace Garmin.Connect.Models
{
    public class GarminUserPreferences
    {
        [JsonPropertyName("displayName")]
        public string DisplayName { get; set; }

        [JsonPropertyName("preferredLocale")]
        public string PreferredLocale { get; set; }

        [JsonPropertyName("measurementSystem")]
        public string MeasurementSystem { get; set; }

        [JsonPropertyName("firstDayOfWeek")]
        public FirstDayOfWeek FirstDayOfWeek { get; set; }

        [JsonPropertyName("numberFormat")]
        public string NumberFormat { get; set; }

        [JsonPropertyName("timeFormat")]
        public Format TimeFormat { get; set; }

        [JsonPropertyName("dateFormat")]
        public Format DateFormat { get; set; }

        [JsonPropertyName("powerFormat")]
        public Format PowerFormat { get; set; }

        [JsonPropertyName("heartRateFormat")]
        public Format HeartRateFormat { get; set; }

        [JsonPropertyName("timeZone")]
        public string TimeZone { get; set; }

        [JsonPropertyName("hydrationMeasurementUnit")]
        public string HydrationMeasurementUnit { get; set; }

        [JsonPropertyName("hydrationContainers")]
        public object[] HydrationContainers { get; set; }

        [JsonPropertyName("golfDistanceUnit")]
        public string GolfDistanceUnit { get; set; }

        [JsonPropertyName("golfElevationUnit")]
        public object GolfElevationUnit { get; set; }

        [JsonPropertyName("golfSpeedUnit")]
        public object GolfSpeedUnit { get; set; }
    }

    public class Format
    {
        [JsonPropertyName("formatId")]
        public long FormatId { get; set; }

        [JsonPropertyName("formatKey")]
        public string FormatKey { get; set; }

        [JsonPropertyName("minFraction")]
        public long MinFraction { get; set; }

        [JsonPropertyName("maxFraction")]
        public long MaxFraction { get; set; }

        [JsonPropertyName("groupingUsed")]
        public bool GroupingUsed { get; set; }

        [JsonPropertyName("displayFormat")]
        public string DisplayFormat { get; set; }
    }

    public class FirstDayOfWeek
    {
        [JsonPropertyName("dayId")]
        public long DayId { get; set; }

        [JsonPropertyName("dayName")]
        public string DayName { get; set; }

        [JsonPropertyName("sortOrder")]
        public long SortOrder { get; set; }

        [JsonPropertyName("isPossibleFirstDay")]
        public bool IsPossibleFirstDay { get; set; }
    }
}