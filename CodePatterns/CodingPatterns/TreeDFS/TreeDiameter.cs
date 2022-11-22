using System;
namespace TreeDFS
{
    public static  class TreeDiameter
    {
        public static int findDiameter(TreeNode root)
        {
            // TODO: Write your code here
            int max = 0;
            Height(root, ref max);

            return max;
        }


        private static int Height(TreeNode root, ref int max)
        {
            if (root == null) return 0;

            var diameter = 1 + Height(root.left, ref max) + Height(root.right, ref max);
            max = Math.Max(max, diameter);

            return 1 + Math.Max(Height(root.left, ref max) , Height(root.right, ref max));
        }


        public static void Run()
        {
            TreeNode root = new TreeNode(1);
            root.left = new TreeNode(2);
            root.right = new TreeNode(3);
            root.left.left = new TreeNode(4);
            root.right.left = new TreeNode(5);
            root.right.right = new TreeNode(6);
            Console.WriteLine("Tree Diameter: " + TreeDiameter.findDiameter(root));
            root.left.left = null;
            root.right.left.left = new TreeNode(7);
            root.right.left.right = new TreeNode(8);
            root.right.right.left = new TreeNode(9);
            root.right.left.right.left = new TreeNode(10);
            root.right.right.left.left = new TreeNode(11);
            Console.WriteLine("Tree Diameter: " + TreeDiameter.findDiameter(root));
        }
    }
}
