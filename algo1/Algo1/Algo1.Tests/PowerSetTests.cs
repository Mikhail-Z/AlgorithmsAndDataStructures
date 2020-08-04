using System;
using AlgorithmsDataStructuresPowerSet;
using NUnit.Framework;

namespace MySet.Tests
{
    public class PowerSetTests
    {
        [Test]
        public void Test_Put_WhenSameValue()
        {
            var set = new PowerSet<int>();

            set.Put(1);
            set.Put(2);
            set.Put(1);

            Assert.AreEqual(2, set.Size());
        }

        [Test]
        public void Test_Get_WhenNoValue()
        {
            var set = new PowerSet<int>();

            set.Put(1);
            set.Put(2);
            set.Put(1);

            Assert.AreEqual(false, set.Get(3));
        }

        [Test]
        public void Test_Get_WhenValueExists()
        {
            var set = new PowerSet<string>();

            set.Put("a");
            set.Put("b");
            set.Put("a");

            Assert.AreEqual(true, set.Get("b"));
            Assert.AreEqual(false, set.Get("k"));
        }

        [Test]
        public void Test_Remove_WhenValueExists()
        {
            // возвращает true если value удалено
            // иначе false
            var set = new PowerSet<string>();

            set.Put("a");
            set.Put("b");
            set.Put("a");

            var result = set.Remove("a");

            Assert.AreEqual(true, result);
            Assert.AreEqual(false, set.Get("a"));
            Assert.AreEqual(true, set.Get("b"));
            Assert.AreEqual(false, set.Get("k"));
            Assert.AreEqual(1, set.Size());
        }

        [Test]
        public void Test_Remove_WhenValueDoesntExist()
        {
            // возвращает true если value удалено
            // иначе false
            var set = new PowerSet<int>();
            set.Put(1);
            set.Put(2);
            set.Put(1);

            var result = set.Remove(3);

            Assert.AreEqual(false, result);
            Assert.AreEqual(true, set.Get(1));
            Assert.AreEqual(true, set.Get(2));
            Assert.AreEqual(2, set.Size());
        }

        [Test]
        public void Test_Intersection_WhenFirstSetIsEmpty()
        {
            // возвращает true если value удалено
            // иначе false
            var set1 = new PowerSet<int>();
            var set2 = new PowerSet<int>();
            set2.Put(1);
            set2.Put(2);
            var result = set1.Intersection(set2);

            Assert.AreEqual(0, result.Size());
            Assert.AreEqual(false, result.Get(1));
            Assert.AreEqual(false, result.Get(2));
        }

        [Test]
        public void Test_Intersection_WhenSecondSetIsEmpty()
        {
            // возвращает true если value удалено
            // иначе false
            var set1 = new PowerSet<int>();
            var set2 = new PowerSet<int>();
            set2.Put(1);
            set2.Put(2);
            var result = set2.Intersection(set1);

            Assert.AreEqual(0, result.Size());
            Assert.AreEqual(false, result.Get(1));
            Assert.AreEqual(false, result.Get(2));
        }

        [Test]
        public void Test_Intersection()
        {
            // возвращает true если value удалено
            // иначе false
            var set1 = new PowerSet<int>();
            var set2 = new PowerSet<int>();
            set1.Put(1);
            set1.Put(3);
            set2.Put(1);
            set2.Put(2);
            var result = set2.Intersection(set1);

            Assert.AreEqual(1, result.Size());
            Assert.AreEqual(true, result.Get(1));
        }

        [Test]
        public void Test_Union_WhenBothSetsAreEmpty()
        {
            // возвращает true если value удалено
            // иначе false
            var set1 = new PowerSet<int>();
            var set2 = new PowerSet<int>();
            
            var result = set1.Union(set2);

            Assert.AreEqual(0, result.Size());
        }

        [Test]
        public void Test_Union_WhenFirstSetIsEmpty()
        {
            // возвращает true если value удалено
            // иначе false
            var set1 = new PowerSet<int>();
            var set2 = new PowerSet<int>();
            set2.Put(1);
            set2.Put(2);
            var result = set1.Union(set2);

            Assert.AreEqual(2, result.Size());
        }

        [Test]
        public void Test_Union_WhenSecondSetIsEmpty()
        {
            // возвращает true если value удалено
            // иначе false
            var set1 = new PowerSet<int>();
            var set2 = new PowerSet<int>();
            set1.Put(1);
            set1.Put(2);
            var result = set1.Union(set2);

            Assert.AreEqual(2, result.Size());
        }

        [Test]
        public void Test_Union()
        {
            // возвращает true если value удалено
            // иначе false
            var set1 = new PowerSet<int>();
            var set2 = new PowerSet<int>();
            set1.Put(1);
            set1.Put(2);
            set2.Put(1);
            set2.Put(3);
            var result = set1.Union(set2);

            Assert.AreEqual(3, result.Size());
        }

        [Test]
        public void Test_Difference_WhenBothSetsAreEmpty()
        {
            // возвращает true если value удалено
            // иначе false
            var set1 = new PowerSet<int>();
            var set2 = new PowerSet<int>();
            var result = set1.Difference(set2);

            Assert.AreEqual(0, result.Size());
        }

        [Test]
        public void Test_Difference_WhenFirstSetIsEmpty()
        {
            // возвращает true если value удалено
            // иначе false
            var set1 = new PowerSet<int>();
            var set2 = new PowerSet<int>();
            set2.Put(1);
            set2.Put(3);
            var result = set1.Difference(set2);

            Assert.AreEqual(0, result.Size());
        }

        [Test]
        public void Test_Difference_WhenSecondSetIsEmpty()
        {
            // возвращает true если value удалено
            // иначе false
            var set1 = new PowerSet<int>();
            var set2 = new PowerSet<int>();
            set1.Put(1);
            set1.Put(3);

            var result = set1.Difference(set2);

            Assert.AreEqual(2, result.Size());
        }

        [Test]
        public void Test_Difference()
        {
            // возвращает true если value удалено
            // иначе false
            var set1 = new PowerSet<int>();
            var set2 = new PowerSet<int>();
            set1.Put(1);
            set1.Put(2);
            set2.Put(1);
            set2.Put(3);

            var result = set1.Difference(set2);

            Assert.AreEqual(1, result.Size());
            Assert.AreEqual(true, result.Get(2));
            Assert.AreEqual(false, result.Get(1));
        }


        [Test]
        public void Test_IsSubset_WhenFalse()
        {
            // возвращает true если value удалено
            // иначе false
            var set1 = new PowerSet<int>();
            var set2 = new PowerSet<int>();
            set1.Put(1);
            set1.Put(2);
            set2.Put(1);
            set2.Put(3);

            var result = set1.IsSubset(set2);

            Assert.AreEqual(false, result);
        }

        [Test]
        public void Test_IsSubset_WhenTrue()
        {
            // возвращает true если value удалено
            // иначе false
            var set1 = new PowerSet<int>();
            var set2 = new PowerSet<int>();
            set1.Put(1);
            set1.Put(2);
            set1.Put(3);
            set2.Put(1);
            set2.Put(3);

            var result = set1.IsSubset(set2);

            Assert.AreEqual(true, result);
        }
    }
}