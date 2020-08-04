using System;
using NUnit.Framework;
using AlgorithmsDataStructuresStack;

namespace AlgorithmsDataStructuresTests
{
    public class StackUnitTests
    {
        [Test]
        public void Test_Push()
        {
            var expectedRepr = "2, 1]";

            var stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            Assert.AreEqual(expectedRepr, stack.ToString());
            Assert.AreEqual(2, stack.Size());
        }

        [Test]
        public void Test_PopWhenStackIsEmpty()
        {
            var stack = new Stack<int>();
            Assert.AreEqual(default(int), stack.Pop());
        }

        [Test]
        public void Test_PopWhenNotEmpty()
        {
            var expectedRepr = "1]";
            var expectedValue = 2;
            var stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            var value = stack.Pop();
            Assert.AreEqual(expectedRepr, stack.ToString());
            Assert.AreEqual(expectedValue, value);
            Assert.AreEqual(1, stack.Size());
        }

        [Test]
        public void Test_PeekWhenIsEmpty()
        {
            var stack = new Stack<int>();
            Assert.AreEqual(default(int), stack.Peek());
        }

        [Test]
        public void Test_PeekWhenIsNotEmpty()
        {
            var expectedRepr = "2, 1]";
            var expectedValue = 2;
            var stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            var value = stack.Peek();
            Assert.AreEqual(expectedRepr, stack.ToString());
            Assert.AreEqual(expectedValue, value);
            Assert.AreEqual(2, stack.Size());
        }
    }
}