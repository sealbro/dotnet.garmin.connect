using System.Text.Json.Serialization;

namespace Garmin.Connect.Auth;

internal class OAuth1Token
{
    [JsonPropertyName("token")]
    public string Token { get; init; }
    [JsonPropertyName("token_secret")]
    public string TokenSecret { get; init; }
}