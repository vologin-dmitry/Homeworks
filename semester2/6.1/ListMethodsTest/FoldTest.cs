using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HW6T1;

namespace ListMethodsTest
{
    [TestClass]
    public class FoldTest
    {
        List<int> list;

        [TestInitialize]
        public void Initialize()
        {
            var values = new int[] { -1, 0, 5, 13451, 23, -43252, 555 };
            list = new List<int>();
            foreach (var value in values)
            {
                list.Add(value);
            }
        }

        [TestMethod]
        public void SumFoldTest()
            => Assert.AreEqual(-29219, ListMethods.Fold(list, (acc, element) => acc + element, 0));

        [TestMethod]
        public void MultToOneFoldTest()
            => Assert.AreEqual(0, ListMethods.Fold(list, (acc, element) => acc * element, 1));

        [TestMethod]
        public void MultToZeroFoldTest()
            => Assert.AreEqual(ListMethods.Fold(list, (acc, element) => acc * element, 0), 0);

        [TestMethod]
        public void SumFroFiveTest()
            => Assert.AreEqual(-29214, ListMethods.Fold(list, (acc, element) => acc + element, 5));

        [TestMethod]
        public void SumSubstractionTest()
            => Assert.AreEqual(29219, ListMethods.Fold(list, (acc, element) => acc - element, 0));

        [TestMethod]
        public void DivisionFoldTest()
        {
            list.Remove(0);
            Assert.AreEqual(0, ListMethods.Fold(list, (acc, element) => acc / element, 0));
        }

        [TestMethod]
        public void MultipleOperationsFoldTest()
        {
            Assert.AreEqual(9692, ListMethods.Fold(list, (acc, element) => (acc - element) / 2, 0));
        }

        [ExpectedException(typeof(DivideByZeroException))]
        public void DivisionToZeroFoldTest()
            => ListMethods.Fold(list, (acc, element) => acc - element, 0);
    }
}
