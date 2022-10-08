using System;

namespace AVLTreePractice 
{
    internal class Program
    {
        //fix parents
        static void Main(string[] args)
        {
            Tree<int> tree = new Tree<int>();



            tree.Insert(1);
            tree.Insert(3);
            tree.Insert(2);
        }
    }
}