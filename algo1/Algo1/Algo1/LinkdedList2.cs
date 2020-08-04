using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;

namespace AlgorithmsDataStructuresLinkedList2
{
    public class Node
    {
        public int value;
        public Node next, prev;

        public Node(int _value)
        {
            value = _value;
            next = null;
            prev = null;
        }
    }

    public class LinkedList2
    {
        public Node head;
        public Node tail;

        public LinkedList2()
        {
            head = null;
            tail = null;
        }

        public void AddInTail(Node _item)
        {
            if (head == null)
            {
                head = _item;
                head.next = null;
                head.prev = null;
            }
            else
            {
                tail.next = _item;
                _item.prev = tail;
            }
            tail = _item;
        }

        public Node Find(int _value)
        {
            Node node = head;
            while (node != null)
            {
                if (node.value == _value) return node;
                node = node.next;
            }
            return null;
        }

        public List<Node> FindAll(int _value)
        {
            var foundNodes = new List<Node>();
            var currentNode = head;
            while (currentNode != null)
            {
                if (currentNode.value == _value)
                {
                    foundNodes.Add(currentNode);
                }
                currentNode = currentNode.next;
            }

            return foundNodes;
        }

        public bool Remove(int _value)
        {
            var currentNode = head;
            while (currentNode != null)
            {
                if (currentNode.value == _value)
                {
                    return RemoveNode(currentNode);
                }

                currentNode = currentNode.next;
            }

            return false;
        }

        public void RemoveAll(int _value)
        {
            var currentNode = head;
            while (currentNode != null)
            {
                var nextNode = currentNode.next;
                if (currentNode.value == _value)
                {
                    RemoveNode(currentNode);
                }
                currentNode = nextNode;
            }
        }

        public void Clear()
        {
            head = null;
            tail = null;
        }

        public int Count()
        {
            var currentNode = head;
            var count = 0;
            while (currentNode != null)
            {
                count++;
                currentNode = currentNode.next;
            }

            return count;
        }

        public void InsertAfter(Node _nodeAfter, Node _nodeToInsert)
        {
            if (_nodeAfter == null)
            {
                AddInHead(_nodeToInsert);
            }
            else if (_nodeAfter == tail)
            {
                AddInTail(_nodeToInsert);
            }
            else
            {
                AddInMiddle(_nodeAfter, _nodeToInsert);
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("[");

            var currentNode = head;

            while (currentNode != null)
            {
                var s = currentNode == tail ? currentNode.value.ToString() : currentNode.value.ToString() + ", ";
                sb.Append(s);
                currentNode = currentNode.next;
            }
            sb.Append("]");
            return sb.ToString();
        }

        public string ReverseToString()
        {
            var sb = new StringBuilder();
            sb.Append("[");

            var currentNode = tail;

            while (currentNode != null)
            {
                var s = currentNode == head ? currentNode.value.ToString() : currentNode.value.ToString() + ", ";
                sb.Append(s);
                currentNode = currentNode.prev;
            }
            sb.Append("]");
            return sb.ToString();
        }

        private bool RemoveNode(Node node)
        {
            if (node == head)
            {
                return RemoveHeadNode();
            }
            else if (node == tail)
            {
                return RemoveTailNode();
            }
            else
            {
                return RemoveMiddleNode(node);
            }
        }

        private bool RemoveMiddleNode(Node node)
        {
            if (node.prev == null || node.next == null)
            {
                return false;
            }

            var prev = node.prev;
            var next = node.next;

            prev.next = next;
            next.prev = prev;
            return true;
        }

        private bool RemoveHeadNode()
        {
            if (head == null)
            {
                return false;
            }

            if (head.next == null)
            {
                head = null;
                tail = null;
            }
            else
            {
                head.next.prev = null;
                head = head.next;
            }
            
            return true;
        }

        private bool RemoveTailNode()
        {
            if (tail == null)
            {
                return false;
            }

            if (tail.prev == null)
            {
                head = null;
                tail = null;
            }
            else
            {
                tail.prev.next = null;
                tail = tail.prev;
            }

            return true;
        }

        private void AddInHead(Node node)
        {
            if (head == null)
            {
                tail = node;
                tail.next = null;
                tail.prev = null;
            }
            else if (head != null)
            {
                head.prev = node;
                node.next = head;
                head = head.prev;
            }
            head = node;
        }

        private void AddInMiddle(Node _nodeAfter, Node _nodeToInsert)
        {
            if (_nodeAfter == null || _nodeAfter.next == null)
            {
                return;
            }

            var next = _nodeAfter.next;
            next.prev = _nodeToInsert;
            _nodeToInsert.next = next;
            _nodeToInsert.prev = _nodeAfter;
            _nodeAfter.next = _nodeToInsert;
        }
    }
}