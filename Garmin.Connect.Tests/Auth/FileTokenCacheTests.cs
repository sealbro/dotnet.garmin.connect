using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Garmin.Connect.Auth;

namespace Garmin.Connect.Tests.Auth;

public class FileTokenCacheTests
{
    private static string NewTempFilePath() =>
        Path.Combine(Path.GetTempPath(), $"garmin_token_test_{Guid.NewGuid():N}.json");

    [Test]
    public async Task GetOAuth1Token_ReturnsNull_WhenFileMissing()
    {
        var cache = new FileTokenCache(NewTempFilePath());

        var actual = await cache.GetOAuth1Token(CancellationToken.None);

        await Assert.That(actual).IsNull();
    }

    [Test]
    public async Task SetOAuth1Token_ThenGet_RoundTrips()
    {
        var path = NewTempFilePath();
        try
        {
            var cache = new FileTokenCache(path);
            var token = new OAuth1Token { Token = "oauth1-token", TokenSecret = "oauth1-secret" };

            await cache.SetOAuth1Token(token, CancellationToken.None);
            var actual = await cache.GetOAuth1Token(CancellationToken.None);

            await Assert.That(actual).IsEqualTo(token);
        }
        finally
        {
            File.Delete(path);
        }
    }

    /// <summary>
    /// SetOAuth1Token and SetOAuth2Token both read-modify-write the same cache file,
    /// so writing one must not erase the other.
    /// </summary>
    [Test]
    public async Task SetOAuth2Token_DoesNotClobberPreviouslyCachedOAuth1Token()
    {
        var path = NewTempFilePath();
        try
        {
            var cache = new FileTokenCache(path);
            var oAuth1 = new OAuth1Token { Token = "oauth1-token", TokenSecret = "oauth1-secret" };
            var oAuth2 = new OAuth2Token { AccessToken = "access", ExpiresIn = 3600 };

            await cache.SetOAuth1Token(oAuth1, CancellationToken.None);
            await cache.SetOAuth2Token(oAuth2, CancellationToken.None);

            await Assert.That(await cache.GetOAuth1Token(CancellationToken.None)).IsEqualTo(oAuth1);
            await Assert.That((await cache.GetOAuth2Token(CancellationToken.None))?.AccessToken).IsEqualTo("access");
        }
        finally
        {
            File.Delete(path);
        }
    }

    [Test]
    public async Task SetOAuth1Token_DoesNotClobberPreviouslyCachedOAuth2Token()
    {
        var path = NewTempFilePath();
        try
        {
            var cache = new FileTokenCache(path);
            var oAuth2 = new OAuth2Token { AccessToken = "access", ExpiresIn = 3600 };
            var oAuth1 = new OAuth1Token { Token = "oauth1-token", TokenSecret = "oauth1-secret" };

            await cache.SetOAuth2Token(oAuth2, CancellationToken.None);
            await cache.SetOAuth1Token(oAuth1, CancellationToken.None);

            await Assert.That((await cache.GetOAuth2Token(CancellationToken.None))?.AccessToken).IsEqualTo("access");
            await Assert.That(await cache.GetOAuth1Token(CancellationToken.None)).IsEqualTo(oAuth1);
        }
        finally
        {
            File.Delete(path);
        }
    }

    [Test]
    public async Task GetOAuth2Token_ReturnsNull_AfterExpiry()
    {
        var path = NewTempFilePath();
        try
        {
            var cache = new FileTokenCache(path);
            var oAuth2 = new OAuth2Token { AccessToken = "access", ExpiresIn = -1 };

            await cache.SetOAuth2Token(oAuth2, CancellationToken.None);
            var actual = await cache.GetOAuth2Token(CancellationToken.None);

            await Assert.That(actual).IsNull();
        }
        finally
        {
            File.Delete(path);
        }
    }
}
