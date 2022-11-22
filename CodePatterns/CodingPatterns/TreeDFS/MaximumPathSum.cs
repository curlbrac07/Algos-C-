using System;
namespace TreeDFS
{
    public static class MaximumPathSum
    {
        public static int findMaximumPathSum(TreeNode root)
        {
            int? maxSum = null;
            PathSum(root, ref maxSum);
            return maxSum.Value;
        }

        private static int PathSum(TreeNode root, ref int? maxSum)
        {
            if (root == null) return 0;


            var sum = root.val + PathSum(root.left, ref maxSum) + PathSum(root.right, ref maxSum);

            maxSum = maxSum==null? sum :  Math.Max(maxSum.Value, sum);

            return root.val + Math.Max(PathSum(root.left, ref maxSum), PathSum(root.right, ref maxSum));
        }

        public static void Run()
        {
            TreeNode root = new TreeNode(1);
            root.left = new TreeNode(2);
            root.right = new TreeNode(3);
            Console.WriteLine("Maximum Path Sum: " + MaximumPathSum.findMaximumPathSum(root));

            root.left.left = new TreeNode(1);
            root.left.right = new TreeNode(3);
            root.right.left = new TreeNode(5);
            root.right.right = new TreeNode(6);
            root.right.left.left = new TreeNode(7);
            root.right.left.right = new TreeNode(8);
            root.right.right.left = new TreeNode(9);
            Console.WriteLine("Maximum Path Sum: " + MaximumPathSum.findMaximumPathSum(root));

            root = new TreeNode(-1);
            root.left = new TreeNode(-3);
            Console.WriteLine("Maximum Path Sum: " + MaximumPathSum.findMaximumPathSum(root));

        }
    }
}
