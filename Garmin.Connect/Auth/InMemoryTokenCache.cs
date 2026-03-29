using System;
using System.Threading;
using System.Threading.Tasks;

namespace Garmin.Connect.Auth;

internal sealed class InMemoryTokenCache : ITokenCache
{
    private OAuth2Token _oauth2Token;
    private DateTimeOffset _oauth2ExpiresAt;

    public Task<OAuth2Token> GetOAuth2Token(CancellationToken cancellationToken)
    {
        if (_oauth2Token is not null && DateTimeOffset.UtcNow < _oauth2ExpiresAt)
            return Task.FromResult(_oauth2Token);
        return Task.FromResult<OAuth2Token>(null);
    }

    public Task SetOAuth2Token(OAuth2Token token, CancellationToken cancellationToken)
    {
        _oauth2Token = token;
        _oauth2ExpiresAt = DateTimeOffset.UtcNow.AddSeconds(token.ExpiresIn);
        return Task.CompletedTask;
    }
}
