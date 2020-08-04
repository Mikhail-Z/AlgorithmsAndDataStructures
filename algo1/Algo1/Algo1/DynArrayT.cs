using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmsDataStructuresDynArray
{

    public class DynArray<T>
    {
        public T[] array;
        public int count;
        public int capacity;

        private const int MIN_CAPACITY = 16;
        private const int MAGNIFICATION_FACTOR = 2;
        private const double REDUCTION_FACTOR = 1.5;

        public DynArray()
        {
            count = 0;
            MakeArray(MIN_CAPACITY);
        }

        public void MakeArray(int new_capacity)
        {
            if (new_capacity < count || new_capacity <= 0)
            {
                throw new ArgumentException();
            }

            var actualNewCapaciity = new_capacity > MIN_CAPACITY ? new_capacity : MIN_CAPACITY;

            if (array != null)
            {
                var newArray = new T[actualNewCapaciity];
                Array.Copy(array, newArray, count);
                array = newArray;
            }
            else
            {
                array = new T[actualNewCapaciity];
            }
            
            capacity = actualNewCapaciity;
        }

        public T GetItem(int index)
        {
            if (index < 0 || index >= count)
            {
                throw new ArgumentOutOfRangeException();
            }

            return array[index];
        }

        public void Append(T itm)
        {
            Insert(itm, count);
        }

        public void Insert(T itm, int index)
        {
            if (index < 0 || index > count)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (count == capacity)
            {
                var newCapacity = capacity * MAGNIFICATION_FACTOR;
                MakeArray(newCapacity);
            }

            MoveItemsRight(index);
            array[index] = itm;
            count++;
        }

        public void Remove(int index)
        {
            if (index < 0 || index >= count)
            {
                throw new ArgumentOutOfRangeException();
            }

            MoveItemsLeft(index);
            count--;

            if (count * 2 < capacity)
            {
                int newCapacity = (int)(capacity / REDUCTION_FACTOR);
                MakeArray(newCapacity);
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("[");
            for (int i = 0; i < count; i++)
            {
                if (i == count - 1)
                {
                    sb.Append(array[i]);
                }
                else
                {
                    sb.Append(array[i] + ", ");
                }
            };
            sb.Append("]");
            return sb.ToString();
        }

        private void MoveItemsRight(int index)
        {
            for (int i = count; i > index; i--)
            {
                array[i] = array[i-1];
            }
            array[index] = default(T);
        }

        private void MoveItemsLeft(int index)
        {
            for (int i = index; i < count-1; i++)
            {
                array[i] = array[i+1];
            }

            array[count - 1] = default(T);
        }
    }
}