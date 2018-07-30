namespace TreesAndGraphs
{
    class BinaryTree<T>
    {
        public BinaryTreeNodeWithParent<T> Head {get; private set;}
    }
    class BinaryTreeNode<T>
    {
        public BinaryTreeNode<T> Left;
        public BinaryTreeNode<T> Rigth;
        public T Value;
    }

     class BinaryTreeNodeWithParent<T> : BinaryTreeNode<T>
     {
          public BinaryTreeNodeWithParent<T> Parent;
          public new BinaryTreeNodeWithParent<T> Left;
          public new BinaryTreeNodeWithParent<T> Rigth;
     }
}