using System;
using System.Collections.Generic;
namespace SlidingWindow
{
    public static class NoRepeatSubstring
    {
        public static int FindLength(string str)
        {
            var length = 0;
            var windowStart = 0;
            var hset = new HashSet<char>();

            for(int windowEnd=0; windowEnd<str.Length; windowEnd++)
            {
                if(hset.Contains(str[windowEnd]))
                {
                    hset.Clear();
                    windowStart = windowEnd; ;
                }
                hset.Add(str[windowEnd]);
                length = Math.Max(length, windowEnd - windowStart + 1);
            }

            return length;
        }

     

        public static void Run()
        {
            Console.WriteLine("Length of the longest substring: " + NoRepeatSubstring.FindLength("aabccbb"));
            Console.WriteLine("Length of the longest substring: " + NoRepeatSubstring.FindLength("abbbb"));
            Console.WriteLine("Length of the longest substring: " + NoRepeatSubstring.FindLength("abccde"));
            Console.WriteLine("Length of the longest substring: " + NoRepeatSubstring.FindLength("abba"));

        }
    }
}
