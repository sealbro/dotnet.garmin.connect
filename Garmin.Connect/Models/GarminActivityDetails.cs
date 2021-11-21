using System.Text.Json.Serialization;

namespace Garmin.Connect.Models;

public class GarminActivityDetails
{
    [JsonPropertyName("activityId")]
    public long ActivityId { get; set; }

    [JsonPropertyName("measurementCount")]
    public long MeasurementCount { get; set; }

    [JsonPropertyName("metricsCount")]
    public long MetricsCount { get; set; }

    [JsonPropertyName("metricDescriptors")]
    public MetricDescriptor[] MetricDescriptors { get; set; }

    [JsonPropertyName("activityDetailMetrics")]
    public ActivityDetailMetric[] ActivityDetailMetrics { get; set; }

    [JsonPropertyName("geoPolylineDTO")]
    public GeoPolylineDto GeoPolylineDto { get; set; }

    [JsonPropertyName("heartRateDTOs")]
    public object HeartRateDtOs { get; set; }

    [JsonPropertyName("detailsAvailable")]
    public bool DetailsAvailable { get; set; }
}

public class ActivityDetailMetric
{
    [JsonPropertyName("metrics")]
    public double[] Metrics { get; set; }
}

public class GeoPolylineDto
{
    [JsonPropertyName("startPoint")]
    public EndPoint StartPoint { get; set; }

    [JsonPropertyName("endPoint")]
    public EndPoint EndPoint { get; set; }

    [JsonPropertyName("minLat")]
    public double MinLat { get; set; }

    [JsonPropertyName("maxLat")]
    public double MaxLat { get; set; }

    [JsonPropertyName("minLon")]
    public double MinLon { get; set; }

    [JsonPropertyName("maxLon")]
    public double MaxLon { get; set; }

    [JsonPropertyName("polyline")]
    public EndPoint[] Polyline { get; set; }
}

public class EndPoint
{
    [JsonPropertyName("lat")]
    public double Lat { get; set; }

    [JsonPropertyName("lon")]
    public double Lon { get; set; }

    [JsonPropertyName("altitude")]
    public object Altitude { get; set; }

    [JsonPropertyName("time")]
    public long Time { get; set; }

    [JsonPropertyName("timerStart")]
    public bool TimerStart { get; set; }

    [JsonPropertyName("timerStop")]
    public bool TimerStop { get; set; }

    [JsonPropertyName("distanceFromPreviousPoint")]
    public object DistanceFromPreviousPoint { get; set; }
        
    [JsonPropertyName("distanceInMeters")]
    public object DistanceInMeters { get; set; }

    [JsonPropertyName("speed")]
    public double Speed { get; set; }

    [JsonPropertyName("cumulativeAscent")]
    public object CumulativeAscent { get; set; }
        
    [JsonPropertyName("cumulativeDescent")]
    public object CumulativeDescent { get; set; }

    [JsonPropertyName("extendedCoordinate")]
    public bool ExtendedCoordinate { get; set; }

    [JsonPropertyName("valid")]
    public bool Valid { get; set; }
}

public class MetricDescriptor
{
    [JsonPropertyName("metricsIndex")]
    public long MetricsIndex { get; set; }

    [JsonPropertyName("key")]
    public string Key { get; set; }

    [JsonPropertyName("unit")]
    public Unit Unit { get; set; }

    [JsonPropertyName("appID")]
    public string AppId { get; set; }

    [JsonPropertyName("developerFieldNumber")]
    public long DeveloperFieldNumber { get; set; }
}

public class Unit
{
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("key")]
    public string Key { get; set; }

    [JsonPropertyName("factor")]
    public double Factor { get; set; }
}