using System;
using System.Collections.Generic;
namespace CyclicSort
{
    public static class FindDuplicate
    {
        public static int FindNumber(int[] nums)
        {
            int i = 0;
            while(i < nums.Length)
            {
                if (nums[i] != nums[nums[i] - 1]) Swap(ref nums[i], ref nums[nums[i] - 1]);
                else i++;
            }

            for (int j = 0; j < nums.Length; j++)
                if (j + 1 != nums[j]) return nums[j];

            return -1;
        }

        private static void Swap(ref int x, ref int y)
        {
            var temp = x;
            x = y;
            y = temp;
        }



        public static void Run()
        {
            Console.WriteLine(FindDuplicate.FindNumber(new int[] { 1, 4, 4, 3, 2 }));
            Console.WriteLine(FindDuplicate.FindNumber(new int[] { 2, 1, 3, 3, 5, 4 }));
            Console.WriteLine(FindDuplicate.FindNumber(new int[] { 2, 4, 1, 4, 4 }));

        }


    }

 
}
