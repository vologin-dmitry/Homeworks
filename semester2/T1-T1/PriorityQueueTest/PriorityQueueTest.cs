using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PriorutyQueueNamespace;

namespace PriorityQueueTest
{
    [TestClass]
    public class PriorityQueueTest
    {
        PriorityQueue queue;

        [TestInitialize]
        public void Initialize()
        {
            queue = new PriorityQueue();
        }


        [TestMethod]
        public void PushOne()
        {
            queue.Enqueue("ololpo", 0);
            Assert.AreEqual("ololpo", queue.Dequeue());
        }

        [TestMethod]
        public void PushTwo()
        {
            queue.Enqueue("hello", 3);
            queue.Enqueue("hi", 5);
            Assert.AreEqual("hi", queue.Dequeue());
        }

        [TestMethod]
        public void PushTwoReversed()
        {
            queue.Enqueue("hello", 5);
            queue.Enqueue("hi", 3);
            Assert.AreEqual("hello", queue.Dequeue());
        }

        [TestMethod]
        public void PushTwoEqual()
        {
            queue.Enqueue("hello", 3);
            queue.Enqueue("hi", 3);
            Assert.AreEqual("hello", queue.Dequeue());
        }

        [TestMethod]
        public void PushThreeEqual()
        {
            queue.Enqueue("hello", 3);
            queue.Enqueue("hi", 3);
            queue.Enqueue("boi", 3);
            Assert.AreEqual("hello", queue.Dequeue());
        }

        [TestMethod]
        public void PushThreeEqualSequnceCheck()
        {
            queue.Enqueue("hello", 3);
            queue.Enqueue("hi", 3);
            queue.Enqueue("boi", 3);
            queue.Dequeue();
            Assert.AreEqual("hi", queue.Dequeue());
        }

        [TestMethod]
        [ExpectedException(typeof(RemovingElementOfEmptyQueue))]
        public void ExceptionJoinsTheGame()
        {
            queue.Dequeue();
        }

        [TestMethod]
        [ExpectedException(typeof(RemovingElementOfEmptyQueue))]
        public void ExceptionJoinsTheGamePartTwo()
        {
            queue.Enqueue("hello", 5);
            queue.Dequeue();
            queue.Dequeue();
        }

        [TestMethod]
        public void AddingNegative()
        {
            queue.Enqueue("hello", -5);
            queue.Enqueue("hi", -3);
            Assert.AreEqual("hi", queue.Dequeue());
        }

        [TestMethod]
        public void AfterClear()
        {
            queue.Enqueue("hello", -3);
            queue.Clear();
            queue.Enqueue("hi", -5);
            Assert.AreEqual("hi", queue.Dequeue());
        }
    }
}
