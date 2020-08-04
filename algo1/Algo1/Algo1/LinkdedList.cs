using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsDataStructuresLinkedList
{
    public class Node
    {   
        public int value;
        public Node next;
        public Node(int _value) { value = _value; }
    }

    public class LinkedList
    {
        public Node head;
        public Node tail;

        public LinkedList()
        {
            head = null;
            tail = null;
        }

        public void AddInTail(Node _item)
        {
            if (head == null) head = _item;
            else tail.next = _item;
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
            Node prevNode = null;
            while (currentNode != null)
            {
                if (currentNode.value == _value)
                {
                    return RemoveNodeBetween(prevNode, currentNode.next);
                }

                prevNode = currentNode;
                currentNode = currentNode.next;
            }

            return false;
        }

        public void RemoveAll(int _value)
        {
            var currentNode = head;
            Node prevNode = null;
            while (currentNode != null)
            {
                var nextNode = currentNode.next;
                if (currentNode.value == _value)
                {
                    RemoveNodeBetween(prevNode, currentNode.next);
                }
                else
                {
                    prevNode = currentNode;
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
            var currentNode = head;
            if (currentNode == null)
            {
                AddInTail(_nodeToInsert);
                return;
            }

            while (currentNode != null)
            {
                if (currentNode == _nodeAfter)
                {
                    var currentNextNode = currentNode.next;
                    _nodeToInsert.next = currentNextNode;
                    currentNode.next = _nodeToInsert;
                    if (currentNode == tail)
                    {
                        tail = _nodeToInsert;
                    }
                    return;
                }

                currentNode = currentNode.next;
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

        private bool RemoveNodeBetween(Node prevNode, Node nextNode)
        {
            if (prevNode == null)
            {
                return RemoveHeadNode();
            }
            else if (nextNode == null)
            {
                return RemoveTailNode();
            }

            prevNode.next = nextNode;
            return true;
        }

        private bool RemoveHeadNode()
        {
            if (head == null)
            {
                return false;
            }

            if (head == tail)
            {
                tail = null;
            }
            head = head.next;
            
            return true;
        }

        private bool RemoveTailNode()
        {
            if (tail == null || head == null)
            {
                return false;
            }
            else if (head == tail)
            {
                head = null;
                tail = null;
                return true;
            }
            else
            {
                var currentNode = head;
                while (currentNode.next != tail)
                {
                    currentNode = currentNode.next;
                }

                currentNode.next = null;
                tail = currentNode;

                return true;
            }
        }
    }
}