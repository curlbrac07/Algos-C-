using System;
using System.Collections.Generic;

namespace TreeDFS
{
    public static class FindAllTreePaths
    {
        public static List<List<int>> FindPaths(TreeNode root, int sum)
        {
            var result = new List<List<int>>();
            if (root == null) return result;
            Recursion(root, sum, result, new List<int>());
            return result;
        }

        private static void Recursion(TreeNode root, int sum, List<List<int>> result, List<int> subList)
        {
            if (root == null) return;

            subList.Add(root.val);
            if (root.val == sum && root.left == null && root.right == null)
            {
                result.Add(new List<int>(subList));
            }
            else
            {
                Recursion(root.left, sum - root.val, result, subList);
                Recursion(root.right, sum - root.val, result, subList);
            }
            
            
            subList.RemoveAt(subList.Count - 1);
        }

        public static void Run()
        {
            TreeNode root = new TreeNode(12);
            root.left = new TreeNode(7);
            root.right = new TreeNode(1);
            root.left.left = new TreeNode(4);
            root.right.left = new TreeNode(10);
            root.right.right = new TreeNode(5);
            int sum = 23;
            List<List<int>> result = FindAllTreePaths.FindPaths(root, sum);
            Console.WriteLine("Tree paths with sum " + sum + ": " );
            foreach (var item in result)
                Console.WriteLine(string.Join(",", item));
        }
    }
}
