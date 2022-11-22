using System;
namespace TwoPointers
{
    public class TripletWithSmallerSum
    {
        public static int searchTriplets(int[] arr, int target)
        {
            int count = 0;

            Array.Sort(arr);

            for(int i=0; i< arr.Length - 2; i++)
            {
                int left = i + 1, right = arr.Length - 1;

                while(left < right)
                {
                    var sum = arr[i] + arr[left] + arr[right];

                   if(sum < target)
                    {
                        count++;
                        right--;
                    }
                    else
                    {
                        left++;
                    }
                }
            }
            return count;
        }

        public static void Run()
        {
            Console.WriteLine(TripletWithSmallerSum.searchTriplets(new int[] { -1, 0, 2, 3 }, 3));
            Console.WriteLine(TripletWithSmallerSum.searchTriplets(new int[] { -1, 4, 2, 1, 3 }, 5)); // -1, 1, 2, 3, 4
        }
    }
}
