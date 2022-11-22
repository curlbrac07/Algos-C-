using System;
using System.Collections.Generic;

namespace TopologicalSort
{
    public class TaskScheduling
    {
        public static bool isSchedulingPossible(int tasks, int[][] prerequisites)
        {

            var edges = new HashSet<int>[tasks];
            var inDegreeSources = new int[tasks];

            for(int i=0; i< prerequisites.Length; i++)
            {
                var child = prerequisites[i][1];
                var parent = prerequisites[i][0];

                if (edges[parent] == null) edges[parent] = new HashSet<int>();
                edges[parent].Add(child);
                inDegreeSources[child] = inDegreeSources[child] + 1;
            }


            var queue = new Queue<int>();
            for(int i=0; i< tasks; i++)
            {
                if (inDegreeSources[i] == 0) queue.Enqueue(i);
            }

            var list = new List<int>();
            while(queue.Count > 0)
            {
                var vertex = queue.Dequeue();
                list.Add(vertex);

                var children = edges[vertex];
                if (children == null || children.Count == 0) continue;
                foreach(var child in children)
                {
                    inDegreeSources[child] = inDegreeSources[child] - 1;
                    if (inDegreeSources[child] == 0) queue.Enqueue(child);
                }
            }
            
            return list.Count == tasks;

        }




        public static void Run()
        {
            var result = TaskScheduling.isSchedulingPossible(3, new int[][] { new int[] { 0, 1 }, new int[] { 1, 2 } });
            Console.WriteLine("Tasks execution possible: " + result);

            result = TaskScheduling.isSchedulingPossible(3,
                new int[][] { new int[] { 0, 1 }, new int[] { 1, 2 }, new int[] { 2, 0 } });
            Console.WriteLine("Tasks execution possible: " + result);

            result = TaskScheduling.isSchedulingPossible(6, new int[][] { new int[] { 2, 5 }, new int[] { 0, 5 },
        new int[] { 0, 4 }, new int[] { 1, 4 }, new int[] { 3, 2 }, new int[] { 1, 3 } });
            Console.WriteLine("Tasks execution possible: " + result);
        }
    }
}
