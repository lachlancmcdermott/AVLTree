using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                return;
            }

            Node<T> current = Head;
            current.Parent.Height++;

            Balance(current);
        }

        public void Balance(T node)
        {

        }

        public void Rotate(T node)
        {

        }

    }
}
