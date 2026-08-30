using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Garmin.Connect.Auth;

namespace Garmin.Connect.Tests;

/// <summary>
/// Wraps an <see cref="ITokenCache"/> to append a line to a local log file every time a token is
/// refreshed (Set*) or a cache lookup misses (Get* returns null) — test-only diagnostics for
/// watching the OAuth1-exchange/full-login refresh flow during local runs.
/// </summary>
public sealed class LoggingTokenCache(ITokenCache inner, string logFilePath) : ITokenCache
{
    private readonly Lock _writeLock = new();

    // GarminConnectContext.GetOrRefreshTokenAsync always calls SetOAuth1Token immediately before
    // SetOAuth2Token on a full login, and calls SetOAuth2Token alone (reusing the cached OAuth1
    // token) on an OAuth1-exchange refresh — this flag turns that ordering into an explicit label.
    private bool _oAuth1JustSet;

    // GetOAuth2Token is called on every outgoing request, so a hit needs logging exactly once
    // per process — logging every call would drown the file in repeats of the same "still valid"
    // line without adding information beyond the first one.
    private bool _loggedInitialCacheState;

    public async Task<OAuth2Token?> GetOAuth2Token(CancellationToken cancellationToken)
    {
        var token = await inner.GetOAuth2Token(cancellationToken);

        if (!_loggedInitialCacheState)
        {
            _loggedInitialCacheState = true;
            Log(token is null
                ? "GetOAuth2Token miss — will refresh"
                : "GetOAuth2Token hit — cached token still valid, no refresh needed yet");
        }

        return token;
    }

    public async Task SetOAuth2Token(OAuth2Token token, CancellationToken cancellationToken)
    {
        await inner.SetOAuth2Token(token, cancellationToken);

        var via = _oAuth1JustSet ? "full login" : "OAuth1 exchange";
        _oAuth1JustSet = false;
        Log($"SetOAuth2Token via={via} expires_in={token.ExpiresIn}s (~{DateTimeOffset.UtcNow.AddSeconds(token.ExpiresIn):O})");
    }

    public async Task<OAuth1Token?> GetOAuth1Token(CancellationToken cancellationToken)
    {
        var token = await inner.GetOAuth1Token(cancellationToken);
        Log(token is null
            ? "GetOAuth1Token miss"
            : $"GetOAuth1Token used for exchange fingerprint={Fingerprint(token.Token)}");

        return token;
    }

    public async Task SetOAuth1Token(OAuth1Token token, CancellationToken cancellationToken)
    {
        await inner.SetOAuth1Token(token, cancellationToken);
        _oAuth1JustSet = true;
        Log($"SetOAuth1Token (new token issued by full login) fingerprint={Fingerprint(token.Token)}");
    }

    private void Log(string message)
    {
        lock (_writeLock)
        {
            File.AppendAllText(logFilePath, $"{DateTimeOffset.UtcNow:O} {message}{Environment.NewLine}");
        }
    }

    // Short, non-reversible identifier so log lines can be compared to tell whether the same
    // OAuth1 token was reused across refreshes or a full login issued a new one — without ever
    // writing the actual token/secret to disk.
    private static string Fingerprint(string? value)
    {
        if (string.IsNullOrEmpty(value))
            return "none";

        var hash = SHA256.HashData(Encoding.UTF8.GetBytes(value));
        return Convert.ToHexString(hash)[..8];
    }
}
