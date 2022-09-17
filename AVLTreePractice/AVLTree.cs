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

            //ret node that 

            Node<T> ret = Balance(parentNode);
            return ret;
        }

        public void AdjustHeight(Node<T> node)
        {
            //update node height to, height of largest child (by val), depth of larger child's node depth + 1
        }


        public Node<T> Balance(Node<T> nodeToBalance)
        {
            if(nodeToBalance.Balance > 1) //balance != 2
            {
                if(nodeToBalance.Left.Balance == 0)
                {
                    nodeToBalance.Left = LeftRoate(nodeToBalance.Left);
                }
                nodeToBalance.Left = LeftRoate(nodeToBalance);
            }
            else if(nodeToBalance.Balance < -1) //balance != -2
            {
                if(nodeToBalance.Right.Balance < 0)
                {
                    nodeToBalance.Right = RightRotate(nodeToBalance.Right);
                }
                nodeToBalance.Right = RightRotate(nodeToBalance);
            }

            //update in this order
            //height
            //balance
            //then and only then Rotate

            //as u go up tree
            //balance (set dept to larger child node's depth + 1; 
            //next, roate left/right, or double rotate left/right 


            return null; 
        }

        public Node<T> RightRotate(Node<T> node)
        {
            Node<T> roationNode = node.Right;
            node.Right = roationNode.Left;
            roationNode = node;

            AdjustHeight(node);

            return roationNode; 
        }
        public Node<T> LeftRoate(Node<T> node)
        {


            return null; 
        }
    }
}
