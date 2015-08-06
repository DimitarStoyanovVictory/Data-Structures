using System;
using System.Collections;
using System.Collections.Generic;

namespace OrderedSet
{
    public class OrderedSet<T> : IEnumerable<T> where T : IComparable 
    {
        private int _size;
        private bool _contains;
        private bool _removeMethodOn;

        public BinaryTree<T> Root { get; set; }

        public int Count
        {
            get
            {
                return _size;
            }

            set { _size = value; }
        }

        public void Add(T element)
        {
            if (Count == 0) // 17
            {
                var firstTreeToAdd = new BinaryTree<T>();
                firstTreeToAdd.Value = element;
                Root = firstTreeToAdd;
            }
            else
            {
                CheckFromRootPosition(element, Root);
            }
            
            Count++;
        }

        public bool Contains(T element)
        {
            if (Count == 0)
            {
                throw new ArgumentNullException("No items in the set!");
            }

            CheckFromRootPosition(element, Root);

            return _contains;
        }

        public void Remove(T element)
        {
            if (Count == 0)
            {
                throw new ArgumentNullException("No items in the set!");
            }

            _removeMethodOn = true;
            CheckFromRootPosition(element, Root);
        }

        private void CheckFromRootPosition(T element, BinaryTree<T> currentTree)
        {
            if (currentTree.Value.CompareTo(element) > 0)
            {
                CompareLeftTree(element, currentTree);
            }

            if (currentTree.Value.CompareTo(element) < 0)
            {
                CompareRigthTree(element, currentTree);
            }

            if (currentTree.Value.CompareTo(element) == 0)
            {
                if (_removeMethodOn)
                {
                    RefactureTree(currentTree);
                }
                else
                {
                    _contains = true;
                }
            }
        }

        private void RefactureTree(BinaryTree<T> currentTree)
        {
            if (currentTree.LeftChild != null)
            {
                currentTree.Value = currentTree.LeftChild.Value;

                if (currentTree.LeftChild.LeftChild == null)
                {
                    currentTree.LeftChild = null;
                }
                else
                {
                    RefactureTree(currentTree.LeftChild);
                }
            }
            else if (currentTree.RightChild != null)
            {
                currentTree.Value = currentTree.RightChild.Value;

                if (currentTree.RightChild.RightChild.Value == null)
                {
                    currentTree.RightChild.RightChild = null;
                }

                RefactureTree(currentTree.RightChild);
            }
        }

        private void CompareRigthTree(T element, BinaryTree<T> currentTree)
        {
            if (currentTree.RightChild != null)
            {
                CheckFromRootPosition(element, currentTree.RightChild);
            }
            else
            {
                currentTree.RightChild = new BinaryTree<T>();
                currentTree.RightChild.Value = element;
            }
        }

        private void CompareLeftTree(T element, BinaryTree<T> currentTree)
        {
            if (currentTree.LeftChild != null)
            {
                CheckFromRootPosition(element, currentTree.LeftChild);
            }
            else
            {
                currentTree.LeftChild = new BinaryTree<T>();
                currentTree.LeftChild.Value = element;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
