using System;
using System.Text.Json.Serialization;

namespace Garmin.Connect.Models;

public class GarminUserSettings
{
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("userData")]
    public UserData UserData { get; set; }

    [JsonPropertyName("userSleep")]
    public UserSleep UserSleep { get; set; }

    [JsonPropertyName("connectDate")]
    public object ConnectDate { get; set; }

    [JsonPropertyName("sourceType")]
    public object SourceType { get; set; }
}

public class UserData
{
    [JsonPropertyName("gender")]
    public string Gender { get; set; }

    [JsonPropertyName("weight")]
    public double Weight { get; set; }

    [JsonPropertyName("height")]
    public double Height { get; set; }

    [JsonPropertyName("timeFormat")]
    public string TimeFormat { get; set; }

    [JsonPropertyName("birthDate")]
    public DateTime BirthDate { get; set; }

    [JsonPropertyName("measurementSystem")]
    public string MeasurementSystem { get; set; }

    [JsonPropertyName("activityLevel")]
    public long ActivityLevel { get; set; }

    [JsonPropertyName("handedness")]
    public string Handedness { get; set; }

    [JsonPropertyName("powerFormat")]
    public GarminFormat PowerFormat { get; set; }

    [JsonPropertyName("heartRateFormat")]
    public GarminFormat HeartRateFormat { get; set; }

    [JsonPropertyName("firstDayOfWeek")]
    public GarminFirstDayOfWeek FirstDayOfWeek { get; set; }

    [JsonPropertyName("vo2MaxRunning")]
    public double Vo2MaxRunning { get; set; }

    [JsonPropertyName("vo2MaxCycling")]
    public double Vo2MaxCycling { get; set; }

    [JsonPropertyName("lactateThresholdSpeed")]
    public double LactateThresholdSpeed { get; set; }

    [JsonPropertyName("lactateThresholdHeartRate")]
    public object LactateThresholdHeartRate { get; set; }

    [JsonPropertyName("diveNumber")]
    public object DiveNumber { get; set; }

    [JsonPropertyName("intensityMinutesCalcMethod")]
    public string IntensityMinutesCalcMethod { get; set; }

    [JsonPropertyName("moderateIntensityMinutesHrZone")]
    public long ModerateIntensityMinutesHrZone { get; set; }

    [JsonPropertyName("vigorousIntensityMinutesHrZone")]
    public long VigorousIntensityMinutesHrZone { get; set; }

    [JsonPropertyName("hydrationMeasurementUnit")]
    public string HydrationMeasurementUnit { get; set; }

    [JsonPropertyName("hydrationContainers")]
    public object[] HydrationContainers { get; set; }

    [JsonPropertyName("hydrationAutoGoalEnabled")]
    public bool HydrationAutoGoalEnabled { get; set; }

    [JsonPropertyName("firstbeatMaxStressScore")]
    public long FirstbeatMaxStressScore { get; set; }

    [JsonPropertyName("firstbeatCyclingLtTimestamp")]
    public long FirstbeatCyclingLtTimestamp { get; set; }

    [JsonPropertyName("firstbeatRunningLtTimestamp")]
    public long FirstbeatRunningLtTimestamp { get; set; }

    [JsonPropertyName("thresholdHeartRateAutoDetected")]
    public bool ThresholdHeartRateAutoDetected { get; set; }

    [JsonPropertyName("ftpAutoDetected")]
    public bool FtpAutoDetected { get; set; }

    [JsonPropertyName("trainingStatusPausedDate")]
    public object TrainingStatusPausedDate { get; set; }

    [JsonPropertyName("weatherLocation")]
    public WeatherLocation WeatherLocation { get; set; }

    [JsonPropertyName("golfDistanceUnit")]
    public string GolfDistanceUnit { get; set; }

    [JsonPropertyName("golfElevationUnit")]
    public object GolfElevationUnit { get; set; }

    [JsonPropertyName("golfSpeedUnit")]
    public object GolfSpeedUnit { get; set; }

    [JsonPropertyName("externalBottomTime")]
    public object ExternalBottomTime { get; set; }
}

public class WeatherLocation
{
    [JsonPropertyName("useFixedLocation")]
    public object UseFixedLocation { get; set; }

    [JsonPropertyName("latitude")]
    public object Latitude { get; set; }

    [JsonPropertyName("longitude")]
    public object Longitude { get; set; }

    [JsonPropertyName("locationName")]
    public object LocationName { get; set; }

    [JsonPropertyName("isoCountryCode")]
    public object IsoCountryCode { get; set; }

    [JsonPropertyName("postalCode")]
    public object PostalCode { get; set; }
}

public class UserSleep
{
    [JsonPropertyName("sleepTime")]
    public long SleepTime { get; set; }

    [JsonPropertyName("defaultSleepTime")]
    public bool DefaultSleepTime { get; set; }

    [JsonPropertyName("wakeTime")]
    public long WakeTime { get; set; }

    [JsonPropertyName("defaultWakeTime")]
    public bool DefaultWakeTime { get; set; }
}