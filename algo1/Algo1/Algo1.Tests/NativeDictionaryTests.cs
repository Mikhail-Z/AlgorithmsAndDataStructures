using System;
using NUnit.Framework;
using AlgorithmsDataStructuresNativeDictionary;

namespace AlgorithmsDataStructuresTests
{
    public class NativeDictionaryTests
    {
        [Test]
        public void Test_IsKey_WhenNoSuchKey()
        {
            var dictionary = new NativeDictionary<int>(10);
            dictionary.Put("b", 2);

            var result = dictionary.IsKey("a");

            Assert.AreEqual(false, result);
        }

        [Test]
        public void Test_IsKey_WhenKeyExists()
        {
            var dictionary = new NativeDictionary<int>(10);
            dictionary.Put("a", 1);
            dictionary.Put("b", 2);
            dictionary.Put("c", 3);
            dictionary.Put("d", 4);
            dictionary.Put("e", 5);
            dictionary.Put("f", 6);
            dictionary.Put("g", 7);
            dictionary.Put("h", 8);
            dictionary.Put("i", 9);
            dictionary.Put("j", 10);
            dictionary.Put("i", 10);

            Assert.AreEqual(true, dictionary.IsKey("a"));
            Assert.AreEqual(true, dictionary.IsKey("b"));
            Assert.AreEqual(true, dictionary.IsKey("c"));
            Assert.AreEqual(true, dictionary.IsKey("d"));
            Assert.AreEqual(true, dictionary.IsKey("e"));
            Assert.AreEqual(true, dictionary.IsKey("f"));
            Assert.AreEqual(true, dictionary.IsKey("g"));
            Assert.AreEqual(true, dictionary.IsKey("h"));
            Assert.AreEqual(true, dictionary.IsKey("i"));
            Assert.AreEqual(true, dictionary.IsKey("j"));
        }

        [Test]
        public void Test_Put_WhenNoExtend()
        {
            var dictionary = new NativeDictionary<int>(10);
            dictionary.Put("a", 1);
            dictionary.Put("b", 2);
            dictionary.Put("c", 3);
            dictionary.Put("d", 4);
            var result = dictionary.IsKey("c");

            Assert.AreEqual(true, result);
        }

        [Test]
        public void Test_Get()
        {
            var dictionary = new NativeDictionary<int>(2);
            dictionary.Put("a", 1);
            dictionary.Put("k", 2);

            var result = dictionary.Get("k");

            Assert.AreEqual(2, result);
        }
    }
}