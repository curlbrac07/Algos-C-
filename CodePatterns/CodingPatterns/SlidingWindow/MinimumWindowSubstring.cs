using System;
using System.Collections.Generic;

namespace SlidingWindow
{
    public class MinimumWindowSubstring
    {
        public static String findSubstring(String str, String pattern)
        {
            var dict = new Dictionary<char, bool>();
            foreach(var ch in pattern)
            {
                dict[ch] = false;
            }

            var distinctCount = dict.Count;
            var matched = 0;
         
            for(int windowEnd =0; windowEnd < str.Length; windowEnd++)
            {
                var ch = str[windowEnd];
                if(dict.TryGetValue(ch, out var flag))
                {
                    if(!flag) dict[ch] = true;
                    matched++;
                }

                if(matched == distinctCount)
                {

                }





            }
            // TODO: Write your code here
            return "";
        }

        public static void Run()
        {

        }
    }
}
