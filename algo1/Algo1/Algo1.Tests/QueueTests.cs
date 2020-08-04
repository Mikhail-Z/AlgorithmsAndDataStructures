using System;
using System.Collections;
using NUnit.Framework;
using AlgorithmsDataStructuresQueue;

namespace AlgorithmsDataStructuresTests
{
    public class QueueUnitTests
    {
        [Test]
        public void Test_Enqueue()
        {
            var expected = "[1 2 3 ]";

            var queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            Assert.AreEqual(expected, queue.ToString());
        }

        [Test]
        public void Test_DequeWhen2ndStackIsNotEmpty()
        {
            var expected = "[3 ]";

            var queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            var lastOne = queue.Dequeue();
            var lastTwo = queue.Dequeue();

            Assert.AreEqual(expected, queue.ToString());
            Assert.AreEqual(1, lastOne);
            Assert.AreEqual(2, lastTwo);
        }

        [Test]
        public void Test_Deque_WhenEmpty()
        {
            var queue = new Queue<int>();
            var actual = queue.Dequeue();

            Assert.AreEqual(default(int), actual);
        }
    }
}