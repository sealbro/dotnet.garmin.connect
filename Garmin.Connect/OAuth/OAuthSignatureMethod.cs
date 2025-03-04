namespace OAuth;

/// <summary>
/// The encryption method to use when hashing a request signature.
/// </summary>
internal enum OAuthSignatureMethod
{
    HmacSha1,
    PlainText,
    RsaSha1
}