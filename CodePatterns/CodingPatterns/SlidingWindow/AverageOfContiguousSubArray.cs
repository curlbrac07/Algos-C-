using System;
namespace SlidingWindow
{
    public static class AverageOfContiguousSubArray
    {
      

        public static double[] FindAveragesBruteForce(int k, int[] arr)
        {
            var resultCount = arr.Length - k + 1;
            var result = new double[resultCount];

            for(int i=0; i< resultCount; i++)
            {
                double sum = 0;
                for(int j=i;j<i+k;j++)
                {
                    sum += arr[j];
                }
                result[i] = sum / k;
            }

            return result;
        }

        public static double[] FindAverages(int k, int[] arr)
        {
            var resultCount = arr.Length - k + 1;
            var result = new double[resultCount];

            double sum = 0;
            var index = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];

                if(i+1 >=k)
                {
                    result[index] = sum / k;
                    sum -= arr[index];
                    index = index + 1;
                }
            }

            return result;
        }

        public static void Run()
        {
            double[] result1 = AverageOfContiguousSubArray.FindAveragesBruteForce(5, new int[] { 1, 3, 2, 6, -1, 4, 1, 8, 2 });
            double[] result2 = AverageOfContiguousSubArray.FindAverages(5, new int[] { 1, 3, 2, 6, -1, 4, 1, 8, 2 });
            Console.WriteLine("Averages of subarrays of size K: " + string.Join(",", result1));
            Console.WriteLine("Averages of subarrays of size K: " + string.Join(",", result2));
        }
    }
}
