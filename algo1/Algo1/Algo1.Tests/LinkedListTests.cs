using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using AlgorithmsDataStructuresLinkedList;

namespace AlgorithmsDataStructuresTests
{
    public class LinkedListTests
    {
        [Test]
        public void Test_AddInTail_Once()
        {
            var list = new LinkedList();
            var node1 = new Node(1);
            list.AddInTail(node1);
            Assert.AreEqual(list.tail, list.head);
            Assert.AreEqual(node1, list.head);
        }

        [Test]
        public void Test_AddInTail_TwoTimes()
        {
            var list = new LinkedList();
            var node1 = new Node(1);
            var node2 = new Node(1);
            list.AddInTail(node1);
            list.AddInTail(node2);
            Assert.AreEqual(node1, list.head);
            Assert.AreEqual(node2, list.tail);
        }

        [Test]
        public void Test_InsertAfter_WhenEmpty()
        {
            var list = new LinkedList();
            var head = list.head;
            var node1 = new Node(1);
            var expected = "[1]";
            list.InsertAfter(head, node1);
            Assert.AreEqual(node1, list.head);
            Assert.AreEqual(node1, list.tail);
            Assert.AreEqual(expected, list.ToString());
        }

        [Test]
        public void Test_Count_WhenEmpty()
        {
            var list = new LinkedList();
            var count = list.Count();
            Assert.AreEqual(0, count);
        }

        [Test]
        public void Test_Count_WhenNonEmpty()
        {
            var list = new LinkedList();
            var node = new Node(1);
            list.AddInTail(node);
            var count = list.Count();
            Assert.AreEqual(1, count);
        }

        [Test]
        public void Test_Clear_WhenNonEmpty()
        {
            var list = new LinkedList();
            var node1 = new Node(1);
            list.AddInTail(node1);
            list.Clear();
            var count = list.Count();
            Assert.AreEqual(null, list.head);
            Assert.AreEqual(null, list.tail);
            Assert.AreEqual(0, count);
        }

        [Test]
        public void Test_Find_WhenOneFoundItem()
        {
            var list = new LinkedList();
            var node1 = new Node(1);
            var node2 = new Node(2);
            list.AddInTail(node1);
            list.AddInTail(node2);
            var foundNode = list.Find(node2.value);
            Assert.AreEqual(node2, foundNode);
        }

        [Test]
        public void Test_Find_WhenManyFoundItems()
        {
            var list = new LinkedList();
            var sameValue = 2;
            var node1 = new Node(1);
            var node2 = new Node(sameValue);
            var node3 = new Node(4);
            var node4 = new Node(sameValue);
            list.AddInTail(node1);
            list.AddInTail(node2);
            list.AddInTail(node3);
            list.AddInTail(node4);
            var foundNode = list.Find(sameValue);
            Assert.AreEqual(node2, foundNode);
        }

        [Test]
        public void Test_Find_WhenNoFoundItems()
        {
            var list = new LinkedList();
            var sameValue = 2;
            var node1 = new Node(1);
            var node2 = new Node(sameValue);
            var node3 = new Node(4);
            var node4 = new Node(sameValue);
            list.AddInTail(node1);
            list.AddInTail(node2);
            list.AddInTail(node3);
            list.AddInTail(node4);
            var foundValue = list.Find(0);
            Assert.AreEqual(null, foundValue);
        }

        [Test]
        public void Test_FindAll_WhenManyFoundItems()
        {
            var list = new LinkedList();
            var sameValue = 2;
            var node1 = new Node(1);
            var node2 = new Node(sameValue);
            var node3 = new Node(4);
            var node4 = new Node(sameValue);
            var expected = new List<Node>() { node2, node4 };
            list.AddInTail(node1);
            list.AddInTail(node2);
            list.AddInTail(node3);
            list.AddInTail(node4);
            var foundNodes = list.FindAll(sameValue);
            CollectionAssert.AreEqual(expected, foundNodes);
        }

        [Test]
        public void Test_FindAll_WhenNoFoundItems()
        {
            var list = new LinkedList();
            var sameValue = 2;
            var node1 = new Node(1);
            var node2 = new Node(sameValue);
            var node3 = new Node(4);
            var node4 = new Node(sameValue);
            var expected = new List<Node>();
            list.AddInTail(node1);
            list.AddInTail(node2);
            list.AddInTail(node3);
            list.AddInTail(node4);
            var foundNodes = list.FindAll(0);
            CollectionAssert.AreEqual(expected, foundNodes);
        }

