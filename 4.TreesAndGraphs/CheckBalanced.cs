using System;
using System.Collections.Generic;

namespace TreesAndGraphs
{
    class CheckBalanced<T>
    {
        public static bool IsBalanced(BinaryTree<T> tree)
        {
            return Depth(tree.Head) >= 0;
        }

        public static int Depth(BinaryTreeNode<T> node)
        {
            if (node == null)
            {
                return 0;
            }

            var leftDepth = Depth(node.Left);
            if (leftDepth == -1) return -1;
            var rigthDepth = Depth(node.Rigth);
            if (rigthDepth == -1) return -1;

            if (Math.Abs(leftDepth - rigthDepth) > 1)
            {
                return -1;
            }

            return Math.Max(leftDepth, rigthDepth) + 1;
        }
    }
}