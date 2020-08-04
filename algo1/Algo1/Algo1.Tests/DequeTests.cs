using System;
using AlgorithmsDataStructuresDeque;
using NUnit.Framework;

namespace AlgorithmsDataStructuresTests
{
    public class DequeUnitTests
    {
        [Test]
        public void Test_AddFront()
        {
            var deque = new Deque<int>();

            deque.AddFront(1);
            deque.AddFront(2);
            deque.AddFront(3);

            var size = deque.Size();
            Assert.AreEqual(3, size);
            Assert.AreEqual(3, deque.RemoveFront());
            Assert.AreEqual(1, deque.RemoveTail());
        }

        [Test]
        public void Test_AddTail()
        {
            var deque = new Deque<int>();

            deque.AddTail(1);
            deque.AddTail(2);
            deque.AddTail(3);

            var size = deque.Size();
            Assert.AreEqual(3, size);
            Assert.AreEqual(1, deque.RemoveFront());
            Assert.AreEqual(3, deque.RemoveTail());
        }

        [Test]
        public void Test_RemoveFront()
        {
            var deque = new Deque<int>();

            deque.AddTail(1);
            deque.AddTail(2);
            deque.AddTail(3);
            var firstItem = deque.RemoveFront();
            
            var size = deque.Size();
            Assert.AreEqual(2, size);
            Assert.AreEqual(1, firstItem);
            Assert.AreEqual(3, deque.RemoveTail());
        }

        [Test]
        public void Test_RemoveFront_WhenEmpty()
        {
            var deque = new Deque<int>();
            var firstItem = deque.RemoveFront();

            var size = deque.Size();
            Assert.AreEqual(0, size);
            Assert.AreEqual(default(int), firstItem);
        }

        [Test]
        public void Test_RemoveTail()
        {
            var deque = new Deque<int>();

            deque.AddTail(1);
            deque.AddTail(2);
            deque.AddTail(3);
            var lastItem = deque.RemoveTail();

            var size = deque.Size();
            Assert.AreEqual(2, size);
            Assert.AreEqual(3, lastItem);
            Assert.AreEqual(1, deque.RemoveFront());
        }

        [Test]
        public void Test_RemoveTail_WhenEmpty()
        {
            var deque = new Deque<int>();
            var lastItem = deque.RemoveTail();

            var size = deque.Size();
            Assert.AreEqual(0, size);
            Assert.AreEqual(default(int), lastItem);
        }
    }
}