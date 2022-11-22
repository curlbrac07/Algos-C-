using System;
using System.Collections.Generic;

namespace CyclicSort
{
    public static class FindAllDuplicate
    {
        public static List<int> FindNumbers(int[] nums)
        {
            return null;
        }

        public static void Run()
        {
            List<int> duplicates = FindAllDuplicate.FindNumbers(new int[] { 3, 4, 4, 5, 5 });
            Console.WriteLine("Duplicates are: " + duplicates);

            duplicates = FindAllDuplicate.FindNumbers(new int[] { 5, 4, 7, 2, 3, 5, 3 });
            Console.WriteLine("Duplicates are: " + duplicates);

        }
    }
}
