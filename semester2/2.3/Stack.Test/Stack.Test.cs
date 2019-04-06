using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Stack.Test
{
    using Calculator;

    [TestClass]
    public class StackTest
    {
        StackOnArray arrayStack;
        StackOnList listStack;

        [TestInitialize]
        public void Initialize()
        {
            arrayStack = new StackOnArray();
            listStack = new StackOnList();
        }

        [TestCleanup]
        public void Cleanup()
        {
            arrayStack.Clear();
            listStack.Clear();
        }

        [TestMethod]
        public void IsEmptyTestArray()
            => IsEmpty(arrayStack);

        [TestMethod]
        public void IsEmptyTestList()
            => IsEmpty(listStack);

        [TestMethod]
        public void IsEmptyTestIntArray()
            => IsEmptyInt(arrayStack);

        [TestMethod]
        public void IsEmptyTestIntList()
            => IsEmptyInt(listStack);

        [TestMethod]
        public void OnePushTestArray()
            => OnePush(arrayStack);

        [TestMethod]
        public void OnePushTestList()
            => OnePush(listStack);

        [TestMethod]
        public void OnePushIntTestArray()
            => OnePushInt(arrayStack);

        [TestMethod]
        public void OnePushIntTestList()
            => OnePushInt(listStack);

        [TestMethod]
        public void PushAndPopTestArray()
            => PushAndPop(arrayStack);

        [TestMethod]
        public void PushAndPopTestList()
            => PushAndPop(listStack);

        [TestMethod]
        public void ValueDoesNotChangeTestArray()
            => ValueDoesNotChange(arrayStack);

        [TestMethod]
        public void ValueDoesNotChangeTestList()
            => ValueDoesNotChange(listStack);

        [TestMethod]
        public void SecondDoesNotChangeTestArray()
            => SecondDoesNotChange(arrayStack);

        [TestMethod]
        public void SecondDoesNotChangeTestList()
            => SecondDoesNotChange(listStack);

        [TestMethod]
        public void ClearCheckTestArray()
            => ClearCheck(arrayStack);

        [TestMethod]
        public void ClearCheckTestList ()
            => ClearCheck(listStack);

        [TestMethod]
        [ExpectedException(typeof(System.IndexOutOfRangeException))]
        public void PopWhenEmptyTestArray()
            => PopWhenEmpty(arrayStack);

        [TestMethod]
        [ExpectedException(typeof(System.IndexOutOfRangeException))]
        public void PopWhenEmptyTestList()
            => PopWhenEmpty(listStack);


        private void IsEmpty(IStack stack)
        {
            Assert.AreEqual(true, stack.IsEmpty());
        }

        private void IsEmptyInt(IStack stack)
        {
            Assert.AreEqual(0, stack.GetSize());
        }

        private void OnePush(IStack stack)
        {
            stack.Push("4");
            Assert.AreEqual(false, stack.IsEmpty());
        }

        private void OnePushInt(IStack stack)
        {
            stack.Push("-51");
            Assert.AreEqual(1, stack.GetSize());
        }

        private void PushAndPop(IStack stack)
        {
            stack.Push("4");
            stack.Pop();
            Assert.AreEqual(true, stack.IsEmpty());
        }

        private void ValueDoesNotChange(IStack stack)
        {
            stack.Push("8");
            Assert.AreEqual("8", stack.Pop());
        }

        private void SecondDoesNotChange(IStack stack)
        {
            stack.Push("3");
            stack.Push("2");
            stack.Pop();
            Assert.AreEqual("3", stack.Pop());
        }

        private void ClearCheck(IStack stack)
        {
            stack.Push("5");
            stack.Clear();
            Assert.AreEqual(true, stack.IsEmpty());
        }
        private void PopWhenEmpty(IStack stack)
        {
            stack.Pop();
        }
    }
}
