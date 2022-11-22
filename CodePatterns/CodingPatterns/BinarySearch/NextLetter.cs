using System;
namespace BinarySearch
{
    public class NextLetter
    {
        public static char searchNextLetter(char[] letters, char key)
        {
            int lo = 0, hi = letters.Length - 1;
            int result = -1;

            while(lo <= hi)
            {
                int mid = lo + (hi - lo) / 2;
                if(letters[mid] == key)
                {
                    result = mid;
                    break;
                }

                if (key < letters[mid]) hi = mid - 1;
                else lo = mid + 1;
            }

            if (lo > hi) result = hi;

            return result == letters.Length-1? letters[0] : letters[result + 1];
        }

        public static void Run()
        {
            Console.WriteLine(NextLetter.searchNextLetter(new char[] { 'a', 'c', 'f', 'h' }, 'f'));
            Console.WriteLine(NextLetter.searchNextLetter(new char[] { 'a', 'c', 'f', 'h' }, 'b'));
            Console.WriteLine(NextLetter.searchNextLetter(new char[] { 'a', 'c', 'f', 'h' }, 'm'));
            Console.WriteLine(NextLetter.searchNextLetter(new char[] { 'a', 'c', 'f', 'h' }, 'h'));
        }
    }
}
