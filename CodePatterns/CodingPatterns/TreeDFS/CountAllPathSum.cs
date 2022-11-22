using System;
using System.Collections.Generic;

namespace TreeDFS
{
    public static class CountAllPathSum
    {
        public static int countPaths(TreeNode root, int S)
        {
            return Recursion(root, new List<int>(), S);
         
        }

        private static int Recursion(TreeNode root, List<int> currPath, int sum)
        {
            if (root == null) return 0;

            currPath.Add(root.val);

            int pathCount = 0, pathIntermediateSum = 0;
            for(int i=currPath.Count-1; i>=0; i--)
            {
                pathIntermediateSum += currPath[i];
                if (pathIntermediateSum == sum) pathCount++;
            }
        
            pathCount += Recursion(root.left, currPath, sum);
            pathCount += Recursion(root.right, currPath, sum);

            currPath.RemoveAt(currPath.Count - 1);

            return pathCount;
        }

        public static void Run()
        {
            TreeNode root = new TreeNode(12);
            root.left = new TreeNode(7);
            root.right = new TreeNode(1);
            root.left.left = new TreeNode(4);
            root.right.left = new TreeNode(10);
            root.right.right = new TreeNode(5);
            Console.WriteLine("Tree has path: " + CountAllPathSum.countPaths(root, 11));
        }
    }
}