        [Test]
        public void Test_InsertAfter_WhenNodeIsInMiddle()
        {
            var list = new LinkedList();
            var node1 = new Node(1);
            var node2 = new Node(2);
            var node3 = new Node(3);
            var insertedNode = new Node(0);
            list.AddInTail(node1);
            list.AddInTail(node2);
            list.AddInTail(node3);
            var head = list.head;
            var tail = list.tail;
            list.InsertAfter(node1, insertedNode);
            var expected = "[1, 0, 2, 3]";
            Assert.AreEqual(expected, list.ToString());
            Assert.AreEqual(head, list.head);
            Assert.AreEqual(tail, list.tail);
        }

        [Test]
        public void Test_InsertAfter_WhenNodeIsHead()
        {
            var list = new LinkedList();
            var node1 = new Node(1);
            var node3 = new Node(3);
            var insertedNode = new Node(0);
            list.AddInTail(node1);
            list.AddInTail(node3);
            var head = list.head;
            var tail = list.tail;
            list.InsertAfter(node1, insertedNode);
            var expected = "[1, 0, 3]";
            Assert.AreEqual(expected, list.ToString());
            Assert.AreEqual(head, list.head);
            Assert.AreEqual(tail, list.tail);
        }

        [Test]
        public void Test_InsertAfter_WhenOneItemInList()
        {
            var list = new LinkedList();
            var node1 = new Node(1);
            var insertedNode = new Node(0);
            list.AddInTail(node1);
            var head = list.head;
            list.InsertAfter(node1, insertedNode);
            var expected = "[1, 0]";
            Assert.AreEqual(expected, list.ToString());
            Assert.AreEqual(head, list.head);
            Assert.AreEqual(insertedNode, list.tail);
        }

        [Test]
        public void Test_InsertAfter_WhenNodeIsTail()
        {
            var list = new LinkedList();
            var node1 = new Node(1);
            var node2 = new Node(2);
            var node3 = new Node(3);
            var insertedNode = new Node(0);
            list.AddInTail(node1);
            list.AddInTail(node2);
            list.AddInTail(node3);
            var head = list.head;
            var tail = list.tail;
            list.InsertAfter(node3, insertedNode);
            var expected = "[1, 2, 3, 0]";
            Assert.AreEqual(expected, list.ToString());
            Assert.AreEqual(head, list.head);
            Assert.AreEqual(insertedNode, list.tail);
        }

        [Test]
        public void Test_Remove_WhenNoFoundItemsInMiddle()
        {
            var list = new LinkedList();
            var node1 = new Node(1);
            var node2 = new Node(2);
            var node3 = new Node(3);
            list.AddInTail(node1);
            list.AddInTail(node2);
            list.AddInTail(node3);
            var head = list.head;
            var tail = list.tail;
            list.Remove(0);
            var expected = "[1, 2, 3]";
            Assert.AreEqual(expected, list.ToString());
            Assert.AreEqual(head, list.head);
            Assert.AreEqual(tail, list.tail);
        }



        [Test]
        public void Test_Remove_WhenOneFoundItemInMiddle()
        {
            var list = new LinkedList();
            var deletedValue = 2;
            var node1 = new Node(1);
            var node2 = new Node(deletedValue);
            var node3 = new Node(3);
            list.AddInTail(node1);
            list.AddInTail(node2);
            list.AddInTail(node3);
            var head = list.head;
            var tail = list.tail;
            list.Remove(deletedValue);
            var expected = "[1, 3]";
            Assert.AreEqual(expected, list.ToString());
            Assert.AreEqual(head, list.head);
            Assert.AreEqual(tail, list.tail);
        }

        [Test]
        public void Test_Remove_WhenManyFoundItemsInMiddle()
        {
            var list = new LinkedList();
            var deletedValue = 2;
            var node1 = new Node(1);
            var node2 = new Node(deletedValue);
            var node3 = new Node(deletedValue);
            var node4 = new Node(3);
            list.AddInTail(node1);
            list.AddInTail(node2);
            list.AddInTail(node3);
            list.AddInTail(node4);
            var head = list.head;
            var tail = list.tail;
            list.Remove(deletedValue);
            var expected = "[1, 2, 3]";
            Assert.AreEqual(expected, list.ToString());
            Assert.AreEqual(head, list.head);
            Assert.AreEqual(tail, list.tail);
        }

        [Test]
        public void Test_Remove_WhenFoundItemInHead()
        {
            var list = new LinkedList();
            var deletedValue = 1;
            var node1 = new Node(deletedValue);
            var node2 = new Node(2);
            var node3 = new Node(3);
            list.AddInTail(node1);
            list.AddInTail(node2);
            list.AddInTail(node3);
            var tail = list.tail;
            list.Remove(deletedValue);
            var expected = "[2, 3]";
            Assert.AreEqual(expected, list.ToString());
            Assert.AreEqual(node2, list.head);
            Assert.AreEqual(tail, list.tail);
        }

