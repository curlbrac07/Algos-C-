using System;
namespace CyclicSort
{
    public  static class FindCorruptNums
    {
        public static int[] FindNumbers(int[] nums)
        {
            return null;
        }

        public static void Run()
        {
     
            int[] nums = FindCorruptNums.FindNumbers(new int[] { 3, 1, 2, 5, 2 });
            Console.WriteLine(nums[0] + ", " + nums[1]);
            nums = FindCorruptNums.FindNumbers(new int[] { 3, 1, 2, 3, 6, 4 });
            Console.WriteLine(nums[0] + ", " + nums[1]);

        }
    }
}
