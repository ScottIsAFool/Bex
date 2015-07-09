using System.Collections.Generic;
using System.Linq;

namespace Bex.Extensions
{
    internal static class ListExtensions
    {
        internal static bool IsNullOrEmpty<T>(this IList<T> list)
        {
            return list == null || !list.Any();
        }

        internal static string ToCommaSeparatedString<T>(this IList<T> list)
        {
            return string.Join(",", list);
        }
    }
}
