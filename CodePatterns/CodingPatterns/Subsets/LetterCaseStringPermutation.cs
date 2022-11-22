using System;
using System.Collections.Generic;
using System.Text;

namespace Subsets
{
    public static class LetterCaseStringPermutation
    {
        public static List<string> FindLetterCaseStringPermutations(string str)
        {
            List<string> permutations = new List<string>();

            if (string.IsNullOrWhiteSpace(str)) return null;

            var array = str.ToCharArray();

            permutations.Add(str);

            for (int j= 0; j< array.Length; j++)
            {
                var ch = array[j];
                if (char.IsDigit(ch)) continue;
                var changedCase = ChangeCase(ch);

                var size = permutations.Count;
                for(int i=0; i<size; i++)
                {
                    var permutationArray = permutations[i].ToCharArray();
                    permutationArray[j] = changedCase;
                    permutations.Add(new string(permutationArray));
                }
            }


            return permutations;
        }

        private  static char ChangeCase(char ch)
        {
            if (char.IsUpper(ch)) return char.ToLower(ch);
            return char.ToUpper(ch);
        }

        public static void Run()
        {
            List<string> result = LetterCaseStringPermutation.FindLetterCaseStringPermutations("ad52");
            Console.WriteLine(" String permutations are: " );
            foreach (var item in result) Console.Write(item + ", ");

            Console.WriteLine();

            result = LetterCaseStringPermutation.FindLetterCaseStringPermutations("ab7c");
            Console.WriteLine(" String permutations are: ");
            foreach (var item in result) Console.Write(item + ", ");
        }
    }
}
