using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Garmin.Connect.Auth;

public sealed class FileTokenCache : ITokenCache
{
    private readonly string _filePath;

    private record CachedToken
    {
        [JsonPropertyName("oauth2_token")]
        public OAuth2Token Token { get; init; }
        [JsonPropertyName("expire_at")]
        public DateTimeOffset ExpiresAt { get; init; }
    }

    public FileTokenCache(string filePath)
    {
        _filePath = filePath;
    }

    public async Task<OAuth2Token> GetOAuth2Token(CancellationToken cancellationToken)
    {
        if (!File.Exists(_filePath))
            return null;

        try
        {
            var json = await File.ReadAllBytesAsync(_filePath, cancellationToken);
            var cached = JsonSerializer.Deserialize<CachedToken>(json);
            if (cached is not null && DateTimeOffset.UtcNow < cached.ExpiresAt)
                return cached.Token;
        }
        catch (JsonException)
        {
            // corrupt file — treat as cache miss
        }

        return null;
    }

    public async Task SetOAuth2Token(OAuth2Token token, CancellationToken cancellationToken)
    {
        var directory = Path.GetDirectoryName(_filePath);
        if (!string.IsNullOrEmpty(directory))
            Directory.CreateDirectory(directory);

        var cached = new CachedToken { Token = token, ExpiresAt = DateTimeOffset.UtcNow.AddSeconds(token.ExpiresIn) };
        var json = JsonSerializer.SerializeToUtf8Bytes(cached);
        await File.WriteAllBytesAsync(_filePath, json, cancellationToken);
    }
}
