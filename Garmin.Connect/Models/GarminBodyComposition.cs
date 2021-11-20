using System;
using System.Text.Json.Serialization;

namespace Garmin.Connect.Models
{
    public class GarminBodyComposition
    {
        [JsonPropertyName("startDate")]
        public DateTime StartDate { get; set; }

        [JsonPropertyName("endDate")]
        public DateTime EndDate { get; set; }

        [JsonPropertyName("dateWeightList")]
        public GarminDateWeight[] DateWeightList { get; set; }

        [JsonPropertyName("totalAverage")]
        public GarminTotalAverage TotalAverage { get; set; }
    }

    public class GarminTotalAverage
    {
        [JsonPropertyName("from")]
        public long From { get; set; }

        [JsonPropertyName("until")]
        public long Until { get; set; }

        [JsonPropertyName("weight")]
        public double Weight { get; set; }

        [JsonPropertyName("bmi")]
        public double Bmi { get; set; }

        [JsonPropertyName("bodyFat")]
        public double BodyFat { get; set; }

        [JsonPropertyName("bodyWater")]
        public double BodyWater { get; set; }

        [JsonPropertyName("boneMass")]
        public double BoneMass { get; set; }

        [JsonPropertyName("muscleMass")]
        public double MuscleMass { get; set; }

        [JsonPropertyName("physiqueRating")]
        public object PhysiqueRating { get; set; }

        [JsonPropertyName("visceralFat")]
        public object VisceralFat { get; set; }

        [JsonPropertyName("metabolicAge")]
        public object MetabolicAge { get; set; }
    }

    public class GarminDateWeight
    {
        [JsonPropertyName("samplePk")]
        public long SamplePk { get; set; }

        [JsonPropertyName("date")]
        public long Date { get; set; }

        [JsonPropertyName("calendarDate")]
        public DateTimeOffset CalendarDate { get; set; }

        [JsonPropertyName("weight")]
        public double Weight { get; set; }

        [JsonPropertyName("bmi")]
        public double Bmi { get; set; }

        [JsonPropertyName("bodyFat")]
        public double BodyFat { get; set; }

        [JsonPropertyName("bodyWater")]
        public double BodyWater { get; set; }

        [JsonPropertyName("boneMass")]
        public long BoneMass { get; set; }

        [JsonPropertyName("muscleMass")]
        public long MuscleMass { get; set; }

        [JsonPropertyName("physiqueRating")]
        public object PhysiqueRating { get; set; }

        [JsonPropertyName("visceralFat")]
        public object VisceralFat { get; set; }

        [JsonPropertyName("metabolicAge")]
        public object MetabolicAge { get; set; }

        [JsonPropertyName("sourceType")]
        public string SourceType { get; set; }

        [JsonPropertyName("timestampGMT")]
        public long TimestampGmt { get; set; }

        [JsonPropertyName("weightDelta")]
        public object WeightDelta { get; set; }
    }
}