using System;
namespace Knapsack
{
    public static class SubsetSum
    {
        public static bool CanPartition(int[] num, int sum)
        {
            return Recursion(num, sum, 0);
        }

        private static bool Recursion(int[] num, int sum, int currIndex)
        {
            if (sum == 0) return true;

            if (currIndex >= num.Length || sum < 0) return false;


            var x = Recursion(num, sum - num[currIndex], currIndex + 1);
            var y = Recursion(num, sum, currIndex + 1);

            return x || y;
        }

        public static void Run()
        {
            int[] num = { 1, 2, 3, 7 };
            Console.WriteLine(CanPartition(num, 6));
            num = new int[] { 1, 2, 7, 1, 5 };
            Console.WriteLine(CanPartition(num, 10));
            num = new int[] { 1, 3, 4, 8 };
            Console.WriteLine(CanPartition(num, 6));
        }
    }
}
