using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DifyAI
{
    internal static class StringExtensions
    {
        /// <summary>
        ///     Remove the search string from the begging of string if exist
        /// </summary>
        /// <param name="text"></param>
        /// <param name="search"></param>
        /// <returns></returns>
        public static string RemoveIfStartWith(this string text, string search)
        {
            var pos = text.IndexOf(search, StringComparison.Ordinal);
            return pos != 0 ? text : text[search.Length..];
        }
    }
}
