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
        public object[] DateWeightList { get; set; }

        [JsonPropertyName("totalAverage")]
        public TotalAverage TotalAverage { get; set; }
    }

    public class TotalAverage
    {
        [JsonPropertyName("from")]
        public long From { get; set; }

        [JsonPropertyName("until")]
        public long Until { get; set; }

        [JsonPropertyName("weight")]
        public object Weight { get; set; }

        [JsonPropertyName("bmi")]
        public object Bmi { get; set; }

        [JsonPropertyName("bodyFat")]
        public object BodyFat { get; set; }

        [JsonPropertyName("bodyWater")]
        public object BodyWater { get; set; }

        [JsonPropertyName("boneMass")]
        public object BoneMass { get; set; }

        [JsonPropertyName("muscleMass")]
        public object MuscleMass { get; set; }

        [JsonPropertyName("physiqueRating")]
        public object PhysiqueRating { get; set; }

        [JsonPropertyName("visceralFat")]
        public object VisceralFat { get; set; }

        [JsonPropertyName("metabolicAge")]
        public object MetabolicAge { get; set; }
    }
}