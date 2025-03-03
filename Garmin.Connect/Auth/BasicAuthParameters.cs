using System;
using System.Collections.Generic;

namespace Garmin.Connect.Auth;

public class BasicAuthParameters : IAuthParameters
{
    private readonly string _email;
    private readonly string _password;
    private readonly IUserAgent _userAgent;


    public string UserAgent => _userAgent.New;

    public string Domain => "garmin.com";
    public string Cookies { get; set; }
    public string Csrf { get; set; }

    public virtual string BaseUrl => $"https://connect.{Domain}";

    public ConsumerCredentials ConsumerCredentials { get; }

    public BasicAuthParameters(string email, string password) : this(email, password, new StaticUserAgent())
    {
    }

    public BasicAuthParameters(string email, string password, IUserAgent userAgent, ConsumerCredentials consumerCredentials = null)
    {
        if (string.IsNullOrEmpty(email))
        {
            throw new ArgumentException(email, nameof(email));
        }

        if (string.IsNullOrEmpty(password))
        {
            throw new ArgumentException(password, nameof(password));
        }

        _email = email;
        _password = password;
        _userAgent = userAgent;
        ConsumerCredentials = consumerCredentials;
    }

    public virtual IReadOnlyDictionary<string, string> GetHeaders()
    {
        var headers = new Dictionary<string, string>
        {
            {
                "User-Agent",
                UserAgent
            },
            {
                "origin",
                $"https://sso.{Domain}"
            }
        };

        if (!string.IsNullOrEmpty(Cookies))
        {
            headers.Add("cookie", Cookies);
        }

        return headers;
    }

    public virtual IReadOnlyDictionary<string, string> GetFormParameters()
    {
        var data = new Dictionary<string, string>
        {
            { "embed", "true" },
            { "_csrf", Csrf },
            { "username", _email },
            { "password", _password }
        };
        return data;
    }

    public virtual IReadOnlyDictionary<string, string> GetQueryParameters()
    {
        var queryParams = new Dictionary<string, string>
        {
            { "id", "gauth-widget" },
            { "embedWidget", "true" },
        };

        return queryParams;
    }

    public virtual IReadOnlyDictionary<string, string> GetMfaParameters()
    {
        var queryParams = new Dictionary<string, string>
        {
            { "embed", "true" },
            { "fromPage", "setupEnterMfaCode" },
            { "_csrf", Csrf },
        };

        return queryParams;
    }
}