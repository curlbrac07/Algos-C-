using System;
using System.Collections.Generic;

namespace TopologicalSort
{
    public static  class TopologicalSort
    {

        public static List<int> sort(int vertices, int[][] edges)
        {
            List<int> sortedOrder = new List<int>();

            var dict = new Dictionary<int, List<int>>();


            for(int i=0; i< edges.Length; i++)
            {
                List<int> list;
                if (!dict.TryGetValue(edges[i][0], out list)) list = new List<int>();
                list.Add(edges[i][1]);
                dict[edges[i][0]] = list;
            }

            var stack = new Stack<int>();
            var visited = new HashSet<int>();

            for (int i = 0; i < vertices; i++)
            {
                if (visited.Contains(i)) continue;
                Dfs(visited, i, dict, stack);

            }

            while(stack.Count > 0)
            {
                sortedOrder.Add(stack.Pop());
            }
                                                                                                                                                                                                                                                                                                                                                                                                                                   
            return sortedOrder;
        }

        private  static void Dfs(HashSet<int> visited, int vertex, Dictionary<int, List<int>> dict, Stack<int> stack)
        {
            if (visited.Contains(vertex)) return;
            visited.Add(vertex);
            dict.TryGetValue(vertex, out var adjacentNodes);
            if(adjacentNodes == null || adjacentNodes.Count < 1)
            {
                stack.Push(vertex);
                return;
            }

            foreach (var node in adjacentNodes)
            {
                if (visited.Contains(node)) continue;
                Dfs(visited, node, dict, stack);
             }

            stack.Push(vertex);
        }


        public static void Run()
        {
            List<int> result = TopologicalSort.sort(4,
            new int[][] { new int[] { 3, 2 }, new int[] { 3, 0 }, new int[] { 2, 0 }, new int[] { 2, 1 } });
            Console.WriteLine(string.Join(",", result));

            result = TopologicalSort.sort(5, new int[][] { new int[] { 4, 2 }, new int[] { 4, 3 }, new int[] { 2, 0 },
        new int[] { 2, 1 }, new int[] { 3, 1 } });
            Console.WriteLine(string.Join(",", result));

            result = TopologicalSort.sort(7, new int[][] { new int[] { 6, 4 }, new int[] { 6, 2 }, new int[] { 5, 3 },
        new int[] { 5, 4 }, new int[] { 3, 0 }, new int[] { 3, 1 }, new int[] { 3, 2 }, new int[] { 4, 1 } });
            Console.WriteLine(string.Join(",", result));

        }
    }
}
