using System.Text.Json.Serialization;

namespace Garmin.Connect.Models;

public class GarminFirstDayOfWeek
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