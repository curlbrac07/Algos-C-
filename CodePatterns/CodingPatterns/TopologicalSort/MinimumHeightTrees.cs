using System;
using System.Collections.Generic;

namespace TopologicalSort
{
    public class MinimumHeightTrees
    {
        public static List<int> findTrees(int nodes, int[][] edges)
        {
            List<int> minHeightTrees = new List<int>();
            if (nodes <= 0) return minHeightTrees;

            if(nodes == 1)
            {
                minHeightTrees.Add(0);
                return minHeightTrees;
            }

            var edgesList = new List<int>[nodes];
            var inDegrees = new int[nodes];

            for(int i=0; i< edges.Length; i++)
            {
                var parent = edges[i][0];
                var child = edges[i][1];

                if (edgesList[i] == null) edgesList[i] = new List<int>();
                edgesList[parent].Add(child);
                edgesList[child].Add(parent); // Its undirected graph

                inDegrees[child] = inDegrees[child] + 1;
                inDegrees[parent] = inDegrees[parent] + 1;
            }


            //Leafs - Indegrees with 1
            var queue = new Queue<int>();
            for(int i=0; i< inDegrees.Length; i++)
            {
                if (inDegrees[i] == 1) queue.Enqueue(i);
            }

            var totalNodes = nodes;
            while(totalNodes > 2)
            {
                var leaves = queue.Count;
                totalNodes = totalNodes - leaves;

                for (int i=0; i< leaves; i++)
                {
                    var element = queue.Dequeue();
                    var children = edgesList[element];
                    if (children == null || children.Count == 0) continue;
                    foreach (var child in children)
                    {
                        inDegrees[child] = inDegrees[child] - 1;
                        if (inDegrees[child] == 1) queue.Enqueue(child);
                    }
                }
            }


            while (queue.Count > 0) minHeightTrees.Add(queue.Dequeue());

            // TODO: Write your code here
            return minHeightTrees;
        }

        public static void Run()
        {
            List<int> result = MinimumHeightTrees.findTrees(5,
        new int[][] { new int[] { 0, 1 }, new int[] { 1, 2 }, new int[] { 1, 3 }, new int[] { 2, 4 } });
            Console.WriteLine("Roots of MHTs: " + result);

            result = MinimumHeightTrees.findTrees(4,
                new int[][] { new int[] { 0, 1 }, new int[] { 0, 2 }, new int[] { 2, 3 } });
            Console.WriteLine("Roots of MHTs: " + result);

            result = MinimumHeightTrees.findTrees(4,
                new int[][] { new int[] { 0, 1 }, new int[] { 1, 2 }, new int[] { 1, 3 } });
            Console.WriteLine("Roots of MHTs: " + result);
        }
    }
}
