using System;
using System.Collections.Generic;

namespace Other
{
    public static class DecodeWays
    {
        private static ISet<string> mappings;
        public static int NumDecodings(string s)
        {
            mappings = GetMappings();
            return Recursive(s, 0);
        }

        private static int Recursive(string s, int startIndex)
        {
            if (startIndex >= s.Length) return 1;

            var digit1 = s[startIndex].ToString();
            var digit2 = (startIndex + 1) < s.Length? s.Substring(startIndex, 2) : null;


            var val1 = mappings.Contains(digit1) ? Recursive(s, startIndex + 1) : 0;
            var val2 = mappings.Contains(digit2) ? Recursive(s, startIndex + 2) : 0;

            return val1 + val2; 
        }


        private  static bool HasValidMapping(int x)
        {
            if (x < 1 || x > 26) return false;

            var startingIndex = (int)'A' - 1;

            return true;
        }

        private static ISet<string> GetMappings()
        {
            var set = new HashSet<string>();

            var startingIndex = (int)'A' - 1;

            for(int i=1; i <=26; i++)
            {
                set.Add(i.ToString()); 
            }

            return set;
        }

        public static void Run()
        {
      
            var input = "12";
            var result = DecodeWays.NumDecodings(input);
            Console.WriteLine("DecodeWays for " + input + "- " + result);

            input = "226";
            result = DecodeWays.NumDecodings(input);
            Console.WriteLine("DecodeWays for " + input + "- " + result);

            input = "0";
            result = DecodeWays.NumDecodings(input);
            Console.WriteLine("DecodeWays for " + input + "- " + result);

            input = "06";
            result = DecodeWays.NumDecodings(input);
            Console.WriteLine("DecodeWays for " + input + "- " + result);

        }
    }
}
