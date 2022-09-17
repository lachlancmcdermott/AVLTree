using System;
using System.Collections.Generic;
using System.Text;

namespace AVLTreePractice
{
    class Node<T> where T : IComparable<T>
    {
        public T Value;
        public int Depth;
        public int Balance { get; set; }
        public Node<T> Left;
        public Node<T> Right;
        public Node<T> Parent;

        public bool isLeaf
        {
            get
            {
                return this.Left == null && this.Right == null;
            }
        }

        public bool isLeftChild
        {
            get
            {
                return this.Parent.Left == this;
            }
        }

        public Node(T value, Node<T> parent)
        {
            Depth = 1;
            Value = value;
            Left = null;
            Right = null;
            Parent = parent;
        }
    }
}