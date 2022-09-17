using System;

namespace AVLTreePractice 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Tree<int> tree = new Tree<int>();

            tree.Insert(1);
            tree.Insert(2);
            tree.Insert(3);
        }
    }
}