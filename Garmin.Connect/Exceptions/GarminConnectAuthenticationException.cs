using System;

namespace Garmin.Connect.Exceptions;

public class GarminConnectAuthenticationException : Exception
{
    public GarminConnectAuthenticationException() : base("Authentication error")
    {
    }

    public GarminConnectAuthenticationException(string message) : base(message)
    {
    }
}