using System.Collections.Generic;
using Garmin.Connect.Auth.External;

namespace Garmin.Connect.Auth;

public interface IAuthParameters
{
    string UserAgent { get; }
    string Domain { get; }
    string Cookies { get; set; }
    string Csrf { get; set; }

    string BaseUrl { get; }
    
    ConsumerCredentials ConsumerCredentials { get; }

    IReadOnlyDictionary<string, string> GetHeaders();

    IReadOnlyDictionary<string, string> GetFormParameters();

    IReadOnlyDictionary<string, string> GetQueryParameters();
}