using System;
using System.Collections.Generic;
namespace SlidingWindow
{
    public static class LongestSubstringWithKDIstinctChars
    {
        public static int FindLength(string s, int k)
        {
            int windowStart = 0;
            var visitedCharsDict = new Dictionary<char, int>();
            int maxLength = 0, windowLength = 0;
            for (int windowEnd = 0; windowEnd < s.Length; windowEnd++)
            {
                var ch = s[windowEnd];
                visitedCharsDict.TryGetValue(ch, out var count);
                visitedCharsDict[ch] = count + 1;

                while (visitedCharsDict.Count > k)
                {
                    var temp = s[windowStart];
                    visitedCharsDict.TryGetValue(temp, out var count2);
                    if (count2 == 1) visitedCharsDict.Remove(temp);
                    else visitedCharsDict[temp] = count2 - 1;

                    windowStart++;
                }

                windowLength = windowEnd - windowStart + 1;
                maxLength = Math.Max(windowLength, maxLength);
            }

            return maxLength;

        }

        public static void Run()
        {
            Console.WriteLine("Length of the longest substring: " + LongestSubstringWithKDIstinctChars.FindLength("araaci", 2));
            Console.WriteLine("Length of the longest substring: " + LongestSubstringWithKDIstinctChars.FindLength("araaci", 1));
            Console.WriteLine("Length of the longest substring: " + LongestSubstringWithKDIstinctChars.FindLength("cbbebi", 3));

        }
    }
}
