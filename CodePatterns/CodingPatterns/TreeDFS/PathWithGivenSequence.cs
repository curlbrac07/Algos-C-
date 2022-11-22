using System;
namespace TreeDFS
{
    public static class PathWithGivenSequence
    {
        public static bool findPath(TreeNode root, int[] sequence)
        {
            if (root == null) return false;
            return Recursion(root, sequence, 0);
        }

        private static bool Recursion(TreeNode root, int[] sequence, int currIndex)
        {
            if (root == null || currIndex >= sequence.Length) return false;

            if (root.val != sequence[currIndex]) return false;

            if(root.left == null && root.right == null && currIndex == sequence.Length - 1)
            {
                return true;
            }

            return Recursion(root.left, sequence, currIndex + 1) || Recursion(root.right, sequence, currIndex + 1);
        }

        public static void Run()
        {
            TreeNode root = new TreeNode(1);
            root.left = new TreeNode(0);
            root.right = new TreeNode(1);
            root.left.left = new TreeNode(1);
            root.right.left = new TreeNode(6);
            root.right.right = new TreeNode(5);

            Console.WriteLine("Tree has path sequence: " + PathWithGivenSequence.findPath(root, new int[] { 1, 0, 7 }));
            Console.WriteLine("Tree has path sequence: " + PathWithGivenSequence.findPath(root, new int[] { 1, 1, 6 }));

        }
    }
}
