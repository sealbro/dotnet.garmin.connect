using System.Collections.Generic;

namespace Garmin.Connect.Auth;

public interface IAuthParameters
{
    string Cookies { get; set; }

    bool NeedReLogin { get; }

    string BaseUrl { get; }

    string SsoUrl { get; }

    string SigninUrl { get; }

    string ExchangeUrl { get; }

    IReadOnlyDictionary<string, string> GetHeaders();

    IReadOnlyDictionary<string, string> GetFormParameters();

    IReadOnlyDictionary<string, string> GetQueryParameters();
}