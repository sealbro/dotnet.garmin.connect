using System;
using System.Threading;
using System.Threading.Tasks;

namespace Garmin.Connect.Auth;

internal sealed class InMemoryTokenCache : ITokenCache
{
    private readonly object _lock = new();
    private OAuth2Token _oauth2Token;
    private DateTimeOffset _oauth2ExpiresAt;
    private OAuth1Token _oauth1Token;

    public Task<OAuth2Token> GetOAuth2Token(CancellationToken cancellationToken)
    {
        lock (_lock)
        {
            if (_oauth2Token is not null && DateTimeOffset.UtcNow < _oauth2ExpiresAt)
                return Task.FromResult(_oauth2Token);
            return Task.FromResult<OAuth2Token>(null);
        }
    }

    public Task SetOAuth2Token(OAuth2Token token, CancellationToken cancellationToken)
    {
        lock (_lock)
        {
            _oauth2Token = token;
            _oauth2ExpiresAt = DateTimeOffset.UtcNow.AddSeconds(token.ExpiresIn);
            return Task.CompletedTask;
        }
    }

    public Task<OAuth1Token> GetOAuth1Token(CancellationToken cancellationToken)
    {
        lock (_lock)
        {
            return Task.FromResult(_oauth1Token);
        }
    }

    public Task SetOAuth1Token(OAuth1Token token, CancellationToken cancellationToken)
    {
        lock (_lock)
        {
            _oauth1Token = token;
            return Task.CompletedTask;
        }
    }
}
