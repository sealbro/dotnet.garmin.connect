using System.Collections.Generic;

namespace Garmin.Connect.Auth;

public interface IAuthParameters
{
    string Cookies { get; set; }

    bool NeedReLogin { get; }

    string BaseUrl { get; }

    string SsoUrl { get; }

    string SigninUrl { get; }

    Dictionary<string, string> GetHeaders();

    Dictionary<string, string> GetFormParameters();

    Dictionary<string, string> GetQueryParameters();
}