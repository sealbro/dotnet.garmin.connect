using System;
using System.Net;

namespace Garmin.Connect.Exceptions;

public class GarminConnectRequestException : Exception
{
    public string Url { get; }

    public HttpStatusCode Status { get; }

    public GarminConnectRequestException(string url, HttpStatusCode status)
        : this(url, status, null)
    {
    }

    internal GarminConnectRequestException(string url, HttpStatusCode status, string details) : base(
        details is null
            ? $"Request [{url}] return code {(int)status} ({status})."
            : $"Request [{url}] return code {(int)status} ({status}).\n{details}")
    {
        Url = url;
        Status = status;
    }
}
