using System;
using System.Collections.Generic;
using System.Text;

namespace Utility.Helper
{
    public static class OrderIdGenereHelper
    {
        private static readonly Random _random = new Random();

        // Generates a random number within a range.      
        private static int RandomNumber(int min, int max)
        {
            return _random.Next(min, max);
        }

        private static string RandomString(int size)
        {
            var builder = new StringBuilder(size);
 
            char offset =  'A';
            const int lettersOffset = 26; // A...Z length=26  

            for (var i = 0; i < size; i++)
            {
                var @char = (char)_random.Next(offset, offset + lettersOffset);
                builder.Append(@char);
            }

            return builder.ToString();
        }

        public static string RandomId()
        {
            var passwordBuilder = new StringBuilder();

            passwordBuilder.Append(RandomString(2));

            passwordBuilder.Append(RandomNumber(100, 9999));

            passwordBuilder.Append(RandomString(2));
            return passwordBuilder.ToString();
        }
    }
}
