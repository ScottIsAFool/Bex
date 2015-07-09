using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Bex.Extensions
{
    internal static class UriExtensions
    {
        internal static IEnumerable<KeyValuePair<string, string>> QueryString(this Uri uri)
        {
            var uriString = uri.IsAbsoluteUri ? uri.AbsoluteUri : uri.OriginalString;

            var queryIndex = uriString.IndexOf("?", StringComparison.OrdinalIgnoreCase);

            if (queryIndex == -1)
            {
                return Enumerable.Empty<KeyValuePair<string, string>>();
            }

            var query = uriString.Substring(queryIndex + 1);

            return query.Split('&')
                .Where(x => !string.IsNullOrEmpty(x))
                .Select(x => x.Split('='))
                .Select(x => new KeyValuePair<string, string>(WebUtility.UrlDecode(x[0]), x.Length == 2 && !string.IsNullOrEmpty(x[1]) ? WebUtility.UrlDecode(x[1]) : null));
        }
    }
}
