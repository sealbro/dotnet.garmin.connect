using System.Text.Json.Serialization;

namespace Garmin.Connect.Models;

public record GarminFirstDayOfWeek
{
    [JsonPropertyName("dayId")]
    public long DayId { get; init; }

    [JsonPropertyName("dayName")]
    public string DayName { get; init; }

    [JsonPropertyName("sortOrder")]
    public long SortOrder { get; init; }

    [JsonPropertyName("isPossibleFirstDay")]
    public bool IsPossibleFirstDay { get; init; }
}