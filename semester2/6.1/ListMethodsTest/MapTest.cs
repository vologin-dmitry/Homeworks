using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HW6T1;

namespace ListMethodsTest
{
    [TestClass]
    public class MapTest
    {
        List<int> list;
        int[] check;

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
        public void MultTo2Test()
        {
            check = new int[] { -2, 0, 10, 26902, 46, -86504, 1110 };
            list = ListMethods.Map(list, x => x * 2);
            AssertAll(list, check);
        }

        [TestMethod]
        public void MultToZeroTest()
        {
            var check = new int[] { 0, 0, 0, 0, 0, 0, 0 };
            list = ListMethods.Map(list, x => x * 0);
            AssertAll(list, check);
        }

        [TestMethod]
        public void MulitToNegativeTest()
        {
            var check = new int[] { 1, 0, -5, -13451, -23, 43252, -555 };
            list = ListMethods.Map(list, x => x *= -1);
            AssertAll(list, check);
        }

        [TestMethod]
        public void AdditionZeroTest()
        {
            var check = new int[] { -1, 0, 5, 13451, 23, -43252, 555 };
            list = ListMethods.Map(list, x => x + 0);
            AssertAll(list, check);
        }

        [TestMethod]
        public void SubtractionOneTest()
        {
            var check = new int[] { -2, -1, 4, 13450, 22, -43253, 554 };
            list = ListMethods.Map(list, x => x - 1);
            AssertAll(list, check);
        }

        [TestMethod]
        public void TwoOperationsTest()
        {
            var check = new int[] { -1, 0, 5, 13451, 23, -43252, 555 };
            list = ListMethods.Map(list, x => x * 2);
            list = ListMethods.Map(list, x => x / 2);
            AssertAll(list, check);
        }

        [TestMethod]
        public void ThreeOperationsTest()
        {
            var check = new int[] { 0, 0, 0, 0, 0, -0, 0 };
            list = ListMethods.Map(list, x => x * 2);
            list = ListMethods.Map(list, x => x / 2);
            list = ListMethods.Map(list, x => x * 0);
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
