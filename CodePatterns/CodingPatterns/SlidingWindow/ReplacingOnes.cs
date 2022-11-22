using System;
namespace SlidingWindow
{
    public class ReplacingOnes
    {

        public static int findLength(int[] arr, int k)
        {

            int maxLength = 0, windowStart = 0, oneCount = 0;
            for(int windowEnd = 0; windowEnd<arr.Length; windowEnd++)
            {
                if (arr[windowEnd] == 1) oneCount++;
                var windowSize = windowEnd - windowStart + 1;

                if(windowSize - oneCount > k)
                {
                    if (arr[windowStart] == 1) oneCount--;
                    windowStart++;
                }

                maxLength = Math.Max(maxLength, windowEnd - windowStart + 1);

            }
            return maxLength;
        }


        public static void Run()
        {
            Console.WriteLine(ReplacingOnes.findLength(new int[] { 0, 1, 1, 0, 0, 0, 1, 1, 0, 1, 1 }, 2));
            Console.WriteLine(ReplacingOnes.findLength(new int[] { 0, 1, 0, 0, 1, 1, 0, 1, 1, 0, 0, 1, 1 }, 3));

        }
    }
}
