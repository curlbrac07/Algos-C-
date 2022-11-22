using System;
using System.Collections.Generic;
namespace SlidingWindow
{
    public static class AllAnagramsInString
    {
        public static List<int> FindPermutation(string str, string pattern)
        {
            var dict = new Dictionary<char, int>();
            foreach(var ch in pattern)
            {
                dict.TryGetValue(ch, out var count);
                dict[ch] = count + 1;
            }

            var result = new List<int>();
            var windowStart = 0;
            var matchedCount = 0;
            for(int windowEnd = 0; windowEnd<str.Length; windowEnd++)
            {
                if(dict.TryGetValue(str[windowEnd], out var count))
                {
                    dict[str[windowEnd]] = count - 1;
                    if (count == 1) matchedCount++;
                }

                if (matchedCount == dict.Count) result.Add(windowStart);

                if(windowEnd >= pattern.Length - 1)
                {
                    var windowStartCh = str[windowStart];
                    if(dict.TryGetValue(windowStartCh, out var count2))
                    {
                        dict[windowStartCh] = count2 + 1;
                        if (count2 == 0) matchedCount--;
                    }
                    windowStart++;
                }
            }
          
            return result;
        }



        public static void Run()
        {


            Console.WriteLine("Permutation exist: " + string.Join(",", AllAnagramsInString.FindPermutation("ppqp", "pq")));
            Console.WriteLine("Permutation exist: " + string.Join(",", AllAnagramsInString.FindPermutation("abbcabc", "abc")));
        }

      
    }
}
