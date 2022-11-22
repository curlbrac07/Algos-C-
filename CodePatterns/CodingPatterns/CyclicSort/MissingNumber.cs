using System;
using System.Collections.Generic;
namespace CyclicSort
{
    public static class MissingNumber
    {
        public static int FindMissingNumber(int[] nums)
        {

            int i = 0;
            while(i < nums.Length)
            {
                if (nums[i] >= nums.Length) continue;
                if (nums[i] != nums[nums[i]]) Swap(ref nums[i], ref nums[nums[i]]);
                else i++;
            }

            for (int j = 0; j < nums.Length; j++)
                if (j != nums[j]) return j;

            return nums.Length;
        }

        private static void Swap(ref int x, ref int y)
        {
            var temp = x;
            x = y;
            y = temp;
        }



        public static void Run()
        {
            Console.WriteLine(MissingNumber.FindMissingNumber(new int[] { 4, 0, 3, 1 }));
            Console.WriteLine(MissingNumber.FindMissingNumber(new int[] { 8, 3, 5, 2, 4, 6, 0, 1 }));

        }


    }

 
}
