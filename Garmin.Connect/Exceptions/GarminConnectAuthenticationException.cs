using System;

namespace Garmin.Connect.Auth.External;

public class GarminConnectAuthenticationException : Exception
{
    public Code Code { get; init; } = Code.None;

    public GarminConnectAuthenticationException(string message) : base(message)
    {
    }

    public GarminConnectAuthenticationException(string message, Exception innerException) : base(message,
        innerException)
    {
    }
}

public enum Code : byte
{
    None = 0,
    CookiesNotFound = 1,
    CsrfTokenNotFound = 2,
    OAuth1TicketNotFound = 3,
    OAuth1TokenNotFound = 4,
    OAuth2TokenNotFound = 5,
    MfaBlockedCloudflare = 6,
    MfaInvalidCode = 7
}