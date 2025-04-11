using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Garmin.Connect.OAuth;

internal static class WebUtils
{
    public static IEnumerable<WebParameter> ParseQueryString(Uri uri)
    {
        if (uri is null) { throw new ArgumentNullException(nameof(uri)); }

        var parsedQuery = HttpUtility.ParseQueryString(uri.Query);
        var queryStringParameters =
            parsedQuery.AllKeys.SelectMany(parsedQuery.GetValues, (key, value) => new { key, value });

        foreach (var param in queryStringParameters)
        {
            yield return new WebParameter(param.key, param.value);
        }
    }
}