using System;
namespace BinarySearch
{
    public static class BinarySearch
    {
        public static int search(int[] arr, int key)
        {
            int lo = 0, hi = arr.Length - 1;

            var ascending = arr[lo] < arr[hi];

            while(lo <= hi)
            {
                int mid = lo + (hi - lo) / 2;

                if (arr[mid] == key) return mid;
                if(ascending)
                {
                    if (key < arr[mid]) hi = mid - 1;
                    else lo = mid + 1;
                }
                else
                {
                    if (key < arr[mid]) lo = mid + 1;
                    else hi = mid - 1;
                }
            }

            return -1;
        }


        public static void Run()
        {
            Console.WriteLine(BinarySearch.search(new int[] { 4, 6, 10 }, 10));
            Console.WriteLine(BinarySearch.search(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 5));
            Console.WriteLine(BinarySearch.search(new int[] { 10, 6, 4 }, 10));
            Console.WriteLine(BinarySearch.search(new int[] { 10, 6, 4 }, 4));
        }
    }
}
