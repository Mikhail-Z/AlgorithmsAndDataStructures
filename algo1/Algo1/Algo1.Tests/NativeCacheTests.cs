using System;
using NUnit.Framework;
using AlgorithmsDataStructuresNativeCache;

namespace AlgorithmsDataStructuresTests
{
    public class NativeCacheTests
    {
        [Test]
        public void Test_IsKey_WithNoSuchKey()
        {
            var cache = new NativeCache<int>(3);
            cache.Put("b", 2);

            var result = cache.IsKey("a");

            Assert.AreEqual(false, result);
        }

        [Test]
        public void Test_IsKey_WhenKeyExists()
        {
            var cache = new NativeCache<int>(3);
            cache.Put("a", 1);
            cache.Put("b", 2);
            cache.Put("c", 3);

            cache.Get("a");
            cache.Get("a");
            cache.Get("a");
            cache.Get("b");
            cache.Get("b");
            cache.Get("c");
            cache.Put("d", 4);

            Assert.AreEqual(true, cache.IsKey("a"));
            Assert.AreEqual(true, cache.IsKey("b"));
            Assert.AreEqual(true, cache.IsKey("d"));
            Assert.AreEqual(false, cache.IsKey("c"));
            CollectionAssert.AreEqual(new int[] { 0, 3, 2 }, cache.hits);
            Assert.AreEqual(1, cache.Get("a"));
            Assert.AreEqual(2, cache.Get("b"));
            Assert.AreEqual(4, cache.Get("d"));
        }
    }
}