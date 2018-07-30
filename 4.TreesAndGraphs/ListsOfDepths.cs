using System;
using System.Collections.Generic;

namespace TreesAndGraphs
{
    class ListsOfDepths
    {
        public static List<Queue<BinaryTreeNode<int>>> Create(BinaryTree<int> tree)
        {
            var listsOfDepths = new List<Queue<BinaryTreeNode<int>>>();
            var deptsQueue = new Queue<BinaryTreeNode<int>>();
            
            if (tree.Head!= null)
                deptsQueue.Enqueue(tree.Head);

            while (deptsQueue.Count > 0)
            {
                listsOfDepths.Add(new Queue<BinaryTreeNode<int>>(deptsQueue));
                var sonsQueue = new Queue<BinaryTreeNode<int>>();
                while (deptsQueue.Count > 0)
                {
                    var node = deptsQueue.Dequeue();
                    if (node.Left != null)
                        sonsQueue.Enqueue(node.Left);
                    if (node.Rigth != null)
                        sonsQueue.Enqueue(node.Rigth);
                }
                deptsQueue = sonsQueue;
            }

            return listsOfDepths;
        }
    }
}