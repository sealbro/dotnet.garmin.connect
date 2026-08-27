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
        public OAuth2Token OAuth2Token { get; init; }
        [JsonPropertyName("expire_at")]
        public DateTimeOffset ExpiresAt { get; init; }
        [JsonPropertyName("oauth1_token")]
        public OAuth1Token OAuth1Token { get; init; }
    }

    public FileTokenCache(string filePath)
    {
        _filePath = filePath;
    }

    public async Task<OAuth2Token> GetOAuth2Token(CancellationToken cancellationToken)
    {
        var cached = await ReadCache(cancellationToken);
        if (cached is not null && DateTimeOffset.UtcNow < cached.ExpiresAt)
            return cached.OAuth2Token;

        return null;
    }

    public async Task SetOAuth2Token(OAuth2Token token, CancellationToken cancellationToken)
    {
        var cached = await ReadCache(cancellationToken);
        var updated = (cached ?? new CachedToken()) with
        {
            OAuth2Token = token,
            ExpiresAt = DateTimeOffset.UtcNow.AddSeconds(token.ExpiresIn)
        };
        await WriteCache(updated, cancellationToken);
    }

    public async Task<OAuth1Token> GetOAuth1Token(CancellationToken cancellationToken)
    {
        var cached = await ReadCache(cancellationToken);
        return cached?.OAuth1Token;
    }

    public async Task SetOAuth1Token(OAuth1Token token, CancellationToken cancellationToken)
    {
        var cached = await ReadCache(cancellationToken);
        var updated = (cached ?? new CachedToken()) with { OAuth1Token = token };
        await WriteCache(updated, cancellationToken);
    }

    private async Task<CachedToken> ReadCache(CancellationToken cancellationToken)
    {
        if (!File.Exists(_filePath))
            return null;

        try
        {
            var json = await File.ReadAllBytesAsync(_filePath, cancellationToken);
            return JsonSerializer.Deserialize<CachedToken>(json);
        }
        catch (JsonException)
        {
            // corrupt file — treat as cache miss
            return null;
        }
    }

    private async Task WriteCache(CachedToken cached, CancellationToken cancellationToken)
    {
        var directory = Path.GetDirectoryName(_filePath);
        if (!string.IsNullOrEmpty(directory))
            Directory.CreateDirectory(directory);

        var json = JsonSerializer.SerializeToUtf8Bytes(cached);
        await File.WriteAllBytesAsync(_filePath, json, cancellationToken);
    }
}
