using System;
using System.Collections.Generic;

namespace TopologicalSort
{
    public class TopologicalSortUsingBFS
    {
        public static List<int> sort(int vertices, int[][] edges)
        {
            List<int> sortedOrder = new List<int>();

            var inDegreeVertices = new int[vertices];
            var parentToChildEdges = new HashSet<int>[vertices];

            //Initialize
            for(int i=0; i< edges.Length; i++)
            {
                var parent = edges[i][0];
                var child = edges[i][1];

                inDegreeVertices[child] = inDegreeVertices[child] + 1;
                if (parentToChildEdges[parent] == null) parentToChildEdges[parent] = new HashSet<int>();
                parentToChildEdges[parent].Add(child);
            }

           
            var queue = new Queue<int>();
            for(int i=0; i< vertices; i++)
            {
                if (inDegreeVertices[i] == 0) queue.Enqueue(i);
            }


            while(queue.Count > 0)
            {
                var vertex = queue.Dequeue();
                sortedOrder.Add(vertex);

                var children = parentToChildEdges[vertex];
                if (children == null || children.Count == 0) continue;

                foreach(var child in children)
                {
                    inDegreeVertices[child] = inDegreeVertices[child] - 1;
                    if (inDegreeVertices[child] == 0) queue.Enqueue(child);
                }
            }

            if (sortedOrder.Count != vertices) return new List<int>(); // This means there is a cycle

           
            return sortedOrder;
        }

        public static void Run()
        {
            List<int> result = TopologicalSortUsingBFS.sort(4,
           new int[][] { new int[] { 3, 2 }, new int[] { 3, 0 }, new int[] { 2, 0 }, new int[] { 2, 1 } });
            Console.WriteLine(string.Join(",", result));

            result = TopologicalSortUsingBFS.sort(5, new int[][] { new int[] { 4, 2 }, new int[] { 4, 3 }, new int[] { 2, 0 },
        new int[] { 2, 1 }, new int[] { 3, 1 } });
            Console.WriteLine(string.Join(",", result));

            result = TopologicalSortUsingBFS.sort(7, new int[][] { new int[] { 6, 4 }, new int[] { 6, 2 }, new int[] { 5, 3 },
        new int[] { 5, 4 }, new int[] { 3, 0 }, new int[] { 3, 1 }, new int[] { 3, 2 }, new int[] { 4, 1 } });
            Console.WriteLine(string.Join(",", result));

        }
    }
}
