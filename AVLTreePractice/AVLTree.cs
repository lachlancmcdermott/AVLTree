using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AVLTreePractice
{
    class Tree<T> where T : IComparable<T>
    {
        Node<T> Head;

        public void Insert(T value)
        {
            if (Head == null)
            {
                Head = new Node<T>(value, null);
            }
            Insert(value, Head);
        }

        private Node<T> Insert(T value, Node<T> parentNode)
        {
            if (parentNode == null)
            {
                Node<T> newNode = new Node<T>(value, null);
                return newNode;
            }
            int compareNodes = value.CompareTo(parentNode.Value);
            if (compareNodes < 0)
            {
                parentNode.Left = Insert(value, parentNode.Right);
            }
            else
            {
                parentNode.Right = Insert(value, parentNode.Right);
            }

            Node<T> ret = Balance(parentNode);
            return ret;
        }

        //update in this order 
        //height
        //balance
        //then and only then Rotate

        public Node<T> Balance(Node<T> nodeToBalance)
        {
            if(nodeToBalance.Balance < -1) //balance != 2
            {
                nodeToBalance = LeftRotate(nodeToBalance);
            }
            else if(nodeToBalance.Balance > 1) //balance != -2
            {
                nodeToBalance = RightRotate(nodeToBalance);
            }
            return nodeToBalance; 
        }

        public void AdjustHeight(Node<T> nodeToAdjust)
        {
            int leftChildHeight = 0;
            int rightChildHeight = 0;

            if (nodeToAdjust.Left != null)
            {
                leftChildHeight = nodeToAdjust.Left.Depth;
            }
            if (nodeToAdjust.Right != null)
            {
                rightChildHeight = nodeToAdjust.Right.Depth;
            }

            int depth = 0;
            if(leftChildHeight > rightChildHeight)
            {
                depth = leftChildHeight;
            }
            else
            {
                depth = rightChildHeight;
            }
            nodeToAdjust.Depth = depth + 1;
        }

        public Node<T> RightRotate(Node<T> node)
        {
            Node<T> rotationNode = node.Right;
            node.Right = rotationNode.Left;
            node.Left = rotationNode;

            //Adjust Height
            AdjustHeight(node);

            return rotationNode; 
        }
        public Node<T> LeftRotate(Node<T> node)
        {
            Node<T> rotationNode = node.Left;
            node.Left = rotationNode.Right;
            node.Right = rotationNode;

            //Adjust Height
            AdjustHeight(node);

            return rotationNode;
        }
    }
}
