using System;
using System.Linq;
using Bex.Exceptions;
using Bex.Extensions;

namespace Bex.Helpers
{
    public class BexHelper
    {
        public static bool IsValidReturnUrl(Uri uri)
        {
            return uri.LocalPath.StartsWith("/oauth20_desktop.srf", StringComparison.OrdinalIgnoreCase);
        }

        public static string ExtractCode(Uri uri)
        {
            var query = uri.QueryString().ToList();

            var code = query.FirstOrDefault(entry => entry.Key.Equals("code", StringComparison.OrdinalIgnoreCase));

            var error = query.FirstOrDefault(entry => entry.Key.Equals("error", StringComparison.OrdinalIgnoreCase));
            var errorDesc = query.FirstOrDefault(entry => entry.Key.Equals("error_description", StringComparison.OrdinalIgnoreCase));

            if (!string.IsNullOrEmpty(error.Value))
            {
                throw new BexException(error.Value, errorDesc.Value);
            }

            if (string.IsNullOrEmpty(code.Value))
            {
                throw new BexException("NoCode", "No code was found in this url");
            }

            return code.Value;
        }
    }
}
