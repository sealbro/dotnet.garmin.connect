using System;

namespace Garmin.Connect.Exceptions;

public class GarminConnectTooManyRequestsException : Exception
{
    public GarminConnectTooManyRequestsException() : base("Too many requests. Try again later.")
    {
    }
}