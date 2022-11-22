using System;
using System.Collections.Generic;

namespace SlidingWindow
{
    public class StringPermutation
    {
        public static bool findPermutation(String str, String pattern)
        {
            int windowStart = 0;

            var dict = new Dictionary<char, int>();

            foreach(var ch in pattern)
            {
                dict.TryGetValue(ch, out var count);
                dict[ch] = count + 1;
            }

            var matchedDictinctCharCount = 0;

            for(int windowEnd = 0; windowEnd<str.Length; windowEnd++)
            {
                var ch = str[windowEnd];
                if (dict.TryGetValue(ch, out var count))
                {
                    dict[ch] = count - 1;
                    if (count == 1) matchedDictinctCharCount++;
                }

                if (matchedDictinctCharCount == dict.Count) return true;

                var windowSize = windowEnd - windowStart + 1;

                //WindowSize should be pattern length
                if(windowSize >= pattern.Length)
                {
                    var ch2 = str[windowStart++];
                    if(dict.TryGetValue(ch2, out var count2))
                    {
                        dict[ch2] = count2 + 1;
                        if (count2 == 0) matchedDictinctCharCount--;
                    }
                }
            }



            // TODO: Write your code here
            return false;
        }


        public static void Run()
        {
            Console.WriteLine("Permutation exist: " + StringPermutation.findPermutation("oidbcaf", "abc"));
            Console.WriteLine("Permutation exist: " + StringPermutation.findPermutation("odicf", "dc"));
            Console.WriteLine("Permutation exist: " + StringPermutation.findPermutation("bcdxabcdy", "bcdyabcdx"));
            Console.WriteLine("Permutation exist: " + StringPermutation.findPermutation("aaacb", "abc"));

        }
    }
}
