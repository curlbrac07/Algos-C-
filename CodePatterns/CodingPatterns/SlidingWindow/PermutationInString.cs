using System;
using System.Collections.Generic;
namespace SlidingWindow
{
    public static class PermutationInString
    {
        public static bool FindPermutation(string str, string pattern)
        {
            var dict = new Dictionary<char, int>();

            foreach(var ch in pattern)
            {
                dict.TryGetValue(ch, out var count);
                dict[ch] = count + 1;
            }

            var windowStart = 0;
            var matchedCount = 0;
            for(int windowEnd=0; windowEnd <str.Length; windowEnd++)
            {
                if (dict.TryGetValue(str[windowEnd], out var count))
                {
                    dict[str[windowEnd]] = count - 1;
                    if (count == 1) matchedCount++;
                }

                if (matchedCount == dict.Count) return true;

                if(windowEnd >= pattern.Length -1)
                {
                    var windowStartChar = str[windowStart];
                    if(dict.TryGetValue(windowStartChar, out var count2))
                    {
                        if(count2 == 0) matchedCount--;
                        dict[windowStartChar] = count2 + 1;
                    }
                    windowStart++;
                }
            }


            return false;
        }

     

        public static void Run()
        {
            Console.WriteLine("Permutation exist: " + PermutationInString.FindPermutation("oidbcaf", "abc"));
            Console.WriteLine("Permutation exist: " + PermutationInString.FindPermutation("odicf", "dc"));
            Console.WriteLine("Permutation exist: " + PermutationInString.FindPermutation("bcdxabcdy", "bcdyabcdx"));
            Console.WriteLine("Permutation exist: " + PermutationInString.FindPermutation("aaacb", "abc"));

        }
    }
}
