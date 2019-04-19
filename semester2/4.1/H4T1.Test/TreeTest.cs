using System;
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


    }
}
