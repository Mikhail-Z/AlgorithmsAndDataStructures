using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructuresDeque
{
    public class Deque<T>
    {
        private List<T> _list;

        public Deque()
        {
            _list = new List<T>();
        }

        public void AddFront(T item)
        {
            _list.Insert(0, item);
        }

        public void AddTail(T item)
        {
            _list.Add(item);
        }

        public T RemoveFront()
        {
            if (_list.Count == 0)
            {
                return default(T);
            }

            var firstItem = _list[0];
            _list.RemoveAt(0);
            return firstItem;
        }

        public T RemoveTail()
        {
            if (_list.Count == 0)
            {
                return default(T);
            }

            int lastIndex = _list.Count - 1;
            var lastItem = _list[lastIndex];
            _list.RemoveAt(lastIndex);
            return lastItem;
        }

        public int Size()
        {
            return _list.Count;
        }
    }
}