using System;
namespace BinarySearch
{
    public class MaxInBitonicArray
    {
        public static int findMax(int[] arr)
        {
            int lo = 0, hi = arr.Length - 1;

            while(lo < hi)
            {
                int mid = lo + (hi - lo) / 2;

                if (arr[mid] < arr[mid + 1]) lo = mid + 1;
                else hi = mid;
            }
            return arr[lo]; // It can be hi too.. as loop exits when lo = high
        }


        public static void Run()
        {
            Console.WriteLine(MaxInBitonicArray.findMax(new int[] { 1, 3, 8, 12, 4, 2 }));
            Console.WriteLine(MaxInBitonicArray.findMax(new int[] { 3, 8, 3, 1 }));
            Console.WriteLine(MaxInBitonicArray.findMax(new int[] { 1, 3, 8, 12 }));
            Console.WriteLine(MaxInBitonicArray.findMax(new int[] { 10, 9, 8 }));
        }

    }
}
