using System;
using System.Collections.Generic;

namespace SlidingWindow
{
    public class StringAnagrams
    {
        public static List<int> findStringAnagrams(String str, String pattern)
        {
            List<int> resultIndices = new List<int>();
            var dict = new Dictionary<char, int>();

            foreach(var ch in pattern)
            {
                dict.TryGetValue(ch, out var count);
                dict[ch] = count + 1;
            }

            int windowStart = 0; int matchedCount = 0;
            for(int windowEnd = 0; windowEnd < str.Length; windowEnd++)
            {
                var ch = str[windowEnd];
                if(dict.TryGetValue(ch, out var count))
                {
                    dict[ch] = count - 1;
                    if (count == 1) matchedCount++;
                }

                if(matchedCount == dict.Count)
                {
                    resultIndices.Add(windowStart);
                }

                var windowSize = windowEnd - windowStart + 1;
                if(windowSize >= pattern.Length)
                {
                    var ch2 = str[windowStart++];
                    if(dict.TryGetValue(ch2, out var count2))
                    {
                        dict[ch2] = count2 + 1;
                        if (count2 == 0) matchedCount--;
                    }
                }
            }

            return resultIndices;
        }


        public static void Run()
        {
            Console.WriteLine(string.Join(",", StringAnagrams.findStringAnagrams("ppqp", "pq")));
            Console.WriteLine(string.Join(",", StringAnagrams.findStringAnagrams("abbcabc", "abc")));
        }
    }
}
