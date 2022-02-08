using System;
using System.Text.Json.Serialization;

using Garmin.Connect.Converters;

namespace Garmin.Connect.Models;

public record GarminGear
{
    [JsonPropertyName("uuid")]
    public string Uuid { get; init; }

    [JsonPropertyName("gearPk")]
    public int GearPk { get; init; }

    [JsonPropertyName("userProfilePk")]
    public Int64 UserProfileID { get; init; }

    [JsonPropertyName("gearMakeName")]
    public string GearMakeName { get; init; }

    [JsonPropertyName("gearModelName")]
    public string GearModelName { get; init; }

    [JsonPropertyName("gearTypeName")]
    public string GearTypeName { get; init; }

    [JsonPropertyName("displayName")]
    public string DisplayName { get; init; }

    [JsonPropertyName("customMakeModel")]
    public string CustomMakeModel { get; init; }

    [JsonPropertyName("imageNameLarge")]
    public string ImageNameLarge { get; init; }

    [JsonPropertyName("imageNameMedium")]
    public string ImageNameMedium { get; init; }

    [JsonPropertyName("imageNameSmall")]
    public string ImageNameSmall { get; init; }

    [JsonPropertyName("dateBegin")]
    [JsonConverter(typeof(DateTimeConverter))]
    public DateTime DateBegin { get; init; }

    [JsonPropertyName("dateEnd")]
    [JsonConverter(typeof(DateTimeConverter))]
    public DateTime? DateEnd { get; init; }

    [JsonPropertyName("maximumMeters")]
    public double MaximumMeters { get; init; }

    [JsonPropertyName("notified")]
    public bool Notified { get; init; }

    [JsonPropertyName("createDate")]
    public DateTime CreateDate { get; init; }

    [JsonPropertyName("updateDate")]
    public DateTime UpdateDate { get; init; }
}

public record GarminGearType
{
    [JsonPropertyName("gearTypePk")]
    public int GearTypePk { get; init; }

    [JsonPropertyName("gearTypeName")]
    public string GearTypeName { get; init; }

    [JsonPropertyName("createDate")]
    public DateTime CreateDate { get; init; }

    [JsonPropertyName("updateData")]
    public DateTime? UpdateData { get; init; }
}
