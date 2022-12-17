using System;
using System.Collections.Generic;

namespace Garmin.Connect.Auth;

public class BasicAuthParameters : IAuthParameters
{
    private readonly string _email;
    private readonly string _password;
    private readonly string _userAgent;

    public string Cookies { get; set; }

    public bool NeedReLogin => string.IsNullOrEmpty(Cookies);

    public virtual string BaseUrl => "https://connect.garmin.com";

    public virtual string ExchangeUrl => "https://connect.garmin.com/modern/di-oauth/exchange";

    public virtual string SsoUrl => "https://sso.garmin.com/sso";

    public virtual string SigninUrl => "https://sso.garmin.com/sso/signin";

    public BasicAuthParameters(string email, string password) : this(email, password, new StaticUserAgent())
    {
    }

    public BasicAuthParameters(string email, string password, IUserAgent userAgent)
    {
        if (string.IsNullOrEmpty(email))
        {
            throw new ArgumentException(email);
        }

        if (string.IsNullOrEmpty(password))
        {
            throw new ArgumentException(password);
        }

        _email = email;
        _password = password;
        _userAgent = userAgent.New;
    }

    public virtual IReadOnlyDictionary<string, string> GetHeaders()
    {
        return new Dictionary<string, string>
        {
            {
                "User-Agent",
                _userAgent
            },
            {
                "accept",
                "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9"
            },
            {
                "origin",
                "https://sso.garmin.com"
            }
        };
    }

    public virtual IReadOnlyDictionary<string, string> GetFormParameters()
    {
        var data = new Dictionary<string, string>
        {
            {
                "username",
                _email
            },
            {
                "password",
                _password
            },
            {
                "embed",
                "false"
            },
            {
                "displayNameRequired",
                "false"
            }
        };
        return data;
    }

    public virtual IReadOnlyDictionary<string, string> GetQueryParameters()
    {
        var queryParams = new Dictionary<string, string>
        {
            {
                "webhost",
                BaseUrl
            },
            {
                "service",
                BaseUrl
            },
            {
                "source",
                SigninUrl
            },
            {
                "redirectAfterAccountLoginUrl",
                BaseUrl
            },
            {
                "redirectAfterAccountCreationUrl",
                BaseUrl
            },
            {
                "gauthHost",
                SsoUrl
            },
            {
                "locale",
                "en_US"
            },
            {
                "id",
                "gauth-widget"
            },
            {
                "cssUrl",
                "https://static.garmincdn.com/com.garmin.connect/ui/css/gauth-custom-v1.2-min.css"
            },
            {
                "privacyStatementUrl",
                "https://www.garmin.com/en-US/privacy/connect/"
            },
            {
                "clientId",
                "GarminConnect"
            },
            {
                "rememberMeShown",
                "true"
            },
            {
                "rememberMeChecked",
                "false"
            },
            {
                "createAccountShown",
                "true"
            },
            {
                "openCreateAccount",
                "false"
            },
            {
                "displayNameShown",
                "false"
            },
            {
                "consumeServiceTicket",
                "false"
            },
            {
                "initialFocus",
                "true"
            },
            {
                "embedWidget",
                "false"
            },
            {
                "socialEnabled",
                "false"
            },
            {
                "generateExtraServiceTicket",
                "false"
            },
            {
                "generateTwoExtraServiceTickets",
                "false"
            },
            {
                "globalOptInShown",
                "true"
            },
            {
                "globalOptInChecked",
                "false"
            },
            {
                "mobile",
                "false"
            },
            {
                "connectLegalTerms",
                "true"
            },
            {
                "showTermsOfUse",
                "false"
            },
            {
                "showPrivacyPolicy",
                "false"
            },
            {
                "showConnectLegalAge",
                "false"
            },
            {
                "locationPromptShown",
                "false"
            },
            {
                "showPassword",
                "false"
            },
            {
                "useCustomHeader",
                "false"
            },
            {
                "mfaRequired",
                "false"
            },
            {
                "performMFACheck",
                "false"
            },
            {
                "rememberMyBrowserShown",
                "false"
            },
            {
                "rememberMyBrowserChecked",
                "false"
            }
        };

        return queryParams;
    }
}