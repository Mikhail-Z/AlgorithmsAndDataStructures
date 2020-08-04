using System;
using AlgorithmsDataStructuresOrderedList;
using NUnit.Framework;

namespace AlgorithmsDataStructuresTests
{
    public class OrderedListTests
    {
        [Test]
        public void Test_Сompare_WhenValuesAreStringsAndFirstLess()
        {
            var s1 = " 123 ";
            var s2 = "  456";
            var list = new OrderedList<string>(true);
            
            var result = list.Compare(s1, s2);

            Assert.AreEqual(-1, result);
        }

        [Test]
        public void Test_Сompare_WhenValuesAreStringsAndSecondLess()
        {
            var s1 = " 456 ";
            var s2 = "  455 ";
            var list = new OrderedList<string>(true);

            var result = list.Compare(s1, s2);

            Assert.AreEqual(1, result);
        }

        [Test]
        public void Test_Сompare_WhenValuesAreStringsAndEqual()
        {
            var s1 = " 456 ";
            var s2 = "456";
            var list = new OrderedList<string>(true);

            var result = list.Compare(s1, s2);

            Assert.AreEqual(0, result);
        }

        [Test]
        public void Test_Сompare_WhenValuesAreNumbersAndFirstLess()
        {
            var n1 = 456;
            var n2 = 457;
            var list = new OrderedList<int>(true);

            var result = list.Compare(n1, n2);

            Assert.AreEqual(-1, result);
        }

        [Test]
        public void Test_Сompare_WhenValuesAreNumbersAndSecondLess()
        {
            var n1 = 456;
            var n2 = 455;
            var list = new OrderedList<int>(true);

            var result = list.Compare(n1, n2);

            Assert.AreEqual(1, result);
        }

        [Test]
        public void Test_Сompare_WhenValuesAreNumbersAndEqual()
        {
            var n1 = 456;
            var n2 = 456;
            var list = new OrderedList<int>(true);

            var result = list.Compare(n1, n2);

            Assert.AreEqual(0, result);
        }

        [Test]
        public void Test_Add_WhenAddedInHead()
        {
            var list = new OrderedList<int>(true);

            list.Add(2);
            list.Add(1);

            Assert.AreEqual("[1, 2]", list.ToString());
        }

        [Test]
        public void Test_Add_WhenAddedInTail()
        {
            var list = new OrderedList<int>(true);

            list.Add(1);
            list.Add(2);

            Assert.AreEqual("[1, 2]", list.ToString());
        }

        [Test]
        public void Test_Add_WhenAddedInMiddle()
        {
            var list = new OrderedList<int>(true);

            list.Add(1);
            list.Add(3);
            list.Add(2);

            Assert.AreEqual("[1, 2, 3]", list.ToString());
        }

        [Test]
        public void Test_Add_WhenAddedExistingValueInMiddle()
        {
            var list = new OrderedList<int>(true);

            list.Add(1);
            list.Add(2);
            list.Add(2);

            Assert.AreEqual("[1, 2, 2]", list.ToString());
        }

        [Test]
        public void Test_Add_WhenDeletedFromHead()
        {
            var list = new OrderedList<int>(true);

            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Delete(1);

            Assert.AreEqual("[2, 3]", list.ToString());
        }

        [Test]
        public void Test_Add_WhenDeletedFromTail()
        {
            var list = new OrderedList<int>(true);

            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Delete(3);

            Assert.AreEqual("[1, 2]", list.ToString());
        }

        [Test]
        public void Test_Add_WhenDeletedFromMiddle()
        {
            var list = new OrderedList<int>(true);

            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Delete(2);

            Assert.AreEqual("[1, 3]", list.ToString());
        }

        [Test]
        public void Test_Find_WhenFilledOut()
        {
            var list = new OrderedList<int>(true);

            list.Add(1);
            list.Add(2);
            list.Add(3);
            var result = list.Find(2);

            Assert.AreEqual(2, result.value);
        }

        [Test]
        public void Test_Find_WhenNotFound()
        {
            var list = new OrderedList<int>(true);

            list.Add(1);
            list.Add(2);
            list.Add(3);
            var result = list.Find(4);

            Assert.AreEqual(null, result);
        }

        [Test]
        public void Test_Count_WhenNotFound()
        {
            var list = new OrderedList<int>(true);

            list.Add(1);
            list.Add(2);
            list.Add(3);
            var result = list.Count();

            Assert.AreEqual(3, result);
        }
    }
}
