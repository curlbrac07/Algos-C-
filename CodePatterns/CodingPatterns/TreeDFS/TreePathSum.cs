using System;
namespace TreeDFS
{
    public static class TreePathSum
    {
        public static bool HasPath(TreeNode root, int sum)
        {
            if (root == null) return false;
            return Recursion(root, sum);
        }

        private static bool Recursion(TreeNode root, int sum)
        {
            if (root == null) return sum == 0;

            return Recursion(root.left, sum - root.val) || Recursion(root.right, sum - root.val);
        }

        public static void Run()
        {
            TreeNode root = new TreeNode(12);
            root.left = new TreeNode(7);
            root.right = new TreeNode(1);
            root.left.left = new TreeNode(9);
            root.right.left = new TreeNode(10);
            root.right.right = new TreeNode(5);
            Console.WriteLine("Tree has path: " + TreePathSum.HasPath(root, 23));
            Console.WriteLine("Tree has path: " + TreePathSum.HasPath(root, 16));
        }
    }
}
