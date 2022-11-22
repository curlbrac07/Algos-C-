using System;
using System.Collections.Generic;
namespace CyclicSort
{
    public static class AllMissingNumbers
    {
        public static List<int> FindNumbers(int[] nums)
        {
            var result = new List<int>();

            int i = 0;
            while(i < nums.Length)
            {
                if (nums[i] != nums[nums[i] - 1]) Swap(ref nums[i], ref nums[nums[i] - 1]);
                else i++;
            }

            for (int j = 0; j < nums.Length; j++)
                if (nums[j] != j + 1) result.Add(j + 1);

            return result;
        }

        private static void Swap(ref int x, ref int y)
        {
            var temp = x;
            x = y;
            y = temp;
        }



        public static void Run()
        {
            List<int> missing = AllMissingNumbers.FindNumbers(new int[] { 2, 3, 1, 8, 2, 3, 5, 1 });
            Console.WriteLine("Missing numbers: " + string.Join(",", missing));

            missing = AllMissingNumbers.FindNumbers(new int[] { 2, 4, 1, 2 });
            Console.WriteLine("Missing numbers: " + string.Join(",", missing));

            missing = AllMissingNumbers.FindNumbers(new int[] { 2, 3, 2, 1 });
            Console.WriteLine("Missing numbers: " + string.Join(",", missing));

        }


    }

 
}
