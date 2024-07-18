using System;
using System.Text.Json.Serialization;

namespace Garmin.Connect.Models;

public record GarminUserSettings
{
    [JsonPropertyName("id")]
    public long Id { get; init; }

    [JsonPropertyName("userData")]
    public UserData UserData { get; init; }

    [JsonPropertyName("userSleep")]
    public UserSleep UserSleep { get; init; }

    [JsonPropertyName("connectDate")]
    public object ConnectDate { get; init; }

    [JsonPropertyName("sourceType")]
    public object SourceType { get; init; }
}

public record UserData
{
    [JsonPropertyName("gender")]
    public string Gender { get; init; }

    [JsonPropertyName("weight")]
    public double Weight { get; init; }

    [JsonPropertyName("height")]
    public double Height { get; init; }

    [JsonPropertyName("timeFormat")]
    public string TimeFormat { get; init; }

    [JsonPropertyName("birthDate")]
    public DateTime BirthDate { get; init; }

    [JsonPropertyName("measurementSystem")]
    public string MeasurementSystem { get; init; }

    [JsonPropertyName("activityLevel")]
    public long ActivityLevel { get; init; }

    [JsonPropertyName("handedness")]
    public string Handedness { get; init; }

    [JsonPropertyName("powerFormat")]
    public GarminFormat PowerFormat { get; init; }

    [JsonPropertyName("heartRateFormat")]
    public GarminFormat HeartRateFormat { get; init; }

    [JsonPropertyName("firstDayOfWeek")]
    public GarminFirstDayOfWeek FirstDayOfWeek { get; init; }

    [JsonPropertyName("vo2MaxRunning")]
    public double Vo2MaxRunning { get; init; }

    [JsonPropertyName("vo2MaxCycling")]
    public double Vo2MaxCycling { get; init; }

    [JsonPropertyName("lactateThresholdSpeed")]
    public double LactateThresholdSpeed { get; init; }

    [JsonPropertyName("lactateThresholdHeartRate")]
    public object LactateThresholdHeartRate { get; init; }

    [JsonPropertyName("diveNumber")]
    public object DiveNumber { get; init; }

    [JsonPropertyName("intensityMinutesCalcMethod")]
    public string IntensityMinutesCalcMethod { get; init; }

    [JsonPropertyName("moderateIntensityMinutesHrZone")]
    public long ModerateIntensityMinutesHrZone { get; init; }

    [JsonPropertyName("vigorousIntensityMinutesHrZone")]
    public long VigorousIntensityMinutesHrZone { get; init; }

    [JsonPropertyName("hydrationMeasurementUnit")]
    public string HydrationMeasurementUnit { get; init; }

    [JsonPropertyName("hydrationContainers")]
    public object[] HydrationContainers { get; init; }

    [JsonPropertyName("hydrationAutoGoalEnabled")]
    public bool HydrationAutoGoalEnabled { get; init; }

    [JsonPropertyName("firstbeatMaxStressScore")]
    public long FirstbeatMaxStressScore { get; init; }

    [JsonPropertyName("firstbeatCyclingLtTimestamp")]
    public long FirstbeatCyclingLtTimestamp { get; init; }

    [JsonPropertyName("firstbeatRunningLtTimestamp")]
    public long FirstbeatRunningLtTimestamp { get; init; }

    [JsonPropertyName("thresholdHeartRateAutoDetected")]
    public bool ThresholdHeartRateAutoDetected { get; init; }

    [JsonPropertyName("ftpAutoDetected")]
    public bool FtpAutoDetected { get; init; }

    [JsonPropertyName("trainingStatusPausedDate")]
    public object TrainingStatusPausedDate { get; init; }

    [JsonPropertyName("weatherLocation")]
    public WeatherLocation WeatherLocation { get; init; }

    [JsonPropertyName("golfDistanceUnit")]
    public string GolfDistanceUnit { get; init; }

    [JsonPropertyName("golfElevationUnit")]
    public object GolfElevationUnit { get; init; }

    [JsonPropertyName("golfSpeedUnit")]
    public object GolfSpeedUnit { get; init; }

    [JsonPropertyName("externalBottomTime")]
    public object ExternalBottomTime { get; init; }
}

public record WeatherLocation
{
    [JsonPropertyName("useFixedLocation")]
    public object UseFixedLocation { get; init; }

    [JsonPropertyName("latitude")]
    public object Latitude { get; init; }

    [JsonPropertyName("longitude")]
    public object Longitude { get; init; }

    [JsonPropertyName("locationName")]
    public object LocationName { get; init; }

    [JsonPropertyName("isoCountryCode")]
    public object IsoCountryCode { get; init; }

    [JsonPropertyName("postalCode")]
    public object PostalCode { get; init; }
}

public record UserSleep
{
    [JsonPropertyName("sleepTime")]
    public long SleepTime { get; init; }

    [JsonPropertyName("defaultSleepTime")]
    public bool DefaultSleepTime { get; init; }

    [JsonPropertyName("wakeTime")]
    public long WakeTime { get; init; }

    [JsonPropertyName("defaultWakeTime")]
    public bool DefaultWakeTime { get; init; }
}