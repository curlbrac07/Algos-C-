using System;
using System.Collections.Generic;

namespace Subsets
{
    public static class Subsets
    {
        public static List<List<int>> FindSubsets(int[] nums)
        {
            List<List<int>> subsets = new List<List<int>>();

            subsets.Add(new List<int>());
            foreach(var num in nums)
            {
                int size = subsets.Count;

                for(int j=0; j<size; j++)
                {
                    var temp = new List<int>(subsets[j]);
                    temp.Add(num);

                    subsets.Add(temp);
                }
            }

            return subsets;
        }


        public static void Run()
        {
            List<List<int>> result = Subsets.FindSubsets(new int[] { 1, 3 });
            Console.WriteLine("Here is the list of subsets: ");
            foreach (var item in result)
            {
                Console.WriteLine(string.Join(',', item));
            }

            result = Subsets.FindSubsets(new int[] { 1, 5, 3 });
            Console.WriteLine("Here is the list of subsets: ");
            foreach (var item in result)
            {
                Console.WriteLine(string.Join(',', item));
            }

        }
    }
}
