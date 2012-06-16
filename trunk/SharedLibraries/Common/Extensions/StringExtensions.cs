using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Common.Extensions
{
    public static class StringExtensions
    {
        private const string _chars = "abcdefghijklmnopqrstuvwxyz1234567890";

        public static string ToUrl(this string text)
        {
            // Replace invalid characters with empty strings.
            return Regex.Replace(text, @"[^\w\.@-]", "-"); 
        }
    }
}
