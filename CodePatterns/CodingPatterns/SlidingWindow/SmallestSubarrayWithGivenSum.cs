using System;
namespace SlidingWindow
{
    public static class SmallestSubarrayWithGivenSum
    {
        public static int FindMinSubArray(int sum, int[] arr)
        {
            var sumInternal = 0;
            var minLength = arr.Length + 1;  //Some dummy no larger..
            var windowStart = 0;
            for(int windowEnd=0; windowEnd< arr.Length; windowEnd++)
            {
                sumInternal += arr[windowEnd];

                while(sumInternal >= sum) //Shrink the window from begininig
                {
                    minLength = Math.Min(minLength, windowEnd - windowStart + 1);
                    sumInternal -= arr[windowStart];
                    windowStart++;
                }
            }

            return minLength == arr.Length + 1 ? 0 : minLength;
        }

        public static void Run()
        {
            int result = SmallestSubarrayWithGivenSum.FindMinSubArray(7, new int[] { 2, 1, 5, 2, 3, 2 });
            Console.WriteLine("Smallest subarray length: " + result);
            result = SmallestSubarrayWithGivenSum.FindMinSubArray(7, new int[] { 2, 1, 5, 2, 8 });
            Console.WriteLine("Smallest subarray length: " + result);
            result = SmallestSubarrayWithGivenSum.FindMinSubArray(8, new int[] { 3, 4, 1, 1, 6 });
            Console.WriteLine("Smallest subarray length: " + result);
        }
    }
}
