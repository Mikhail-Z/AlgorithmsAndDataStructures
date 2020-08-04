using System;
using AlgorithmsDataStructuresBloomFilter;
using NUnit.Framework;

namespace AlgorithmsDataStructuresTests
{
    public class UnitTests
    {
        [Test]
        public void TestMethod1()
        {
            
            var bloomFilter = new BloomFilter(32);
            var values = new string[]
            {
                "0123456789",
                "1234567890",
                "2345678901",
                "3456789012",
                "4567890123",
                "5678901234",
                "6789012345",
                "7890123456",
                "8901234567",
                "9012345678"
            };
            foreach (var value in values)
            {
                bloomFilter.Add(value);
            }
            var expected = new bool[values.Length];
            for (int i = 0; i < values.Length; i++)
            {
                expected[i] = true;
            }

            var results = new bool[values.Length];
            for (int i = 0; i < values.Length; i++)
            {
                results[i] = bloomFilter.IsValue(values[i]);
            }

            CollectionAssert.AreEqual(expected, results);
        }
    }
}