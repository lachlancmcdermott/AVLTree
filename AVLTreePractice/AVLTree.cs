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
    public class Tree<T> where T : IComparable<T>
    {
        public Node<T> Head;
        public int Count { get; private set; }

        public void Insert(T value)
        {
            Count++;
            if (Head == null)
            {
                Head = new Node<T>(value, null);
                return;
            }
            Head = Insert(value, Head);
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

            AdjustHeight(parentNode);
            Node<T> ret = Balance(parentNode);
            return ret;
        }

        public Node<T> Balance(Node<T> nodeToBalance)
        {
            if (nodeToBalance.Balance < -1) //balance != 2
            {
                if (nodeToBalance.Right.Balance == 1)
                {
                    nodeToBalance.Right = RightRotate(nodeToBalance.Right);
                }
                nodeToBalance = LeftRotate(nodeToBalance);
            }
            else if (nodeToBalance.Balance > 1) //balance != -2
            {
                if (nodeToBalance.Left.Balance == -1)
                {
                    nodeToBalance.Left = LeftRotate(nodeToBalance.Left);
                }
                nodeToBalance = RightRotate(nodeToBalance);
            }
            return nodeToBalance; 
        }

        public void AdjustHeight(Node<T> nodeToAdjust)
        {
            int rightChildHeight = nodeToAdjust.Right != null? nodeToAdjust.Right.Depth : 0;
            int leftChildHeight = nodeToAdjust.Left != null? nodeToAdjust.Left.Depth : 0;

            int depth = leftChildHeight > rightChildHeight? leftChildHeight : rightChildHeight;
            nodeToAdjust.Depth = depth + 1;
        }

        public Node<T> LeftRotate(Node<T> node)
        {
            Node<T> rotationNode = node.Right;
            node.Right = rotationNode.Left;
            rotationNode.Left = node;

            AdjustHeight(node);

            return rotationNode; 
        }
        public Node<T> RightRotate(Node<T> node)
        {
            Node<T> rotationNode = node.Left;
            node.Left = rotationNode.Right;
            rotationNode.Right = node;
                
            AdjustHeight(node);

            return rotationNode;
        }
    }
}
