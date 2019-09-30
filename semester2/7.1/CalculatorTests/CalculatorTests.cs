using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using H7T1;

namespace CalculatorTests
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        public void SimpleAdditionTest()
        {
            Assert.AreEqual(2, Counter.Count(1, 1, "+"));
        }

        [TestMethod]
        public void ZeroAsResultTest()
        {
            Assert.AreEqual(0, Counter.Count(-1, 1, "+"));
        }

        [TestMethod]
        public void SimpleDifferenceTest()
        {
            Assert.AreEqual(1, Counter.Count(2, 1, "-"));
        }

        [TestMethod]
        public void SecondIsLargerDifferenceTest()
        {
            Assert.AreEqual(-2, Counter.Count(2, 4, "-"));
        }

        [TestMethod]
        public void SecondIsNegativeDifferenceTest()
        {
            Assert.AreEqual(6, Counter.Count(2, -4, "-"));
        }

        [TestMethod]
        public void SimpleMultiplicationTest()
        {
            Assert.AreEqual(16, Counter.Count(2, 8, "*"));
        }

        [TestMethod]
        public void MultiplicationToOneTest()
        {
            Assert.AreEqual(8, Counter.Count(1, 8, "*"));
        }

        [TestMethod]
        public void MultiplicationToZerpTest()
        {
            Assert.AreEqual(0, Counter.Count(0, 8, "*"));
        }

        [TestMethod]
        public void SimpleDivisionTest()
        {
            Assert.AreEqual(4, Counter.Count(8, 2, "/"));
        }

        [TestMethod]
        public void SecondIsLargerDivisionTest()
        {
            Assert.AreEqual(0.5, Counter.Count(8, 16, "/"));
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void DivideByZeroDivisionTest()
        {
            Assert.AreEqual(0, 5, Counter.Count(8, 0, "/"));
        }
    }
}
