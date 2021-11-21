using System.Text.Json.Serialization;

namespace Garmin.Connect.Models;

public class GarminUserPreferences
{
    [JsonPropertyName("displayName")]
    public string DisplayName { get; set; }

    [JsonPropertyName("preferredLocale")]
    public string PreferredLocale { get; set; }

    [JsonPropertyName("measurementSystem")]
    public string MeasurementSystem { get; set; }

    [JsonPropertyName("firstDayOfWeek")]
    public GarminFirstDayOfWeek FirstDayOfWeek { get; set; }

    [JsonPropertyName("numberFormat")]
    public string NumberFormat { get; set; }

    [JsonPropertyName("timeFormat")]
    public GarminFormat TimeFormat { get; set; }

    [JsonPropertyName("dateFormat")]
    public GarminFormat DateFormat { get; set; }

    [JsonPropertyName("powerFormat")]
    public GarminFormat PowerFormat { get; set; }

    [JsonPropertyName("heartRateFormat")]
    public GarminFormat HeartRateFormat { get; set; }

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