using System;
using System.Collections.Generic;

namespace Subsets
{
    public  static class SubsetWithDuplicates
    {

        public static List<List<int>> FindSubsets(int[] nums)
        {
            List<List<int>> subsets = new List<List<int>>();

            Array.Sort(nums);
            subsets.Add(new List<int>());
            int? prev = null;
            var prevSize = 0;
            foreach(var num in nums)
            {
                var size = subsets.Count;

                int startIndex = (prev != null && prev.Value == num) ? size - prevSize : 0;


                for (int j= startIndex; j< size; j++)
                {
                    var tempList = new List<int>(subsets[j]);
                    tempList.Add(num);

                    subsets.Add(tempList);
                }

                prevSize = size;
                prev = num;
            }
           

            return subsets;
        }


        public static void Run()
        {
            List<List<int>> result = SubsetWithDuplicates.FindSubsets(new int[] { 1, 3 , 3});
            Console.WriteLine("Here is the list of subsets: ");
            foreach (var item in result)
            {
                Console.WriteLine(string.Join(',', item));
            }

            result = SubsetWithDuplicates.FindSubsets(new int[] { 1, 5, 3, 3 });
            Console.WriteLine("Here is the list of subsets: ");
            foreach (var item in result)
            {
                Console.WriteLine(string.Join(',', item));
            }

        }


    }
}
