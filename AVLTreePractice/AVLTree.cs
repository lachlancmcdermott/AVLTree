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

            //ret node to replace 

            Node<T> ret = Balance(parentNode);
            return ret;
        }

        public void AdjustHeight(Node<T> node)
        {
            //update node height to, height of largest child (by val), depth of larger child's node depth + 1


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

        public Node<T> RightRotate(Node<T> node)
        {
            Node<T> rotationNode = node.Right;
            node.Right = rotationNode.Left;
            node.Left = rotationNode;

            AdjustHeight(rotationNode);

            return rotationNode; 
        }
        public Node<T> LeftRotate(Node<T> node)
        {
            Node<T> rotationNode = node.Left;
            node.Left = rotationNode.Right;
            node.Right = rotationNode;

            AdjustHeight(rotationNode);

            return rotationNode;
        }
    }
}
