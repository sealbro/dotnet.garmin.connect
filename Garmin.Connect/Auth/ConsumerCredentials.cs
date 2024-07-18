using System.Text.Json.Serialization;

namespace Garmin.Connect.Auth;

public record ConsumerCredentials
{
    [JsonPropertyName("consumer_key")]
    public string Consumer_Key { get; set; }
    [JsonPropertyName("consumer_secret")]
    public string Consumer_Secret { get; set; }
}

// 10/01/23
//{
//    "consumer_key": "fc3e99d2-118c-44b8-8ae3-03370dde24c0",
//    "consumer_secret": "E08WAR897WEy2knn7aFBrvegVAf0AFdWBBF"
//}