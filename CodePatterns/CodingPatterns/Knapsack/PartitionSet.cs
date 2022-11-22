using System;
namespace Knapsack
{
    public  static class PartitionSet
    {
        public static bool CanPartition(int[] num)
        {
            var sum = 0;
            for (int i = 0; i < num.Length; i++) sum += num[i];
            if (sum % 2 != 0) return false;
            var subSum = sum / 2;
            return Recursion(num, 0, subSum);
        }


        private static bool Recursion(int[] num, int currIndex, int sum)
        {
            if (currIndex >= num.Length || sum < 0) return false;

            if (sum == 0) return true;

            var x = Recursion(num, currIndex + 1, sum - num[currIndex]);
            var y = Recursion(num, currIndex + 1, sum);

            return x || y;
        }

        public static bool CanPartitionWithMemoization(int[] num)
        {
            var sum = 0;
            for (int i = 0; i < num.Length; i++) sum += num[i];
            if (sum % 2 != 0) return false;
            var subSum = sum / 2;

            var dp = new bool?[num.Length][];
            for (int i = 0; i < num.Length; i++)
                dp[i] = new bool?[subSum + 1];

            return RecursionWithMemoization(num, 0, subSum, dp);
        }


        private static bool RecursionWithMemoization(int[] num, int currIndex, int sum, bool?[][] dp)
        {
            if (currIndex >= num.Length || sum < 0) return false;

            if (sum == 0) return true;

            if (dp[currIndex][sum] != null) return dp[currIndex][sum].Value;

            var x = Recursion(num, currIndex + 1, sum - num[currIndex]);
            var y = Recursion(num, currIndex + 1, sum);

            dp[currIndex][sum] = x || y;

            return dp[currIndex][sum].Value;
        }


        public static void Run()
        {
            int[] num = { 1, 2, 3, 4 };
            Console.WriteLine(CanPartitionWithMemoization(num));
            num = new int[] { 1, 1, 3, 4, 7 };
            Console.WriteLine(CanPartitionWithMemoization(num));
            num = new int[] { 2, 3, 4, 6 };
            Console.WriteLine(CanPartitionWithMemoization(num));
        }
    }
}
