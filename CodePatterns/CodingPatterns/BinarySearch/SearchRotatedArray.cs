using System;
namespace BinarySearch
{
    public class SearchRotatedArray
    {
        public static int search(int[] arr, int key)
        {
            int lo = 0, hi = arr.Length - 1;

            while(lo < hi)
            {
                int mid = lo + (hi - lo) / 2;

                if (arr[mid] < arr[mid + 1]) lo = mid + 1;
                else hi = mid;
            }

            return lo;
        }

        public static void Run()
        {
            Console.WriteLine(SearchRotatedArray.search(new int[] { 10, 15, 1, 3, 8 }, 15));
            Console.WriteLine(SearchRotatedArray.search(new int[] { 4, 5, 7, 9, 10, -1, 2 }, 10));
        }
    }
}
