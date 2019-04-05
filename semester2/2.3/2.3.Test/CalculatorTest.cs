using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorTest
{
    using Calculator;

    [TestClass]
    public class CalculatorTest
    {
        private Calculator calculator;
        private StackOnList listStack;
        private StackOnArray arrayStack;

        [TestInitialize]
        public void Initialize()
        {
            calculator = new Calculator();
            listStack = new StackOnList();
            arrayStack = new StackOnArray();
        }

        [TestCleanup]
        public void Cleanup()
        {
            listStack.Clear();
            arrayStack.Clear();
        }

        [TestMethod]
        public void Sum1and1TestList()
            => Sum1and1Test(listStack);

        [TestMethod]
        public void Sum1and1TestArray()
            => Sum1and1Test(arrayStack);

        [TestMethod]
        public void SumIsZeroAsResultTestList()
            => SumIsZeroAsResultTest(listStack);

        [TestMethod]
        public void SumIsZeroAsResultTestArray()
            => SumIsZeroAsResultTest(arrayStack);

        [TestMethod]
        public void SumPositiveAndNegativeNumbersTestList()
            => SumPositiveAndNegativeNumbersTest(listStack);

        [TestMethod]
        public void SumPositiveAndNegativeNumbersTestArray()
            => SumPositiveAndNegativeNumbersTest(arrayStack);

        [TestMethod]
        public void SumTwoZeroesTestList()
            => SumTwoZeroesTest(listStack);

        [TestMethod]
        public void SumTwoZeroesTestArray()
            => SumTwoZeroesTest(arrayStack);

        [TestMethod]
        public void Mult5and4TestList()
            => Mult5and4Test(listStack);

        [TestMethod]
        public void Mult5and4TestArray()
            => Mult5and4Test(arrayStack);

        [TestMethod]
        public void MultToNegativeTestList()
            => MultToNegativeTest(listStack);

        [TestMethod]
        public void MultToNegativeTestArray()
            => MultToNegativeTest(arrayStack);

        [TestMethod]
        public void MultTwoNegativesTestList()
            => MultTwoNegativesTest(listStack);

        [TestMethod]
        public void MultTwoNegativesTestArray()
            => MultTwoNegativesTest(arrayStack);

        [TestMethod]
        public void MultToZeroTestList()
            => MultToZeroTest(listStack);

        [TestMethod]
        public void MultToZeroTestArray()
            => MultToZeroTest(arrayStack);

        [TestMethod]
        public void MultTwoZeroesTestList()
            => MultTwoZeroesTest(listStack);

        [TestMethod]
        public void MultTwoZeroesTestArray()
            => MultTwoZeroesTest(arrayStack);

        [TestMethod]
        public void Div20By4TestList()
            => Div20By4Test(listStack);

        [TestMethod]
        public void Div20By4TestArray()
            => Div20By4Test(arrayStack);

        [TestMethod]
        public void DivToNegativeTestList()
            => DivToNegativeTest(listStack);

        [TestMethod]
        public void DivToNegativeTestArray()
            => DivToNegativeTest(arrayStack);

        [TestMethod]
        [ExpectedException(typeof(System.DivideByZeroException))]
        public void DivByZeroTestList()
            => DivByZeroTest(listStack);

        [TestMethod]
        [ExpectedException(typeof(System.DivideByZeroException))]
        public void DivByZeroTestArray()
            => DivByZeroTest(arrayStack);

        [TestMethod]
        public void DivByLargerTestList()
            => DivByLargerTest(listStack);

        [TestMethod]
        public void DivByLargerTestArray()
            => DivByLargerTest(arrayStack);

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void WrongInputBehaviourTestList()
            => WrongInputBehaviourTest(listStack);

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void WrongInputBehaviourTestArray()
            => WrongInputBehaviourTest(arrayStack);

        [TestMethod]
        public void SeveralOperationsBehaviourTestList()
            => SeveralOperationsBehaviourTest(listStack);

        [TestMethod]
        public void SeveralOperationsBehaviourTestArray()
            => SeveralOperationsBehaviourTest(arrayStack);

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void WrongBalanceBehaviourTestList()
            => WrongBalanceBehaviourTest(listStack);

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void WrongBalanceBehaviourTestArray()
            => WrongBalanceBehaviourTest(arrayStack);



        private void Sum1and1Test(IStack stack)
        {
            Assert.AreEqual(2, calculator.Count("1 1 +", stack));
        }

        private void SumIsZeroAsResultTest(IStack stack)
        {
            Assert.AreEqual(0, calculator.Count("4 4 -", stack));
        }

        private void SumPositiveAndNegativeNumbersTest(IStack stack)
        {
            Assert.AreEqual(2, calculator.Count("5 -3 +", stack));
        }

        private void SumTwoZeroesTest(IStack stack)
        {
            Assert.AreEqual(0, calculator.Count("0 0 +", stack));
        }

        private void Mult5and4Test(IStack stack)
        {
            Assert.AreEqual(20, calculator.Count("5 4 *", stack));
        }

        private void MultToNegativeTest(IStack stack)
        {
            Assert.AreEqual(-36, calculator.Count("9 -4 *", stack));
        }

        private void MultTwoNegativesTest(IStack stack)
        {
            Assert.AreEqual(27, calculator.Count("-9 -3 *", stack));
        }

        private void MultToZeroTest(IStack stack)
        {
            Assert.AreEqual(0, calculator.Count("3 0 *", stack));
        }

        private void MultTwoZeroesTest(IStack stack)
        {
            Assert.AreEqual(0, calculator.Count("0 0 *", stack));
        }

        private void Div20By4Test(IStack stack)
        {
            Assert.AreEqual(5, calculator.Count("20 4 /", stack));
        }

        private void DivToNegativeTest(IStack stack)
        {
            Assert.AreEqual(-3, calculator.Count("3 -1 /", stack));
        }

        private void DivByZeroTest(IStack stack)
        {
            calculator.Count("3 0 /", stack);
        }

        private void DivByLargerTest(IStack stack)
        {
            Assert.AreEqual(0, calculator.Count("4 5 /", stack));
        }

        private void WrongInputBehaviourTest(IStack stack)
        {
            calculator.Count("hei boiiiii", stack);
        }

        private void SeveralOperationsBehaviourTest(IStack stack)
        {
            Assert.AreEqual(28, calculator.Count("4 5 2 + *", stack));
        }
        
        private void WrongBalanceBehaviourTest(IStack stack)
        {
            calculator.Count("5 4 3 2 + -", stack);
        }
    }
}