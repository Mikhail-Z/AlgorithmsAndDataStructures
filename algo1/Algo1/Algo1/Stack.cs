using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmsDataStructuresStack
{
    public class Node<T>
    {
        public T value;
        public Node<T> next;

        public Node(T _value)
        {
            value = _value;
            next = null;
        }
    }

    public class Stack<T>
    {
        private Node<T> _head;
        private Node<T> _tail;
        private int _size;

        public Stack()
        {
            _head = null;
            _tail = null;
            _size = 0;
        }


        public int Size()
        {
            return _size;
        }

        public T Pop()
        {
            if (_head == null)
            {
                return default(T);
            }

            var value = _head.value;
            if (_head == _tail)
            {
                _tail = null;
            }
            _head = _head.next;

            _size--;
            return value;
        }

        public void Push(T val)
        {
            var newNode = new Node<T>(val);
            newNode.next = _head;
            _head = newNode;
            if (_tail == null)
            {
                _tail = _head;
            }

            _size++;
        }

        public T Peek()
        {
            if (_head == null)
            {
                return default(T);
            }

            return _head.value;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            var currentNode = _head;

            while (currentNode != null)
            {
                var s = currentNode == _tail ? currentNode.value.ToString() : currentNode.value.ToString() + ", ";
                sb.Append(s);
                currentNode = currentNode.next;
            }
            sb.Append("]");
            return sb.ToString();
        }
    }
}