        [Test]
        public void Test_Remove_WhenFoundItemInTail()
        {
            var list = new LinkedList();
            var deletedValue = 3;
            var node1 = new Node(1);
            var node2 = new Node(2);
            var node3 = new Node(deletedValue);
            list.AddInTail(node1);
            list.AddInTail(node2);
            list.AddInTail(node3);
            var head = list.head;
            list.Remove(deletedValue);
            var expected = "[1, 2]";
            Assert.AreEqual(expected, list.ToString());
            Assert.AreEqual(head, list.head);
            Assert.AreEqual(node2, list.tail);
        }

        [Test]
        public void Test_Remove_WhenFoundItemInHeadTwoTimes()
        {
            var list = new LinkedList();
            var deletedValue = 1;
            var node1 = new Node(deletedValue);
            var node2 = new Node(deletedValue);
            var node3 = new Node(2);
            var node4 = new Node(3);
            list.AddInTail(node1);
            list.AddInTail(node2);
            list.AddInTail(node3);
            list.AddInTail(node4);
            var tail = list.tail;
            list.Remove(deletedValue);
            list.Remove(deletedValue);
            var expected = "[2, 3]";
            Assert.AreEqual(expected, list.ToString());
            Assert.AreEqual(node3, list.head);
            Assert.AreEqual(tail, list.tail);
        }

        [Test]
        public void Test_Remove_WhenFoundItemInTailTwoTimes()
        {
            var list = new LinkedList();
            var deletedValue = 3;
            var node1 = new Node(1);
            var node2 = new Node(2);
            var node3 = new Node(deletedValue);
            var node4 = new Node(deletedValue);
            list.AddInTail(node1);
            list.AddInTail(node2);
            list.AddInTail(node3);
            list.AddInTail(node4);
            var head = list.head;
            list.Remove(deletedValue);
            list.Remove(deletedValue);
            var expected = "[1, 2]";
            Assert.AreEqual(expected, list.ToString());
            Assert.AreEqual(head, list.head);
            Assert.AreEqual(node2, list.tail);
        }

        [Test]
        public void Test_RemoveAll_WhenNoFoundItemsInMiddle()
        {
            var list = new LinkedList();
            var deletedValue = 0;
            var node1 = new Node(1);
            var node2 = new Node(2);
            var node3 = new Node(3);
            list.AddInTail(node1);
            list.AddInTail(node2);
            list.AddInTail(node3);
            var head = list.head;
            var tail = list.tail;
            list.RemoveAll(deletedValue);
            var expected = "[1, 2, 3]";
            Assert.AreEqual(expected, list.ToString());
            Assert.AreEqual(head, list.head);
            Assert.AreEqual(tail, list.tail);
        }

        [Test]
        public void Test_RemoveAll_WhenOneFoundItemInMiddle()
        {
            var list = new LinkedList();
            var deletedValue = 2;
            var node1 = new Node(1);
            var node2 = new Node(deletedValue);
            var node3 = new Node(3);
            list.AddInTail(node1);
            list.AddInTail(node2);
            list.AddInTail(node3);
            var head = list.head;
            var tail = list.tail;
            list.RemoveAll(deletedValue);
            var expected = "[1, 3]";
            Assert.AreEqual(expected, list.ToString());
            Assert.AreEqual(head, list.head);
            Assert.AreEqual(tail, list.tail);
        }

        [Test]
        public void Test_RemoveAll_WhenManyFoundItemsInMiddle()
        {
            var list = new LinkedList();
            var deletedValue = 2;
            var node1 = new Node(1);
            var node2 = new Node(deletedValue);
            var node3 = new Node(deletedValue);
            var node4 = new Node(3);
            list.AddInTail(node1);
            list.AddInTail(node2);
            list.AddInTail(node3);
            list.AddInTail(node4);
            var head = list.head;
            var tail = list.tail;
            list.RemoveAll(deletedValue);
            var expected = "[1, 3]";
            Assert.AreEqual(expected, list.ToString());
            Assert.AreEqual(head, list.head);
            Assert.AreEqual(tail, list.tail);
        }

        [Test]
        public void Test_RemoveAll_WhenFoundItemInHead()
        {
            var list = new LinkedList();
            var deletedValue = 1;
            var node1 = new Node(deletedValue);
            var node2 = new Node(2);
            var node3 = new Node(3);
            list.AddInTail(node1);
            list.AddInTail(node2);
            list.AddInTail(node3);
            var tail = list.tail;
            list.RemoveAll(deletedValue);
            var expected = "[2, 3]";
            Assert.AreEqual(expected, list.ToString());
            Assert.AreEqual(node2, list.head);
            Assert.AreEqual(tail, list.tail);
        }

