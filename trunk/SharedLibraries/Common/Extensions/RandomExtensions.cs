using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Common.Extensions
{
    public static class RandomExtensions
    {
        private const string _chars = "abcdefghijklmnopqrstuvwxyz1234567890";

        public static string String(this Random random,int size)
        {
            char[] buffer = new char[size];

            for (int i = 0; i < size; i++)
            {
                buffer[i] = _chars[random.Next(_chars.Length)];
            }
            return new string(buffer);
        }
    }
}
