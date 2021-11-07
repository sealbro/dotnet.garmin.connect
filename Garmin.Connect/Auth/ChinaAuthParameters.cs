using System.Collections.Generic;

namespace Garmin.Connect.Auth
{
    public class ChinaAuthParameters : BasicAuthParameters
    {
        public override string BaseUrl => "https://connect.garmin.cn";

        public override string SsoUrl => "https://sso.garmin.cn/sso";

        public override string SigninUrl => "https://sso.garmin.com/cn/signin";

        public ChinaAuthParameters(string email, string password) : base(email, password)
        {
        }

        public override Dictionary<string, string> GetHeaders()
        {
            var headers = base.GetHeaders();
            headers["origin"] = "https://sso.garmin.cn";

            return headers;
        }

        public override Dictionary<string, string> GetQueryParameters()
        {
            var queryParams = base.GetQueryParameters();
            queryParams["cssUrl"] = "https://static.garmincdn.cn/cn.garmin.connect/ui/css/gauth-custom-v1.2-min.css";

            return queryParams;
        }
    }
}