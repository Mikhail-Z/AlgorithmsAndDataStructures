using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsDataStructuresLinkedList2
{
    public class LinkedList2WithDummyNodes
    {
        private Node _dummyHead;
        private Node _dummyTail;
        public Node Head
        {
            get
            {
                if (_dummyHead.next == _dummyTail)
                {
                    return null;
                }

                return _dummyHead.next;
            }
        }

        public Node Tail
        {
            get
            {
                if (_dummyTail.prev == _dummyHead)
                {
                    return null;
                }

                return _dummyTail.prev;
            }
        }

        public LinkedList2WithDummyNodes()
        {
            _dummyHead = new Node(0);
            _dummyTail = new Node(0);

            _dummyHead.next = _dummyTail;
            _dummyTail.prev = _dummyHead;
        }

        public void AddInTail(Node _item)
        {
            InsertAfter(_dummyTail.prev, _item);
        }

        public Node Find(int _value)
        {
            Node node = _dummyHead.next;
            while (node != _dummyTail)
            {
                if (node.value == _value) return node;
                node = node.next;
            }
            return null;
        }

        public List<Node> FindAll(int _value)
        {
            var foundNodes = new List<Node>();
            var currentNode = _dummyHead.next;
            while (currentNode != _dummyTail)
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
            var currentNode = _dummyHead.next;
            while (currentNode != _dummyTail)
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
            var currentNode = _dummyHead.next;
            while (currentNode != _dummyTail)
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
            _dummyHead.next = _dummyTail;
            _dummyTail.prev = _dummyHead;
        }

        public int Count()
        {
            var currentNode = _dummyHead.next;
            var count = 0;
            while (currentNode != _dummyTail)
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
                InsertAfterInternal(_dummyHead, _nodeToInsert);
            }

            InsertAfterInternal(_nodeAfter, _nodeToInsert);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("[");

            var currentNode = _dummyHead.next;

            while (currentNode != _dummyTail)
            {
                var s = currentNode == _dummyTail.prev ? currentNode.value.ToString() : currentNode.value.ToString() + ", ";
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

            var currentNode = _dummyTail.prev;

            while (currentNode != _dummyHead)
            {
                var s = currentNode == _dummyHead.next ? currentNode.value.ToString() : currentNode.value.ToString() + ", ";
                sb.Append(s);
                currentNode = currentNode.prev;
            }
            sb.Append("]");
            return sb.ToString();
        }

        private void InsertAfterInternal(Node _nodeAfter, Node _nodeToInsert)
        {
            if (_nodeAfter == null || _nodeAfter == _dummyTail)
            {
                return;
            }

            var next = _nodeAfter.next;
            next.prev = _nodeToInsert;
            _nodeToInsert.next = next;
            _nodeToInsert.prev = _nodeAfter;
            _nodeAfter.next = _nodeToInsert;
        }

        private bool RemoveNode(Node node)
        {
            if (node == _dummyHead || node == _dummyTail)
            {
                return false;
            }

            var prev = node.prev;
            var next = node.next;

            prev.next = next;
            next.prev = prev;
            return true;
        }
    }
}