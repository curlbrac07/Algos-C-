using System;
using System.Collections.Generic;
namespace CyclicSort
{
    public static class CyclicSort
    {
        public static void Sort(int[] nums)
        {
            var i = 0;

            while(i < nums.Length)
            {
                if ((i + 1) != nums[i])
                {
                    Swap(ref nums[i], ref nums[nums[i] - 1]);
                }
                else
                {
                    i++;
                }
            }
        }

        private static void Swap(ref int x, ref int y)
        {
            var temp = x;
            x = y;
            y = temp;
        }



        public static void Run()
        {
            int[] arr = new int[] { 3, 1, 5, 4, 2 };
            CyclicSort.Sort(arr);
            foreach (int num in arr)
                Console.Write(num + " ");
            Console.WriteLine();

            arr = new int[] { 2, 6, 4, 3, 1, 5 };
            CyclicSort.Sort(arr);
            foreach (int num in arr)
                Console.Write(num + " ");
            Console.WriteLine();

            arr = new int[] { 1, 5, 6, 4, 3, 2 };
            CyclicSort.Sort(arr);
            foreach (int num in arr)
                Console.Write(num + " ");
            Console.WriteLine();

        }


    }

 
}
