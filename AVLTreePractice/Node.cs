using System;
using System.Collections.Generic;
using System.Text;

namespace AVLTreePractice
{
    public class Node<T> where T : IComparable<T>
    {
        public T Value;
        public int Depth;
        public Node<T> Left;
        public Node<T> Right;
        public Node<T> Parent;

        public int Balance
        {
            get
            {
                int rightChildHeight = this.Right != null ? this.Right.Depth : 0;
                int leftChildHeight = this.Left != null ? this.Left.Depth : 0;

                return leftChildHeight - rightChildHeight;   
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