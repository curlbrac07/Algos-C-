using System;
using System.Collections.Generic;
namespace TwoPointers
{
    public class TripletSumToZero
    {
        public static List<List<int>> searchTriplets(int[] arr)
        {
            List<List<int>> triplets = new List<List<int>>();

            Array.Sort(arr);

            for(int i=0; i< arr.Length; i++)
            {
                int num1 = arr[i];
                if (i > 0 && arr[i] == arr[i - 1]) continue;
                TargetSum(arr, i+1, num1, triplets);
            }

            // TODO: Write your code here
            return triplets;
        }

        private  static void TargetSum(int[] arr, int start, int startNum, List<List<int>> triplets)
        {
            int left = start, right = arr.Length - 1, target = -startNum;

            while (left < right)
            {
                if(arr[left] == target - arr[right])
                {
                    triplets.Add(new List<int>() { startNum, arr[left++], arr[right--] });

                    while (left < right && arr[left] == arr[left - 1]) left++;

                    while (left < right && arr[right] == arr[right + 1]) right--;
                }
                else if(arr[left] + arr[right] < target)
                {
                    left++;
                }
                else
                {
                    right--;
                }
            }
        }

        public static void Run()
        {
            var result = TripletSumToZero.searchTriplets(new int[] { -3, 0, 1, 2, -1, 1, -2 });
            foreach(var item in result)
            {
                Console.WriteLine(string.Join(",", item));
            }
            Console.WriteLine();

            result = TripletSumToZero.searchTriplets(new int[] { -5, 2, -1, -2, 3 });
            foreach (var item in result)
            {
                Console.WriteLine(string.Join(",", item));
            }
            Console.WriteLine();
        }

    }
}
