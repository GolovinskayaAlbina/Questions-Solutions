using System;

namespace TreesAndGraphs
{
    class MinimalTree
    {
        BinaryTreeNode<int> _root;
        public static MinimalTree CreateMinimalTree(int[] sorted){
            if (sorted == null || sorted.Length == 0)
            {
                return new MinimalTree(null);
            }
            return new MinimalTree(CreateMinimalTreeNode(sorted, 0, sorted.Length-1));
        }

        static BinaryTreeNode<int> CreateMinimalTreeNode(int[] sorted, int start, int end)
        {
            if (start > end) //Todo: check
            {
                return null;
            }
            int middle = ( start + end) / 2;
            return new BinaryTreeNode<int>{
                Value = sorted[middle],
                Left = CreateMinimalTreeNode(sorted, start, middle - 1),
                Rigth = CreateMinimalTreeNode (sorted, middle + 1, end)
            };
        }

        private MinimalTree(BinaryTreeNode<int> root)
        {
            _root = root;
        }
    }
}
