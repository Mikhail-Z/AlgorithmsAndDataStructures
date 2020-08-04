using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmsDataStructuresQueue
{
    public class Queue<T>
    {
        Stack<T> stack1;
        Stack<T> stack2;

        public Queue()
        {
            stack1 = new Stack<T>();
            stack2 = new Stack<T>();
        }

        public void Enqueue(T item)
        {
            stack1.Push(item);
        }

        public T Dequeue()
        {
            if (IsEmpty())
            {
                return default(T);
            }

            if (stack2.Count == 0)
            {
                MoveFirstStackToSecondStack();
            }

            return stack2.Pop();
        }

        public int Size()
        {
            return stack1.Count + stack2.Count;
        }

        public override string ToString()
        {
            Stack<T> tmpStack = new Stack<T>();
            foreach (var item in stack1)
            {
                tmpStack.Push(item);
            }

            var stringBuilder = new StringBuilder();
            stringBuilder.Append("[");
            foreach (var item in stack2)
            {
                stringBuilder.Append(item + " ");
            }

            foreach (var item in tmpStack)
            {
                stringBuilder.Append(item.ToString() + " ");
            }

            stringBuilder.Append("]");
            return stringBuilder.ToString();
        }

        private bool IsEmpty()
        {
            return Size() == 0;
        }

        private void MoveFirstStackToSecondStack()
        {
            while (stack1.Count != 0)
            {
                stack2.Push(stack1.Pop());
            }
        }
    }

    public static class QueueUtils
    {
        public static void Rotate(Queue<Object> queue, int n)
        {
            if (n < 0)
            {
                throw new ArgumentException();
            }

            for (int i = 0; i < n; i++)
            {
                queue.Enqueue(queue.Dequeue());
            }
        }
    }
}