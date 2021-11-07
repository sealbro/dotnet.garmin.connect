using System;

namespace Garmin.Connect.Exceptions
{
    public class GarminConnectAuthenticationException
        : Exception
    {
        public GarminConnectAuthenticationException() : base("Authentication error")
        {
        }
    }
}