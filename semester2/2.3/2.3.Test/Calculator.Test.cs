using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorTest
{
    using Calculator;

    [TestClass]
    public class CalculatorTest
    {
        private Calculator listCalculator;
        private Calculator arrayCalculator;

        [TestInitialize]
        public void Initialize()
        {
            listCalculator = new Calculator(new StackOnList());
            arrayCalculator = new Calculator(new StackOnArray());
        }


        [TestMethod]
        public void Sum1and1TestList()
            => Assert.AreEqual(2, listCalculator.Count("1 1 +"));

        [TestMethod]
        public void Sum1and1TestArray()
            => Assert.AreEqual(2, arrayCalculator.Count("1 1 +"));

        [TestMethod]
        public void SumIsZeroAsResultTestList()
            => Assert.AreEqual(0, listCalculator.Count("4 4 -"));

        [TestMethod]
        public void SumIsZeroAsResultTestArray()
            => Assert.AreEqual(0, arrayCalculator.Count("4 4 -"));

        [TestMethod]
        public void SumPositiveAndNegativeNumbersTestList()
            => Assert.AreEqual(2, listCalculator.Count("5 -3 +"));

        [TestMethod]
        public void SumPositiveAndNegativeNumbersTestArray()
            => Assert.AreEqual(2, arrayCalculator.Count("5 -3 +"));

        [TestMethod]
        public void SumTwoZeroesTestList()
            => Assert.AreEqual(0, listCalculator.Count("0 0 +"));

        [TestMethod]
        public void SumTwoZeroesTestArray()
            => Assert.AreEqual(0, arrayCalculator.Count("0 0 +"));

        [TestMethod]
        public void Mult5and4TestList()
            => Assert.AreEqual(20, listCalculator.Count("5 4 *"));

        [TestMethod]
        public void Mult5and4TestArray()
            => Assert.AreEqual(20, arrayCalculator.Count("5 4 *"));

        [TestMethod]
        public void MultToNegativeTestList()
            => Assert.AreEqual(-36, listCalculator.Count("9 -4 *"));

        [TestMethod]
        public void MultToNegativeTestArray()
            => Assert.AreEqual(-36, arrayCalculator.Count("9 -4 *"));

        [TestMethod]
        public void MultTwoNegativesTestList()
            => Assert.AreEqual(27, listCalculator.Count("-9 -3 *"));

        [TestMethod]
        public void MultTwoNegativesTestArray()
            => Assert.AreEqual(27, arrayCalculator.Count("-9 -3 *"));

        [TestMethod]
        public void MultToZeroTestList()
            => Assert.AreEqual(0, listCalculator.Count("3 0 *"));

        [TestMethod]
        public void MultToZeroTestArray()
            => Assert.AreEqual(0, arrayCalculator.Count("3 0 *"));

        [TestMethod]
        public void MultTwoZeroesTestList()
            => Assert.AreEqual(0, listCalculator.Count("0 0 *"));

        [TestMethod]
        public void MultTwoZeroesTestArray()
            => Assert.AreEqual(0, arrayCalculator.Count("0 0 *"));

        [TestMethod]
        public void Div20By4TestList()
            => Assert.AreEqual(5, listCalculator.Count("20 4 /"));

        [TestMethod]
        public void Div20By4TestArray()
            => Assert.AreEqual(5, arrayCalculator.Count("20 4 /"));

        [TestMethod]
        public void DivToNegativeTestList()
            => Assert.AreEqual(-3, listCalculator.Count("3 -1 /"));

        [TestMethod]
        public void DivToNegativeTestArray()
            => Assert.AreEqual(-3, arrayCalculator.Count("3 -1 /"));

        [TestMethod]
        [ExpectedException(typeof(System.DivideByZeroException))]
        public void DivByZeroTestList()
            => listCalculator.Count("3 0 /");

        [TestMethod]
        [ExpectedException(typeof(System.DivideByZeroException))]
        public void DivByZeroTestArray()
            => arrayCalculator.Count("3 0 /");

        [TestMethod]
        public void DivByLargerTestList()
            => Assert.AreEqual(0, listCalculator.Count("4 5 /"));

        [TestMethod]
        public void DivByLargerTestArray()
            => Assert.AreEqual(0, arrayCalculator.Count("4 5 /"));

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void WrongInputBehaviourTestList()
            => listCalculator.Count("hei boiiiii");

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void WrongInputBehaviourTestArray()
            => arrayCalculator.Count("hei boiiiii");

        [TestMethod]
        public void SeveralOperationsBehaviourTestList()
            => Assert.AreEqual(28, listCalculator.Count("4 5 2 + *"));

        [TestMethod]
        public void SeveralOperationsBehaviourTestArray()
            => Assert.AreEqual(28, arrayCalculator.Count("4 5 2 + *"));

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void WrongBalanceBehaviourTestList()
            => listCalculator.Count("5 4 3 2 + -");

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void WrongBalanceBehaviourTestArray()
            => arrayCalculator.Count("5 4 3 2 + -");
    }
}