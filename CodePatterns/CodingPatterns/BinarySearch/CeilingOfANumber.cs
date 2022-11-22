using System;
namespace BinarySearch
{
    public static class CeilingOfANumber
    {
        public static int searchCeilingOfANumber(int[] arr, int key)
        {
            if (arr == null || arr.Length == 0 || key > arr[arr.Length - 1]) return -1;

            int lo = 0, hi = arr.Length - 1;

            while(lo <= hi)
            {
                int mid = lo + (hi - lo) / 2;

                if (arr[mid] == key) return mid;

                if (key < arr[mid]) hi = mid - 1;
                else lo = mid + 1;
            }

            return lo;
        }


        public static void Run()
        {
            Console.WriteLine(CeilingOfANumber.searchCeilingOfANumber(new int[] { 4, 6, 10 }, 6));
            Console.WriteLine(CeilingOfANumber.searchCeilingOfANumber(new int[] { 1, 3, 8, 10, 15 }, 12));
            Console.WriteLine(CeilingOfANumber.searchCeilingOfANumber(new int[] { 4, 6, 10 }, 17));
            Console.WriteLine(CeilingOfANumber.searchCeilingOfANumber(new int[] { 4, 6, 10 }, -1));
        }

    }
}
