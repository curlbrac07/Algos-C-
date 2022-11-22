using System;
namespace TwoPointers
{
    public class SortedArraySquares
    {
        //Build the squares array from right to left
        public static int[] MakeSquares_Approach2(int[] arr)
        {
            int n = arr.Length;
            int[] squares = new int[n];
            int left = 0, right = n - 1;

            int index = n - 1;
            while(left <=right)
            {
                var leftSq = arr[left] * arr[left];
                var rightSq = arr[right] * arr[right];

                if(leftSq > rightSq)
                {
                    squares[index--] = leftSq;
                    left++;
                }
                else
                {
                    squares[index--] = rightSq;
                    right--;
                }
            }

            return squares;

        }
        public static int[] MakeSquares(int[] arr)
        {
            int[] squares = new int[arr.Length];

            int lastNegativeInt = -1;
            for (int j = 0; j < arr.Length; j++)
            {
                if (arr[j] >= 0)
                {
                    lastNegativeInt = j - 1;
                    break;
                }
            }
            int firstPos = lastNegativeInt + 1;

            int i = 0;
            while(lastNegativeInt >= 0 && firstPos <= (arr.Length-1))
            {
                var negSquare = arr[lastNegativeInt] * arr[lastNegativeInt];
                var posSquare = arr[firstPos] * arr[firstPos];

                if(negSquare < posSquare)
                {
                    squares[i++] = negSquare;
                    lastNegativeInt--;
                }
                else if(negSquare > posSquare)
                {
                    squares[i++] = posSquare;
                    firstPos++;
                }
                else
                {
                    squares[i++] = negSquare;
                    squares[i++] = negSquare;
                    firstPos++;
                    lastNegativeInt--;
                }
            }

            while (lastNegativeInt >= 0)
            {
                squares[i++] = arr[lastNegativeInt] * arr[lastNegativeInt];
                lastNegativeInt--;
            }

            while(firstPos <= arr.Length - 1)
            {
                squares[i++] = arr[firstPos] * arr[firstPos];
                firstPos++;
            }

            return squares;
        }


        public static void Run()
        {
            int[] result = SortedArraySquares.MakeSquares_Approach2(new int[] { -2, -1, 0, 2, 3 });
            foreach(var num in result)
                Console.Write(num + " ");
            Console.WriteLine();

            result = SortedArraySquares.MakeSquares_Approach2(new int[] { -3, -1, 0, 1, 2 });
            foreach (var num in result)
                Console.Write(num + " ");
            Console.WriteLine();
        }


    }
}
