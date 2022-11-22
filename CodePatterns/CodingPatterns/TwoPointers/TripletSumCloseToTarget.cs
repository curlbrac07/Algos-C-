using System;
namespace TwoPointers
{
    public class TripletSumCloseToTarget
    {
        public static int searchTriplet(int[] arr, int targetSum)
        {
            int minDiffBetweenSumAndTarget = Int32.MaxValue;
            Array.Sort(arr);
            for (int i=0; i< arr.Length-2; i++)
            {
                int left = i+1, right = arr.Length - 1;
                while (left < right)
                {
                    var sum = arr[i] + arr[left] + arr[right];
                    var diff = targetSum - sum;
                    if (diff == 0) return sum;

                    minDiffBetweenSumAndTarget = Math.Min(minDiffBetweenSumAndTarget, Math.Abs(diff));
       
                    if (diff < 0) right--; // targetSum - sum < 0 ==> targetSum < Sum ==> Sum > targetSum
                    else left++;
                    left++;
                    right--;
                }
            }
            return targetSum - minDiffBetweenSumAndTarget;
        }

        public static void Run()
        {
            Console.WriteLine(TripletSumCloseToTarget.searchTriplet(new int[] { -2, 0, 1, 2 }, 2));
            Console.WriteLine(TripletSumCloseToTarget.searchTriplet(new int[] { -3, -1, 1, 2 }, 1));
            Console.WriteLine(TripletSumCloseToTarget.searchTriplet(new int[] { 1, 0, 1, 1 }, 100));
        }
    }
}
