using System;

namespace TreesAndGraphs
{
    class ValidateBST
    {
        public static bool IsValid(BinaryTree<int> tree)
        {
            return MinMaxStrategy(tree.Head, null, null);
        }

        public static bool MinMaxStrategy(BinaryTreeNode<int> node, int? max, int? min)
        {  
            if (node == null)
                return true;

            if (max != null && node.Value > max){
                return false;
            }  

            if (min != null && node.Value <= min){
                return false;
            }

            return MinMaxStrategy(node.Left, node.Value, min) && 
                MinMaxStrategy(node.Rigth, max, node.Value);
        }
    }
}