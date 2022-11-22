using System;
namespace BinarySearch
{
    public class SearchInfiniteSortedArray
    {
        public static int search(ArrayReader reader, int key)
        {
            int lo = 0, hi = 0;

            while(lo <= hi && reader.get(hi) < key)
            {
                var newLo = hi + 1;
                hi += (hi - lo + 1) * 2;
                lo = newLo;
            }

            return search(reader, key, lo, hi);
        }


        public static int search(ArrayReader reader, int key, int start, int end)
        {
            int lo = start, hi = end;

            while (lo <= hi)
            {
                int mid = lo + (hi - lo) / 2;

                var val = reader.get(mid);

                if (val == key) return mid;

                if (key < val) hi = mid - 1;
                else lo = mid + 1;

            }

            return -1;
        }

        public static void Run()
        {
            ArrayReader reader = new ArrayReader(new int[] { 4, 6, 8, 10, 12, 14, 16, 18, 20, 22, 24, 26, 28, 30 });
            Console.WriteLine(SearchInfiniteSortedArray.search(reader, 16));
            Console.WriteLine(SearchInfiniteSortedArray.search(reader, 11));
            reader = new ArrayReader(new int[] { 1, 3, 8, 10, 15 });
            Console.WriteLine(SearchInfiniteSortedArray.search(reader, 15));
            Console.WriteLine(SearchInfiniteSortedArray.search(reader, 200));
        }
    }

    public class ArrayReader
    {
        int[] arr;

        public ArrayReader(int[] arr)
        {
            this.arr = arr;
        }

        public int get(int index)
        {
            if (index >= arr.Length)
                return Int32.MaxValue;
            return arr[index];
        }
    }
}
