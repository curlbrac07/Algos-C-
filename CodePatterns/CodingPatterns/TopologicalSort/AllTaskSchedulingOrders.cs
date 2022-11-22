using System;
using System.Collections.Generic;

namespace TopologicalSort
{
    public class AllTaskSchedulingOrders
    {
        public static void printOrders(int tasks, int[][] prerequisites)
        {
            var edges = new HashSet<int>[tasks];
            var inDegree = new int[tasks];

            for(int i=0; i< prerequisites.Length; i++)
            {
                var parent = prerequisites[i][0];
                var child = prerequisites[i][1];

                if (edges[parent] == null) edges[parent] = new HashSet<int>();
                edges[parent].Add(child);

                inDegree[child] = inDegree[child] + 1;
            }

            var result = new List<List<int>>();

            var queue = new Queue<int>();
            for(int i = 0; i< tasks; i++)
            {
                if (inDegree[i] == 0)
                {
                    queue.Enqueue(i);

                    result.Add(new List<int>() { i });
                }
            }

            while(queue.Count > 0)
            {
                var vertex = queue.Dequeue();
                var children = edges[vertex];
                if (children == null || children.Count == 0) continue;

                var temp = new List<int>();
                int newInDegreeCount = 0;
                foreach(var child in children)
                {
                    inDegree[child] = inDegree[child] - 1;
                    if (inDegree[child] == 0)
                    {
                        newInDegreeCount++;
                        temp.Add(child);
                        queue.Enqueue(child);

                        foreach (var item in result)
                            item.Add(child);
                    }
                }

                foreach(var x in temp)
                {

                }
            }

            foreach (var item in result)
                Console.WriteLine(string.Join(",", item));
        }

        public static void Run()
        {
            AllTaskSchedulingOrders.printOrders(3, new int[][] { new int[] { 0, 1 }, new int[] { 1, 2 } });
            Console.WriteLine();

            AllTaskSchedulingOrders.printOrders(4,
                new int[][] { new int[] { 3, 2 }, new int[] { 3, 0 }, new int[] { 2, 0 }, new int[] { 2, 1 } });
            Console.WriteLine();

            AllTaskSchedulingOrders.printOrders(6, new int[][] { new int[] { 2, 5 }, new int[] { 0, 5 }, new int[] { 0, 4 },
        new int[] { 1, 4 }, new int[] { 3, 2 }, new int[] { 1, 3 } });
            Console.WriteLine();
        }


    }
}
