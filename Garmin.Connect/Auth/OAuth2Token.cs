using System.Text.Json.Serialization;

namespace Garmin.Connect.Auth;

internal record OAuth2Token
{
    [JsonPropertyName("scope")]
    public string Scope { get; set; }
    [JsonPropertyName("jti")]
    public string Jti { get; set; }
    [JsonPropertyName("access_token")]
    public string Access_Token { get; set; }
    [JsonPropertyName("token_type")]
    public string Token_Type { get; set; }
    [JsonPropertyName("refresh_token")]
    public string Refresh_Token { get; set; }
    [JsonPropertyName("expires_in")]
    public int Expires_In { get; set; }
    [JsonPropertyName("refresh_token_expires_in")]
    public int Refresh_Token_Expires_In { get; set; }
}