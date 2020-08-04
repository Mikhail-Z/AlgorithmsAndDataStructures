using System;
using AlgorithmsDataStructuresDynArray;
using NUnit.Framework;

namespace AlgorithmsDataStructuresTests
{
    public class DynArrayTests
    {
        [Test]
        public void Test_MakeArray_WhenWrongNegativeCapacity()
        {
            var array = new DynArray<int>();
            Assert.Catch<ArgumentException>(() => array.MakeArray(0));
        }

        [Test]
        public void Test_MakeArray_WhenCapacityLowerThanSize()
        {
            var array = new DynArray<int>();
            for (var i = 0; i < 20; i++)
            {
                array.Append(i);
            }
            Assert.Catch<ArgumentException>(() => array.MakeArray(17));
        }

        [Test]
        public void Test_MakeArray_WhenNewCapacityIsHigher()
        {
            var newCapacity = 100;
            var newCount = 18;
            var array = new DynArray<int>();
            for (var i = 0; i < newCount; i++)
            {
                array.Append(i+1);
            }
            var arrayRepr = "[1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18]";

            array.MakeArray(newCapacity);
            Assert.AreEqual(newCapacity, array.capacity);
            Assert.AreEqual(newCount, array.count);
            Assert.AreEqual(arrayRepr, array.ToString());
        }

        [Test]
        public void Test_GetItem_WhenIndexIsNegative()
        {
            var array = new DynArray<int>();
            Assert.Catch<ArgumentOutOfRangeException>(() => array.GetItem(-1));
        }

        [Test]
        public void Test_GetItem_WhenIndexIsZero()
        {
            var actualItem = 1;
            var actualRepr = "[1]";
            var array = new DynArray<int>();
            array.Append(actualItem);
            var item = array.GetItem(0);
            Assert.AreEqual(actualItem, item);
            Assert.AreEqual(actualRepr, array.ToString());
        }

        [Test]
        public void Test_GetItem_WhenIndexIsCount()
        {
            var actualItem = 1;
            var array = new DynArray<int>();
            array.Append(actualItem);
            Assert.Catch<ArgumentOutOfRangeException>(() => array.GetItem(2));
        }

        [Test]
        public void Test_Append_WhenCapacityIsChanged()
        {
            var newCount = 18;
            var array = new DynArray<int>();
            for (var i = 0; i < newCount; i++)
            {
                array.Append(i + 1);
            }
            var arrayRepr = "[1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18]";

            Assert.AreEqual(16 * 2, array.capacity);
            Assert.AreEqual(newCount, array.count);
            Assert.AreEqual(arrayRepr, array.ToString());
        }

        [Test]
        public void Test_Append_WhenCapacityIsNotChanged()
        {
            var newCount = 16;
            var array = new DynArray<int>();
            for (var i = 0; i < newCount; i++)
            {
                array.Append(i + 1);
            }
            var arrayRepr = "[1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16]";

            Assert.AreEqual(16, array.capacity);
            Assert.AreEqual(newCount, array.count);
            Assert.AreEqual(arrayRepr, array.ToString());
        }

        [Test]
        public void Test_Insert_WhenPositionIsNegative()
        {
            var array = new DynArray<int>();
            Assert.Catch<ArgumentOutOfRangeException>(() => array.Insert(1, -1));
        }

        [Test]
        public void Test_Insert_WhenCapacityPositionIsHigherThanCount()
        {
            var array = new DynArray<int>();
            Assert.Catch<ArgumentOutOfRangeException>(() => array.Insert(1, 1));
        }

        [Test]
        public void Test_Insert_WhenCapacityIsNotChanged()
        {
            var newCount = 16;
            var array = new DynArray<int>();

            for (var i = 0; i < newCount; i++)
            {
                array.Insert(i+1, 0);
            }
            var arrayRepr = "[16, 15, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1]";

            Assert.AreEqual(16, array.capacity);
            Assert.AreEqual(newCount, array.count);
            Assert.AreEqual(arrayRepr, array.ToString());
        }

        [Test]
        public void Test_Insert_WhenCapacityIsChanged()
        {
            var newCount = 18;
            var array = new DynArray<int>();
            for (var i = 0; i < newCount; i++)
            {
                array.Insert(i+1, i);
            }
            var arrayRepr = "[1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18]";

            Assert.AreEqual(16 * 2, array.capacity);
            Assert.AreEqual(newCount, array.count);
            Assert.AreEqual(arrayRepr, array.ToString());
        }

        [Test]
        public void Test_Remove_WhenCapacityIsNotChangedWhenSizeIsHalfOfCapacity()
        {
            var newCount = 18;
            var array = new DynArray<int>();
            for (var i = 0; i < newCount; i++)
            {
                array.Insert(i + 1, i);
            }
            array.Remove(17);
            array.Remove(5);
            var arrayRepr = "[1, 2, 3, 4, 5, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17]";

            Assert.AreEqual(16 * 2, array.capacity);
            Assert.AreEqual(newCount - 2, array.count);
            Assert.AreEqual(arrayRepr, array.ToString());
        }

        [Test]
        public void Test_Remove_WhenCapacityIsChanged()
        {
            var newCount = 34;
            var array = new DynArray<int>();
            for (var i = 0; i < newCount; i++)
            {
                array.Insert(i + 1, i);
            }
            array.Remove(17);
            array.Remove(16);
            array.Remove(5);
            Assert.AreEqual(42, array.capacity);
            Assert.AreEqual(newCount - 3, array.count);
        }

        [Test]
        public void Test_Remove_WhenIndexIsHigherThanCount()
        {
            var array = new DynArray<int>();
            Assert.Catch<ArgumentOutOfRangeException>(() => array.Remove(0));
        }

        [Test]
        public void Test_Remove_WhenIndexIsNegative()
        {
            var array = new DynArray<int>();
            Assert.Catch<ArgumentOutOfRangeException>(() => array.Remove(-1));
        }
    }
}