using System;
namespace CyclicSort
{
    public static class FirstSmallestMissingPositive
    {

        public static int FindNumber(int[] nums)
        {
            return -1;
        }


        public static void Run()
        {
            Console.WriteLine(FirstSmallestMissingPositive.FindNumber(new int[] { -3, 1, 5, 4, 2 }));
            Console.WriteLine(FirstSmallestMissingPositive.FindNumber(new int[] { 3, -2, 0, 1, 2 }));
            Console.WriteLine(FirstSmallestMissingPositive.FindNumber(new int[] { 3, 2, 5, 1 }));
        }
    }
}
