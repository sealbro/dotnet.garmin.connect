using System.Threading;
using System.Threading.Tasks;

namespace Garmin.Connect.Auth;

public interface ITokenCache
{
    Task<OAuth2Token> GetOAuth2Token(CancellationToken cancellationToken);
    Task SetOAuth2Token(OAuth2Token token, CancellationToken cancellationToken);
    Task<OAuth1Token> GetOAuth1Token(CancellationToken cancellationToken) => Task.FromResult<OAuth1Token>(null);
    Task SetOAuth1Token(OAuth1Token token, CancellationToken cancellationToken) => Task.CompletedTask;
}
