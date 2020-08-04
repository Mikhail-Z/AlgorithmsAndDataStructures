using System;
using AlgorithmsDataStructuresTasks;
using NUnit.Framework;

namespace MyStack.Tests
{
    public class PostfixNotationTaskUnitTests
    {
        [Test]
        public void Test_Expression_FromExample()
        {
            var expression = "8 2 + 5 * 9 + =";
            var result = PostfixNotationTask.Solve(expression);
            Assert.AreEqual(59, result);
        }

        [Test]
        public void Test_Expression_FromExampleWithMinus()
        {
            var expression = "8 2 - 5 * 9 + =";
            var result = PostfixNotationTask.Solve(expression);
            Assert.AreEqual(39, result);
        }
    }
}