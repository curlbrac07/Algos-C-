using System;
using System.Collections.Generic;

namespace Subsets
{
    public static class Permutations
    {
        public static List<List<int>> FindPermutations(int[] nums)
        {
            List<List<int>> result = new List<List<int>>();

            var queue = new Queue<List<int>>();
            queue.Enqueue(new List<int>());
            foreach(var num in nums)
            {
                //Take all existing permutations and add existinf number
                var size = queue.Count;
                for(int i = 0; i< size; i++)
                {
                    var list = queue.Dequeue(); // existing permutation

                    for (int j = 0; j <= list.Count; j++)
                    {
                        var tempList = new List<int>(list);
                        tempList.Insert(j, num);

                        if (tempList.Count == nums.Length)
                        {
                            result.Add(tempList);
                        }
                        else
                        {
                            queue.Enqueue(tempList);
                        }
                    }


                }
            }
            
            return result;
        }




        public static void Run()
        {
            List<List<int>> result = Permutations.FindPermutations(new int[] { 1, 3, 5 });
            Console.WriteLine("Here are all the permutations: " );

            foreach(var item in result)
            {
                Console.WriteLine(string.Join(',', item));
            }

        }
    }
}
