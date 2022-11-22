using System;
using System.Collections.Generic;

namespace SlidingWindow
{
    public static class CharacterReplacement
    {


        public static int findLength(String str, int k)
        {
            int maxLength = 0, windowStart = 0, maxRepeatingChars = 0;

            var dict = new Dictionary<char, int>();

            for(int windowEnd = 0; windowEnd < str.Length; windowEnd++)
            {
                var ch = str[windowEnd];
                dict.TryGetValue(ch, out var count);
                dict[ch] = count + 1;

                maxRepeatingChars = Math.Max(maxRepeatingChars, count + 1);

                var windowSize = windowEnd - windowStart + 1;

                if(windowSize > maxRepeatingChars + k)
                {
                    var charToRemove = str[windowStart];
                    dict.TryGetValue(charToRemove, out var count2);
                    if (count2 == 1) dict.Remove(charToRemove);
                    else dict[charToRemove] = count2 - 1;
                    windowStart = windowStart + 1;
                }


                maxLength = Math.Max(maxLength, windowEnd - windowStart + 1);

            }
            return maxLength;
        }


        public static void Run()
        {
            Console.WriteLine(CharacterReplacement.findLength("aabccbb", 2));
            Console.WriteLine(CharacterReplacement.findLength("abbcb", 1));
            Console.WriteLine(CharacterReplacement.findLength("abccde", 1));
        }
    }
}
