using System.Text.Json.Serialization;

namespace Garmin.Connect.Auth;

public record OAuth2Token
{
    [JsonPropertyName("scope")]
    public string Scope { get; init; }
    [JsonPropertyName("jti")]
    public string Jti { get; init; }
    [JsonPropertyName("access_token")]
    public string AccessToken { get; init; }
    [JsonPropertyName("token_type")]
    public string TokenType { get; init; }
    [JsonPropertyName("refresh_token")]
    public string RefreshToken { get; init; }
    [JsonPropertyName("expires_in")]
    public int ExpiresIn { get; init; }
    [JsonPropertyName("refresh_token_expires_in")]
    public int RefreshTokenExpiresIn { get; init; }
}