using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Castlerock.FileManager.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Convert the string to a url friendly string
        /// </summary>
        public static string ToUrl(this string value)
        {
            if (value == null)
            {
                return value;
            }

            // make the url lowercase
            var encoded = (value ?? "").ToLower();

            // replace & with and
            encoded = Regex.Replace(encoded, @"\&+", "and");

            // remove characters
            encoded = encoded.Replace("'", "");

            // remove invalid characters
            encoded = Regex.Replace(encoded, @"[^a-z0-9]", "-");

            // remove duplicates
            encoded = Regex.Replace(encoded, @"-+", "-");

            // trim leading & trailing characters
            encoded = encoded.Trim('-');

            return encoded;
        }
    }
}
