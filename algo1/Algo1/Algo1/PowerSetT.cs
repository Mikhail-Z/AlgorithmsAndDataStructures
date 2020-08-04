using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructuresPowerSet
{

    // наследуйте этот класс от HashTable
    // или расширьте его методами из HashTable
    public class PowerSet<T>
    {
        private List<T> _values;

        public PowerSet()
        {
            _values = new List<T>();
        }

        public int Size()
        {
            // количество элементов в множестве
            return _values.Count;
        }

        public void Put(T value)
        {
            if (_values.Contains(value) == false)
            {
                _values.Add(value);
            }
        }

        public bool Get(T value)
        {
            // возвращает true если value имеется в множестве,
            // иначе false
            return _values.Contains(value);
        }

        public bool Remove(T value)
        {
            // возвращает true если value удалено
            // иначе false
            return _values.Remove(value);
        }

        public PowerSet<T> Intersection(PowerSet<T> set2)
        {
            // пересечение текущего множества и set2
            var intersection = new PowerSet<T>();
            foreach (var value in _values)
            {
                if (set2.Get(value))
                {
                    intersection.Put(value);
                }
            }

            return intersection;
        }

        public PowerSet<T> Union(PowerSet<T> set2)
        {
            // объединение текущего множества и set2
            var union = new PowerSet<T>();
            foreach (var value in _values)
            {
                union.Put(value);
            }

            foreach (var value2 in set2.GetValues())
            {
                union.Put(value2);
            }

            return union;
        }

        public PowerSet<T> Difference(PowerSet<T> set2)
        {
            // разница текущего множества и set2
            var difference = new PowerSet<T>();
            foreach (var value in this.GetValues())
            {
                difference.Put(value);
            }
            foreach (var value2 in set2.GetValues())
            {
                difference.Remove(value2);
            }
            return difference;
        }

        public bool IsSubset(PowerSet<T> set2)
        {
            // возвращает true, если set2 есть
            // подмножество текущего множества,
            // иначе false
            foreach (var value2 in set2.GetValues())
            {
                if (_values.Contains(value2) == false)
                {
                    return false;
                }
            }
            return true; ;
        }

        public List<T> GetValues()
        {
            return _values;
        }
    }
    
}