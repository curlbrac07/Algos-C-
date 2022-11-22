using System;
namespace BinarySearch
{
    public class FindRange
    {
        public static int[] findRange(int[] arr, int key)
        {
            int[] result = new int[] { -1, -1 };

            result[0] = Search(arr, key, true);

            if (result[0] == -1) return result;
            result[1] = Search(arr, key, false);

            return result;
        }

        private static int Search(int[] arr, int key, bool useLowRange)
        {
            int lo = 0, hi = arr.Length - 1;

            int result = -1;

            while(lo <=hi)
            {
                int mid = lo + (hi - lo) / 2;

                if(arr[mid] == key)
                {
                    result = mid;
                    if (useLowRange)
                        hi = mid - 1;
                    else lo = mid + 1;
                }
                else if(key < arr[mid])
                {
                    hi = mid - 1;
                }
                else
                {
                    lo = mid + 1;
                }
            }

            return result;
        }

        public static void Run()
        {
            int[] result = FindRange.findRange(new int[] { 4, 6, 6, 6, 9 }, 6);
            Console.WriteLine("Range: [" + result[0] + ", " + result[1] + "]");
            result = FindRange.findRange(new int[] { 1, 3, 8, 10, 15 }, 10);
            Console.WriteLine("Range: [" + result[0] + ", " + result[1] + "]");
            result = FindRange.findRange(new int[] { 1, 3, 8, 10, 15 }, 12);
            Console.WriteLine("Range: [" + result[0] + ", " + result[1] + "]");
        }
    }
}
