using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HW6T1;

namespace ListMethodsTest
{
    [TestClass]
    public class FilterTest
    {
        List<int> list;

        [TestInitialize]
        public void Initialize()
        {
            var values = new int[] { -1, 0, 5, 22, 44, 13451, 23, -43252, 555 };
            list = new List<int>();
            foreach (var value in values)
            {
                list.Add(value);
            }
        }

        [TestMethod]
        public void PositiveFilterTest()
        {
            var check = new int[] { 5, 22, 44, 13451, 23, 555 };
            list = ListMethods.Filter(list, x => x > 0);
            AssertAll(list, check);
        }

        [TestMethod]
        public void NegativeFilterTest()
        {
            var check = new int[] { -1, -43252 };
            list = ListMethods.Filter(list, x => x < 0);
            AssertAll(list, check);
        }

        [TestMethod]
        public void EvenFilterTest()
        {
            var check = new int[] { 0, 22, 44, -43252 };
            list = ListMethods.Filter(list, x => x % 2 == 0);
            AssertAll(list, check);
        }

        [TestMethod]
        public void AllPassedFilterTest()
        {
            var check = new int[] { -1, 0, 5, 22, 44, 13451, 23, -43252, 555 };
            list = ListMethods.Filter(list, x => x > -50000);
            AssertAll(list, check);
        }

        [TestMethod]
        public void NonePassedFilterTest()
        {
            list = ListMethods.Filter(list, x => x == -50000);
            Assert.AreEqual(list.Count, 0);
        }


        [TestMethod]
        public void TwoFilterTest()
        {
            var check = new int[] { 0, 22, 44 };
            list = ListMethods.Filter(list, x => x % 2 == 0);
            list = ListMethods.Filter(list, x => x >= 0);
            AssertAll(list, check);
        }

        [TestMethod]
        public void ThreeFilterTest()
        {
            var check = new int[] { 22, 44 };
            list = ListMethods.Filter(list, x => x % 2 == 0);
            list = ListMethods.Filter(list, x => x >= 0);
            list = ListMethods.Filter(list, x => x >= 5);
            AssertAll(list, check);
        }

        private void AssertAll(List<int> list, int[] check)
        {
            for (int i = 0; i < list.Count; ++i)
            {
                Assert.AreEqual(list[i], check[i]);
            }
        }
    }
}
