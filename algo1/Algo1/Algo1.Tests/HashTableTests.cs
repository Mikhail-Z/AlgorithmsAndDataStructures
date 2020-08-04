using NUnit.Framework;
using AlgorithmsDataStructuresHashTable;


namespace AlgorithmsDataStructuresTests
{
    public class HastTableTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test_HashFun()
        {
            var hashTable = new HashTable(10, 2);

            var result = hashTable.HashFun("aaa");

            Assert.AreEqual(1, result);
        }

        [Test]
        public void Test_SeekSlot_WhenNoCollision()
        {
            var hashTable = new HashTable(10, 2);

            var result = hashTable.SeekSlot("aaa");

            Assert.AreEqual(1, result);
        }

        [Test]
        public void Test_SeekSlot_WhenCollisionAndStepMultiplesSize()
        {
            var hashTable = new HashTable(10, 2);

            var result = hashTable.SeekSlot("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");

            Assert.AreEqual(1, result);
        }

        [Test]
        public void Test_SeekSlot_WhenCollisionAndStepMultiplesSizeFound()
        {
            var hashTable = new HashTable(10, 2);

            hashTable.Put("a");
            var result = hashTable.SeekSlot("k");

            Assert.AreEqual(9, result);
        }

        [Test]
        public void Test_SeekSlot_WhenCollisionAndStepMultiplesSizeFoundStepChanged()
        {
            var hashTable = new HashTable(10, 2);

            hashTable.Put("a");
            hashTable.Put("c");
            hashTable.Put("e");
            hashTable.Put("g");
            hashTable.Put("i");
            var result = hashTable.SeekSlot("k");

            Assert.AreEqual(8, result);
        }

        [Test]
        public void Test_SeekSlot_WhenCollisionAndStepMultiplesSizeNoFound()
        {
            var hashTable = new HashTable(10, 2);

            hashTable.Put("a");
            hashTable.Put("b");
            hashTable.Put("c");
            hashTable.Put("d");
            hashTable.Put("e");
            hashTable.Put("f");
            hashTable.Put("g");
            hashTable.Put("h");
            hashTable.Put("i");
            hashTable.Put("j");
            var result = hashTable.SeekSlot("k");

            Assert.AreEqual(-1, result);
        }

        [Test]
        public void Test_SeekSlot_WhenCollisionAndStepDoesntMultipleSizeAndNoFound()
        {
            var hashTable = new HashTable(10, 3);

            hashTable.Put("a");
            hashTable.Put("b");
            hashTable.Put("c");
            hashTable.Put("d");
            hashTable.Put("e");
            hashTable.Put("f");
            hashTable.Put("g");
            hashTable.Put("h");
            hashTable.Put("i");
            hashTable.Put("j");
            var result = hashTable.SeekSlot("k");

            Assert.AreEqual(-1, result);
        }

        [Test]
        public void Test_SeekSlot_WhenCollisionAndStepDoesntMultipleSizeAndFound()
        {
            var hashTable = new HashTable(10, 3);

            hashTable.Put("a");
            hashTable.Put("d");
            hashTable.Put("g");
            var result = hashTable.SeekSlot("j");

            Assert.AreEqual(6, result);
        }

        [Test]
        public void Test_Find_WhenFoundAndStepDoesntMultipleSize()
        {
            var hashTable = new HashTable(10, 3);

            var slot1 = hashTable.Put("a");
            var slot2 = hashTable.Put("d");
            var slot3 = hashTable.Put("g");
            var result1 = hashTable.Find("a");
            var result2 = hashTable.Find("d");
            var result3 = hashTable.Find("g");

            Assert.AreEqual(slot1, result1);
            Assert.AreEqual(slot2, result2);
            Assert.AreEqual(slot3, result3);
        }

        public void Test_Find_WhenFoundAndStepMultiplesSize()
        {
            var hashTable = new HashTable(10, 2);

            var slot1 = hashTable.Put("a");
            var slot2 = hashTable.Put("c");
            var slot3 = hashTable.Put("e");
            var result1 = hashTable.Find("a");
            var result2 = hashTable.Find("c");
            var result3 = hashTable.Find("e");

            Assert.AreEqual(slot1, result1);
            Assert.AreEqual(slot2, result2);
            Assert.AreEqual(slot3, result3);
        }

        [Test]
        public void Test_Find_WhenNotFoundAndStepDoesntMultipleSize()
        {
            var hashTable = new HashTable(10, 3);

            var slot1 = hashTable.Put("a");
            var slot2 = hashTable.Put("d");
            var slot3 = hashTable.Put("g");
            var result1 = hashTable.Find("k");

            Assert.AreEqual(-1, result1);
        }

        [Test]
        public void Test_Find_WhenNotFoundAndStepMultiplesSize()
        {
            var hashTable = new HashTable(10, 2);

            var slot1 = hashTable.Put("a");
            var slot2 = hashTable.Put("c");
            var slot3 = hashTable.Put("e");
            var result1 = hashTable.Find("k");

            Assert.AreEqual(-1, result1);
        }
    }
}