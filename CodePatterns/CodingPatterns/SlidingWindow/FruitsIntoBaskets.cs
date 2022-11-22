using System;
using System.Collections.Generic;
namespace SlidingWindow
{
    public static class FruitsIntoBaskets
    {
        public static int FindLength(char[] arr)
        {
            int windowStart = 0;
            int length = 0;
            var dict = new Dictionary<char, int>();
            for(int windowEnd=0; windowEnd< arr.Length; windowEnd++)
            {
                var ch = arr[windowEnd];
                dict.TryGetValue(ch, out var count);
                dict[ch] = count + 1;

                //if Distinct chars > 2 - Then Shrink
                while(dict.Count > 2)
                {
                    var windowStartChar = arr[windowStart];
                    dict[windowStartChar] = dict[windowStartChar] - 1;
                    if (dict[windowStartChar] < 1) dict.Remove(windowStartChar);
                    windowStart++;
                }

                length = Math.Max(length, windowEnd - windowStart + 1);
            }

            return length;
        }

     

        public static void Run()
        {
           Console.WriteLine("Maximum number of fruits: " +
                         FruitsIntoBaskets.FindLength(new char[] { 'A', 'B', 'C', 'A', 'C' }));
            Console.WriteLine("Maximum number of fruits: " +
                                  FruitsIntoBaskets.FindLength(new char[] { 'A', 'B', 'C', 'B', 'B', 'C' }));
            
        }
    }
}
