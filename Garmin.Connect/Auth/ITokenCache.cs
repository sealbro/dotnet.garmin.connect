using System.Threading;
using System.Threading.Tasks;

namespace Garmin.Connect.Auth;

public interface ITokenCache
{
    Task<OAuth2Token> GetOAuth2Token(CancellationToken cancellationToken);
    Task SetOAuth2Token(OAuth2Token token, CancellationToken cancellationToken);
}