        [Test]
        public void Test_RemoveAll_WhenFoundItemInTail()
        {
            var list = new LinkedList();
            var deletedValue = 3;
            var node1 = new Node(1);
            var node2 = new Node(2);
            var node3 = new Node(deletedValue);
            var insertedNode = new Node(0);
            list.AddInTail(node1);
            list.AddInTail(node2);
            list.AddInTail(node3);
            var head = list.head;
            list.RemoveAll(deletedValue);
            var expected = "[1, 2]";
            Assert.AreEqual(expected, list.ToString());
            Assert.AreEqual(head, list.head);
            Assert.AreEqual(node2, list.tail);
        }

        [Test]
        public void Test_RemoveAll_WhenFoundItemInTailTwoTimes()
        {
            var list = new LinkedList();
            var deletedValue = 3;
            var node1 = new Node(1);
            var node2 = new Node(2);
            var node3 = new Node(deletedValue);
            var node4 = new Node(deletedValue);
            var insertedNode = new Node(0);
            list.AddInTail(node1);
            list.AddInTail(node2);
            list.AddInTail(node3);
            list.AddInTail(node4);
            var head = list.head;
            list.RemoveAll(deletedValue);
            var expected = "[1, 2]";
            Assert.AreEqual(expected, list.ToString());
            Assert.AreEqual(head, list.head);
            Assert.AreEqual(node2, list.tail);
        }
        [Test]
        public void Test_RemoveAll_WhenFoundItemInHeadTwoTimes()
        {
            var list = new LinkedList();
            var deletedValue = 1;
            var node1 = new Node(deletedValue);
            var node2 = new Node(deletedValue);
            var node3 = new Node(3);
            var node4 = new Node(4);
            list.AddInTail(node1);
            list.AddInTail(node2);
            list.AddInTail(node3);
            list.AddInTail(node4);
            var tail = list.tail;
            list.RemoveAll(deletedValue);
            var expected = "[3, 4]";
            Assert.AreEqual(expected, list.ToString());
            Assert.AreEqual(node3, list.head);
            Assert.AreEqual(tail, list.tail);
        }

        [Test]
        public void Test_Remove_WhenListFromOneElement()
        {
            var list = new LinkedList();
            var deletedValue = 2;
            var node1 = new Node(deletedValue);
            list.AddInTail(node1);
            list.Remove(deletedValue);
            var expected = "[]";
            Assert.AreEqual(expected, list.ToString());
            Assert.AreEqual(null, list.head);
            Assert.AreEqual(null, list.tail);
        }


        [Test]
        public void Test_RemoveAll_WhenListFromOneElement()
        {
            var list = new LinkedList();
            var deletedValue = 2;
            var node1 = new Node(deletedValue);
            list.AddInTail(node1);
            list.RemoveAll(deletedValue);
            var expected = "[]";
            Assert.AreEqual(expected, list.ToString());
            Assert.AreEqual(null, list.head);
            Assert.AreEqual(null, list.tail);
        }

        [Test]
        public void Test_Remove_WhenListIsEmpty()
        {
            var list = new LinkedList();
            var deletedValue = 2;
            list.Remove(deletedValue);
            var expected = "[]";
            Assert.AreEqual(expected, list.ToString());
            Assert.AreEqual(null, list.head);
            Assert.AreEqual(null, list.tail);
        }

        [Test]
        public void Test_Remove_WhenListContainsOneElement()
        {
            var list = new LinkedList();
            var deletedValue = 2;
            var node = new Node(deletedValue);
            list.AddInTail(node);
            list.Remove(deletedValue);
            var expected = "[]";
            Assert.AreEqual(expected, list.ToString());
            Assert.AreEqual(null, list.head);
            Assert.AreEqual(null, list.tail);
        }

        [Test]
        public void Test_RemoveAll_WhenListIsEmpty()
        {
            var list = new LinkedList();
            var deletedValue = 2;
            list.RemoveAll(deletedValue);
            var expected = "[]";
            Assert.AreEqual(expected, list.ToString());
            Assert.AreEqual(null, list.head);
            Assert.AreEqual(null, list.tail);
        }

        [Test]
        public void Test_RemoveAll_WhenListContainsOneElement()
        {
            var list = new LinkedList();
            var deletedValue = 2;
            var node1 = new Node(deletedValue);
            var node2 = new Node(deletedValue);
            list.AddInTail(node1);
            list.AddInTail(node2);
            list.RemoveAll(deletedValue);
            var expected = "[]";
            Assert.AreEqual(expected, list.ToString());
            Assert.AreEqual(null, list.head);
            Assert.AreEqual(null, list.tail);
        }
    }
}