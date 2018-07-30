using System;

namespace TreesAndGraphs
{
    class Successor
    {
        public static BinaryTreeNodeWithParent<int> GetNext(BinaryTree<int> tree, int value)
        {
            if (tree.Head == null)
            {
                return null;
            }
            var founded = GetNodeByValue(tree.Head, value);
            if (founded == null)
            {
                return null;
            }

            if (founded.Rigth == null)
            {
                BinaryTreeNodeWithParent<int> tmp = founded.Parent;
                while (tmp != null && tmp.Value < value)
                {
                    tmp = tmp.Parent;
                }
                return tmp;
            }

            var n = founded.Rigth;
            while (n.Left != null)
            {
                n = n.Left;
            }
            return n;
        }

        public static BinaryTreeNodeWithParent<int> GetNodeByValue(BinaryTreeNodeWithParent<int> node, int value)
        {
                if (node.Value == value)
                {
                    return node;
                }
                if (node.Value > value && node.Left != null) 
                {
                    return GetNodeByValue(node.Left, value);
                }
                if (node.Value < value && node.Rigth != null)
                {
                    return GetNodeByValue(node.Rigth, value);
                }
                return null;
        }
    }
}