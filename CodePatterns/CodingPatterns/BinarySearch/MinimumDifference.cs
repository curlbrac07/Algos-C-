using System;
namespace BinarySearch
{
    public class MinimumDifference
    {
        public static int searchMinDiffElement(int[] arr, int key)
        {
            if (key > arr[arr.Length - 1]) return arr[arr.Length - 1];
            if (key < arr[0]) return arr[0];

            int lo = 0, hi = arr.Length - 1;
            while(lo <= hi)
            {
                int mid = lo + (hi - lo) / 2;

                if (arr[mid] == key) return key;

                if (key < arr[mid]) hi = mid - 1;
                else lo = mid + 1;
            }

            if ( Math.Abs(arr[lo] - key) > Math.Abs(arr[hi] - key)) return arr[hi];
            return arr[lo];
        }

        public static void Run()
        {
            Console.WriteLine(MinimumDifference.searchMinDiffElement(new int[] { 4, 6, 10 }, 7));
            Console.WriteLine(MinimumDifference.searchMinDiffElement(new int[] { 4, 6, 10 }, 4));
            Console.WriteLine(MinimumDifference.searchMinDiffElement(new int[] { 1, 3, 8, 10, 15 }, 12));
            Console.WriteLine(MinimumDifference.searchMinDiffElement(new int[] { 4, 6, 10 }, 17));
        }
    }
}
