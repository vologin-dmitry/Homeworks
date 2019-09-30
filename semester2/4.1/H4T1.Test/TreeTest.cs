using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace H4T1.Test
{
    [TestClass]
    public class TreeTest
    {
        private Tree tree;

        [TestInitialize]
        public void Initialize()
        {
            tree = new Tree();
        }

        [TestMethod]
        public void Sum1and1Count()
        {
            tree.Build("( + 1 1 )");
            Assert.AreEqual(tree.Count(), 2);
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void DivByZeroCount()
        {
            tree.Build("( / 1 0 )");
            tree.Count();
        }

        [TestMethod]
        public void HardExpressionCount()
        {
            tree.Build("( *( + 1 1 ) ( / ( + 3 2 ) 4 )");
            Assert.AreEqual(tree.Count(), 2);
        }

        [TestMethod]
        public void HardExpressionGetLine()
        {
            tree.Build("( *( + 1 1 ) ( / ( + 3 2 ) 4 ) )");
            Assert.AreEqual(tree.GetLine(), "( * ( + 1 1 ) ( / ( + 3 2 ) 4 ) )");
        }

        [TestMethod]
        public void ZeroMultiplicationCount()
        {
            tree.Build("( * ( + 4 3 ) ( - 5 5 ) )");
            Assert.AreEqual(tree.Count(), 0);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void NothingCount()
        {
            tree.Count();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void NothingGetLine()
        {
            tree.GetLine();
        }

        [TestMethod]
        public void ReadFileCount()
        {
            tree.BuildFromfile("test.txt");
            Assert.AreEqual(tree.Count(), 2);
        }

        [TestMethod]
        public void ReadFileLine()
        {
            tree.BuildFromfile("test.txt");
            Assert.AreEqual(tree.GetLine(), "( * ( + 1 1 ) ( / ( + 3 2 ) 4 ) )");
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void NoFileTest()
        {
            tree.BuildFromfile("tests.txt");
        }
    }
}
