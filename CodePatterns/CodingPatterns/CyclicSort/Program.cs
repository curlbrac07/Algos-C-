using System;

namespace CyclicSort
{
    class Program
    {
        static void Main(string[] args)
        {
            //CyclicSort.Run();

            //MissingNumber.Run();

            //AllMissingNumbers.Run();
            //FindDuplicate.Run();

            Console.WriteLine(5 ^ 5);

            Console.WriteLine(5 ^ 7);

        }

        private static void Swap(ref int x, ref int y)
        {
            x ^= y;

            y ^= x;   // This becomes y = y ^ (x ^ y) ==> x

            x ^= y;   // x from step 1 is x^y(old y value). This becomes x = (x ^ old_y) ^ x ==> old_y;
        }

        private static bool IsOdd(int x) 
        {
            return (x & 1) == 1;
        }

        private static bool IsEven(int x) 
        {
            return (x & 1) == 0;
        }


        private static string ToUpper(string s) // bitwise AND with ‘_’ to get UPPER
        {
            var charArray = s.ToCharArray();

            for(int i=0; i< charArray.Length; i++)
            {
                charArray[i] &= '_';
            }

            return new string(charArray);
        }

        private static string ToLower(string s) // bitwise OR with ‘ ’ to get lower 
        {
            var charArray = s.ToCharArray();

            for (int i = 0; i < charArray.Length; i++)
            {
                charArray[i] |= ' ';
            }

            return new string(charArray);
        }

        private static string ToggleCase(string s) // // Bitwise EXOR with 32
        {
            var charArray = s.ToCharArray();

            for (int i = 0; i < charArray.Length; i++)
            {
                charArray[i] ^= (char)32;
            }

            return new string(charArray);
        }
    }
}
