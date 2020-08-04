using System;
using System.Collections.Generic;
using System.Text;

//Вопрос: Оцените сложность операции поиска, изменилась ли она?
//Ответ: Нет, не изменилась, так как в основе упорядоченного списка все тот же двунаправленный список, допускающий только последовательный доступ, поэтому поиск, добавление, удаление элемента выполняется так же за O(n)
namespace AlgorithmsDataStructuresOrderedList
{
    public class Node<T>
    {
        public T value;
        public Node<T> next, prev;

        public Node(T _value)
        {
            value = _value;
            next = null;
            prev = null;
        }
    }

    public class OrderedList<T>
    {
        public Node<T> head, tail;
        private bool _ascending;

        public OrderedList(bool asc)
        {
            head = null;
            tail = null;
            _ascending = asc;
        }

        public int Compare(T v1, T v2)
        {
            int result = 0;
            if (typeof(T) == typeof(String))
            {
                return ((string)(object)v1).Trim().CompareTo(((string)(object)v2).Trim());
            }

            if (v1 is IComparable && v2 is IComparable)
            {
                var v1comp = (IComparable)v1;
                var v2comp = (IComparable)v2;
                return v1comp.CompareTo(v2comp);
            }
            return result;
        }

        public void Add(T value)
        {
            var curNode = head;
            if (curNode == null)
            {
                head = tail = new Node<T>(value);
                return;
            }

            while (curNode != null 
                && (Compare(curNode.value, value) == -1 && _ascending 
                    || Compare(curNode.value, value) == 1 && !_ascending))
            {
                curNode = curNode.next;
            }

            if (curNode == head)
            {
                var newNode = new Node<T>(value);
                newNode.next = curNode;
                curNode.prev = newNode;

                head = newNode;
            }
            else if (curNode == null)
            {
                var newNode = new Node<T>(value);
                newNode.prev = tail;
                tail.next = newNode;

                tail = tail.next;
            }
            else
            {
                var newNode = new Node<T>(value);
                newNode.next = curNode;
                newNode.prev = curNode.prev;
                curNode.prev.next = newNode;
                curNode.prev = newNode;
            }
        }

        public Node<T> Find(T val)
        {
            Node<T> curNode = null;
            do
            {
                if (curNode == null)
                {
                    curNode = head;
                }
                else
                {
                    curNode = curNode.next;
                }
            }
            while (curNode != null && Compare(curNode.value, val) != 0);

            return curNode;
        }

        public void Delete(T val)
        {
            var node = Find(val);

            if (node == null)
            {
                return;
            }

            if (node == head)
            {
                if (head.next == null)
                {
                    head = tail = null;
                    return;
                }

                head.next.prev = null;
                head = head.next;
            }
            else if (node == tail)
            {
                tail.prev.next = null;
                tail = tail.prev;
            }
            else
            {
                var prevNode = node.prev;
                var nextNode = node.next;
                prevNode.next = nextNode;
                nextNode.prev = prevNode;   
            }
        }

        public void Clear(bool asc)
        {
            _ascending = asc;
            head = null;
            tail = null;
        }

        public int Count()
        {
            int count = 0;
            Node<T> node = head;
            while (node != null)
            {
                node = node.next;
                count++;
            }

            return count;
        }

        public string ToString()
        {
            Node<T> node = head;
            var sb = new StringBuilder();
            sb.Append("[");
            while (node != null)
            {
                if (node.next == null)
                {
                    sb.Append(node.value + "]");
                }
                else
                {
                    sb.Append(node.value + ", ");
                }
                node = node.next;
            }

            return sb.ToString();
        }
    }
}