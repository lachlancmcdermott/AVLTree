using AVLTreePractice;

namespace ExampleTest
{
    [TestClass]
    public class NodeTest
    {
        [TestMethod]
        public void ValueTest()
        {
            Node<int> bob = new Node<int>(100, null);

            Assert.AreEqual(100, bob.Value);
        }
    }

    [TestClass]
    public class TreeTest
    {
        [TestMethod]
        public void CountTest()
        {
            Tree<int> tree = new Tree<int>();
            tree.Insert(1);
            tree.Insert(2);
            Assert.IsTrue(tree.Count == 2);
        }

        [TestMethod]
        public void BalanceTest()
        {
            Tree<int> tree = new Tree<int>();
            for (int i = 0; i < 100; i++)
            {
                Random random = new Random();
                int a = random.Next(100);
                tree.Insert(a);
                i++;
            }
            Assert.IsTrue(tree.Head.Balance == 1 || tree.Head.Balance == -1 || tree.Head.Balance == 0);
        }
    }

}