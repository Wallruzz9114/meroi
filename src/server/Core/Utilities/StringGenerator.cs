using System;
using System.Linq;

namespace Core.Utilities
{
    public static class StringGenerator
    {
        public static string GenerateRandomString(int length = 10)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            var random = new Random();
            var randomString = new string(
                Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());

            return randomString;
        }
    }
}