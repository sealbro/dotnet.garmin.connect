using System.Text.Json.Serialization;

namespace Garmin.Connect.Auth;

public record ConsumerCredentials
{
    /// <summary>
    /// Used value fom "https://thegarth.s3.amazonaws.com/oauth_consumer.json"
    /// </summary>
    public static ConsumerCredentials Default { get; } = new()
    {
        ConsumerKey = "fc3e99d2-118c-44b8-8ae3-03370dde24c0",
        ConsumerSecret = "E08WAR897WEy2knn7aFBrvegVAf0AFdWBBF"
    };

    [JsonPropertyName("consumer_key")]
    public string ConsumerKey { get; init; }
    [JsonPropertyName("consumer_secret")]
    public string ConsumerSecret { get; init; }
}