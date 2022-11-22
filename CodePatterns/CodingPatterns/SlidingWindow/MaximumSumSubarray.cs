using System;
namespace SlidingWindow
{
    public static class MaximumSumSubarray
    {
        public static int FindMaxSumSubArray(int k, int[] arr)
        {
            var windowSum = 0;
            var maxSum = 0;
            var windowStart = 0;
            for(int windowEnd = 0; windowEnd < arr.Length; windowEnd++)
            {
                windowSum += arr[windowEnd];

                if(windowEnd + 1 >= k)
                {
                    maxSum = Math.Max(windowSum, maxSum);
                    windowSum -= arr[windowStart];
                    windowStart++;
                }
            }

            return maxSum;

        }

        public static void Run()
        {
            Console.WriteLine("Maximum sum of a subarray of size K: "
        + MaximumSumSubarray.FindMaxSumSubArray(3, new int[] { 2, 1, 5, 1, 3, 2 }));
            Console.WriteLine("Maximum sum of a subarray of size K: "
                + MaximumSumSubarray.FindMaxSumSubArray(2, new int[] { 2, 3, 4, 1, 5 }));
        }
    }
}
