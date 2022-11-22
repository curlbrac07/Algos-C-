using System;
namespace TwoPointers
{
    public static class RemoveDuplicates
    {
        public static int Remove(int[] arr)
        {
            int nextNonDupPtr = 1;

            for(int i=1; i< arr.Length; i++)
            {
                if(arr[nextNonDupPtr - 1] != arr[i])
                {
                    arr[nextNonDupPtr] = arr[i];
                    nextNonDupPtr++;
                }
            }

            return nextNonDupPtr;
        }


        public static void Run()
        {
            int[] arr = new int[] { 2, 3, 3, 3, 6, 9, 9 };
            Console.WriteLine(RemoveDuplicates.Remove(arr));

            arr = new int[] { 2, 2, 2, 11 };
            Console.WriteLine(RemoveDuplicates.Remove(arr));
        }


    }
}
