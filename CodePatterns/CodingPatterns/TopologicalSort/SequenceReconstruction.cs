using System;
using System.Collections.Generic;

namespace TopologicalSort
{
    public class SequenceReconstruction
    {
        public static bool canConstruct(int[] originalSeq, int[][] sequences)
        {
            var count = originalSeq.Length;
            var edges = new List<int>[count];
            var inDegrees = new int[count];

  
            for(int i=0; i< sequences.Length; i++)
            {
                var parent = sequences[i][0];
                if (edges[parent] == null) edges[parent] = new List<int>();
                for (int j=1; j<sequences[i].Length; j++)
                {
                    var child = sequences[i][j];
                    edges[parent].Add(child);
                    inDegrees[child] = inDegrees[child] + 1;
                }
            }

   
            var queue = new Queue<int>();
            for(int i=0; i< count; i++)
            {
                if (inDegrees[i] == 0) queue.Enqueue(i);
            }

            var next = 0;
            
            while(queue.Count > 0)
            {
                var element = queue.Dequeue();
                if (element == originalSeq[next]) next++;
                var children = edges[element];

                if (children == null || children.Count == 0) continue;
                foreach(var child in children)
                {
                    inDegrees[child] = inDegrees[child] - 1;
                    if(inDegrees[child] == 0) queue.Enqueue(child);
                }
            }

            if (next == count - 1) return true;


            return false;
        }
        
        public static void Run()
        {
            bool result = SequenceReconstruction.canConstruct(new int[] { 1, 2, 3, 4 },
       new int[][] { new int[] { 1, 2 }, new int[] { 2, 3 }, new int[] { 3, 4 } });
            Console.WriteLine("Can we uniquely construct the sequence: " + result);

            result = SequenceReconstruction.canConstruct(new int[] { 1, 2, 3, 4 },
                new int[][] { new int[] { 1, 2 }, new int[] { 2, 3 }, new int[] { 2, 4 } });
            Console.WriteLine("Can we uniquely construct the sequence: " + result);

            result = SequenceReconstruction.canConstruct(new int[] { 3, 1, 4, 2, 5 },
                new int[][] { new int[] { 3, 1, 5 }, new int[] { 1, 4, 2, 5 } });
            Console.WriteLine("Can we uniquely construct the sequence: " + result);
        }
    }
}
