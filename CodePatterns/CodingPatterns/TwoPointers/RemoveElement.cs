using System;
namespace TwoPointers
{
    public class RemoveElement
    {

        public static int Remove(int[] arr, int key)
        {
            int nextPtr = 0;

            for(int i=0; i< arr.Length; i++)
            {
                if(arr[i] != key)
                {
                    arr[nextPtr] = arr[i];
                    nextPtr++;
                }
            }

            return nextPtr;
        }


        public static void Run()
        {
            int[] arr = new int[] { 3, 2, 3, 6, 3, 10, 9, 3 };
            Console.WriteLine(RemoveElement.Remove(arr, 3));

            arr = new int[] { 2, 11, 2, 2, 1 };
            Console.WriteLine(RemoveElement.Remove(arr, 2));
        }
    }
}
