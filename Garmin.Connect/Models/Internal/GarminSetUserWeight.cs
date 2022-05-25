using System.Text.Json.Serialization;

namespace Garmin.Connect.Models.Internal;

internal record struct GarminSetUserWeight
{
    [JsonPropertyName("userData")]
    public WeightUserData UserData { get; init; }

    public GarminSetUserWeight(double weight)
    {
        UserData = new WeightUserData
        {
            Weight = weight
        };
    }
}

internal record struct WeightUserData
{
    [JsonPropertyName("weight")]
    public double Weight { get; init; }
}