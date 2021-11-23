using System.Text.Json.Serialization;

namespace Garmin.Connect.Models;

public record GarminUserPreferences
{
    [JsonPropertyName("displayName")]
    public string DisplayName { get; init; }

    [JsonPropertyName("preferredLocale")]
    public string PreferredLocale { get; init; }

    [JsonPropertyName("measurementSystem")]
    public string MeasurementSystem { get; init; }

    [JsonPropertyName("firstDayOfWeek")]
    public GarminFirstDayOfWeek FirstDayOfWeek { get; init; }

    [JsonPropertyName("numberFormat")]
    public string NumberFormat { get; init; }

    [JsonPropertyName("timeFormat")]
    public GarminFormat TimeFormat { get; init; }

    [JsonPropertyName("dateFormat")]
    public GarminFormat DateFormat { get; init; }

    [JsonPropertyName("powerFormat")]
    public GarminFormat PowerFormat { get; init; }

    [JsonPropertyName("heartRateFormat")]
    public GarminFormat HeartRateFormat { get; init; }

    [JsonPropertyName("timeZone")]
    public string TimeZone { get; init; }

    [JsonPropertyName("hydrationMeasurementUnit")]
    public string HydrationMeasurementUnit { get; init; }

    [JsonPropertyName("hydrationContainers")]
    public object[] HydrationContainers { get; init; }

    [JsonPropertyName("golfDistanceUnit")]
    public string GolfDistanceUnit { get; init; }

    [JsonPropertyName("golfElevationUnit")]
    public object GolfElevationUnit { get; init; }

    [JsonPropertyName("golfSpeedUnit")]
    public object GolfSpeedUnit { get; init; }
}