using System;

namespace OrderedSet
{
    public class BinaryTree<T> where T : IComparable
    {
        public BinaryTree(T value, BinaryTree<T> leftChild = null, BinaryTree<T> rightChild = null)
        {
            Value = value;
            LeftChild = leftChild;
            RightChild = rightChild;
        }

        public BinaryTree()
        {
        }

        public T Value { get; set; }

        public BinaryTree<T> LeftChild { get; set; }

        public BinaryTree<T> RightChild { get; set; }

        public int CompareTo(IComparable element)
        {
            if (Value.CompareTo(element) > 0)
            {
                return 1;
            }

            if (Value.CompareTo(element) < 0)
            {
                return -1;
            }

            return 0;
        }
    }
}
