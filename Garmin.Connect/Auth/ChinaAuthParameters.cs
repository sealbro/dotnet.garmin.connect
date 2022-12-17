using System.Collections.Generic;

namespace Garmin.Connect.Auth;

public class ChinaAuthParameters : BasicAuthParameters
{
    public override string BaseUrl => "https://connect.garmin.cn";

    public override string ExchangeUrl => "https://connect.garmin.cn/modern/di-oauth/exchange";

    public override string SsoUrl => "https://sso.garmin.cn/sso";

    public override string SigninUrl => "https://sso.garmin.com/cn/signin";

    public ChinaAuthParameters(string email, string password) : base(email, password)
    {
    }

    public override IReadOnlyDictionary<string, string> GetHeaders() =>
        new Dictionary<string, string>(base.GetHeaders())
        {
            {
                "origin", "https://sso.garmin.cn"
            }
        };

    public override IReadOnlyDictionary<string, string> GetQueryParameters() =>
        new Dictionary<string, string>(base.GetQueryParameters())
        {
            { "cssUrl", "https://static.garmincdn.cn/cn.garmin.connect/ui/css/gauth-custom-v1.2-min.css" }
        };
}