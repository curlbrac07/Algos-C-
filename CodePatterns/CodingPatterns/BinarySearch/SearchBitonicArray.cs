using System;
namespace BinarySearch
{
    public class SearchBitonicArray
    {
        public static int search(int[] arr, int key)
        {
            int maxIndex = FindMaxIndex(arr);

            var index = BinarySearch(arr, key, 0, maxIndex);

            if (maxIndex == arr.Length - 1 || index > -1) return index;

            return BinarySearch(arr, key, maxIndex + 1, arr.Length - 1);
        }


        private static int FindMaxIndex(int[] arr)
        {
            int lo = 0, hi = arr.Length - 1;

            while(lo < hi)
            {
                int mid = lo + (hi - lo) / 2;

                if (arr[mid] > arr[mid + 1]) hi = mid;
                else lo = mid + 1;
            }

            return lo;
        }

        private static int BinarySearch(int[] arr, int key, int start, int end)
        {
            int lo = start, hi = end;

            while (lo <= hi)
            {
                int mid = lo + (hi - lo) / 2;

                if (arr[mid] == key) return mid;

                if (key < arr[mid]) hi = mid - 1;
                else lo = mid + 1;
            }

            return -1;
        }


        public static void Run()
        {
            Console.WriteLine(SearchBitonicArray.search(new int[] { 1, 3, 8, 4, 3 }, 4));
            Console.WriteLine(SearchBitonicArray.search(new int[] { 3, 8, 3, 1 }, 8));
            Console.WriteLine(SearchBitonicArray.search(new int[] { 1, 3, 8, 12 }, 12));
            Console.WriteLine(SearchBitonicArray.search(new int[] { 10, 9, 8 }, 10));
        }
    }
}
