using System;
using System.Collections.Generic;

namespace TreeDFS
{
    public class SumOfPathNumbers
    {

        public static int findSumOfPathNumbers(TreeNode root)
        {
            int sum = 0;
            //Recursion(root, 0, ref sum);
            //return sum;

            return Iteration(root);
        }

        private static void Recursion(TreeNode root, int currNumber, ref int sum)
        {
            if (root == null) return;

            currNumber = currNumber * 10 + root.val;
            if (root.left == null && root.right == null)
            {
                sum += currNumber;
            }
            else
            {
                Recursion(root.left, currNumber, ref sum);
                Recursion(root.right, currNumber, ref sum);
            }
        }

        private  static int Iteration(TreeNode root)
        {
            if (root == null) return -1;

            var sum = 0;

            var stack = new Stack<TreeNode>();
            var currNumberStack = new Stack<int>();
            stack.Push(root);
            currNumberStack.Push(0);

            while (stack.Count > 0)
            {
                var node = stack.Pop();
                var currNum = currNumberStack.Pop();

                currNum = currNum * 10 + node.val;

                if (node.left == null && node.right == null)
                {
                    sum += currNum;
                }

                if (node.left != null)
                {
                    stack.Push(node.left);
                    currNumberStack.Push(currNum);
                }
                if (node.right != null)
                {
                    stack.Push(node.right);
                    currNumberStack.Push(currNum);
                }
            }

            return sum;

        }

        public static void Run()
        {

            TreeNode root = new TreeNode(1);
            root.left = new TreeNode(0);
            root.right = new TreeNode(1);
            root.left.left = new TreeNode(1);
            root.right.left = new TreeNode(6);
            root.right.right = new TreeNode(5);
           Console.WriteLine("Total Sum of Path Numbers: " + SumOfPathNumbers.findSumOfPathNumbers(root));

        }
    }
}
