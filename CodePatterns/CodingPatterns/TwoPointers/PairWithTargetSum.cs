using System;
namespace TwoPointers
{
    public static class PairWithTargetSum
    {
        public static int[] Search(int[] arr, int targetSum)
        {
            int i = 0; int j = arr.Length - 1;

            while(i<j)
            {
                var sum = arr[i] + arr[j];
                if (sum < targetSum) i++;
                else if (sum > targetSum) j--;
                else return new int[] { i, j }; ;
            }
            return new int[] { -1, -1 };
        }


        public static void Run()
        {
            int[] result = PairWithTargetSum.Search(new int[] { 1, 2, 3, 4, 6 }, 6);
            Console.WriteLine("Pair with target sum: [" + result[0] + ", " + result[1] + "]");
            result = PairWithTargetSum.Search(new int[] { 2, 5, 9, 11 }, 11);
            Console.WriteLine("Pair with target sum: [" + result[0] + ", " + result[1] + "]");
        }
    }
}
