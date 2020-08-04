using System;
using System.Text;
using AlgorithmsDataStructuresTasks;
using NUnit.Framework;


namespace MyStack.Tests
{
    public class BracketTaskUnitTests
    {
        [Test]
        public void Test_BracketTask_WhenLeftBracketsCountHigherThanRight()
        {
            Assert.AreEqual(false, BracketTask.Solve("((())"));
        }

        [Test]
        public void Test_BracketTask_WhenFromRightBracketBegins()
        {
            Assert.AreEqual(false, BracketTask.Solve("((())))"));
        }

        [Test]
        public void Test_BracketTask_WhenLeftBracketsCountEqualsRightAndRightOrder()
        {
            Assert.AreEqual(true, BracketTask.Solve("((())())"));
        }
    }
}