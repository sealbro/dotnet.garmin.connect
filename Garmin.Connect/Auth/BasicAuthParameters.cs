using System;
using System.Collections.Generic;

namespace Garmin.Connect.Auth
{
    public class BasicAuthParameters : IAuthParameters
    {
        private readonly string _email;
        private readonly string _password;

        public virtual string BaseUrl => "https://connect.garmin.com";

        public virtual string SsoUrl => "https://sso.garmin.com/sso";

        public virtual string SigninUrl => "https://sso.garmin.com/sso/signin";

        public BasicAuthParameters(string email, string password)
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
        }

        public virtual Dictionary<string, string> GetHeaders()
        {
            return new Dictionary<string, string>
            {
                {
                    "User-Agent",
                    "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/79.0.3945.88 Safari/537.36"
                },
                {
                    "origin",
                    "https://sso.garmin.com"
                }
            };
        }

        public virtual Dictionary<string, string> GetFormParameters()
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
                    "true"
                },
                {
                    "lt",
                    "e1s1"
                },
                {
                    "_eventId",
                    "submit"
                },
                {
                    "displayNameRequired",
                    "false"
                }
            };
            return data;
        }

        public virtual Dictionary<string, string> GetQueryParameters()
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
                    "usernameShown",
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
                    "generateExtraServiceTicket",
                    "false"
                }
            };

            return queryParams;
        }
    }
}