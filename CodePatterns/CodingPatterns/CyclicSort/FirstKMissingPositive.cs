using System;
using System.Collections.Generic;

namespace CyclicSort
{
    public static class FirstKMissingPositive
    {
      
        public static List<int> FindNumbers(int[] nums, int k)
        {
            return null;
        }


        public static void Run()
        {
  
            List<int> missingNumbers = FirstKMissingPositive.FindNumbers(new int[] { 3, -1, 4, 5, 5 }, 3);
            Console.WriteLine("Missing numbers: " + missingNumbers);

            missingNumbers = FirstKMissingPositive.FindNumbers(new int[] { 2, 3, 4 }, 3);
            Console.WriteLine("Missing numbers: " + missingNumbers);

            missingNumbers = FirstKMissingPositive.FindNumbers(new int[] { -2, -3, 4 }, 2);
            Console.WriteLine("Missing numbers: " + missingNumbers);

        }

    }
}
