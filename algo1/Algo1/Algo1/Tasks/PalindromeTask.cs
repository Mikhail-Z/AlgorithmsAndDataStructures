using AlgorithmsDataStructuresDeque;

namespace AlgorithmsDataStructuresTasks
{
    public static class Palindrome
    {
        public static bool Check(string s)
        {
            var deque = new Deque<char>();
            for (int i = 0; i < s.Length; i++)
            {
                deque.AddTail(s[i]);
            }

            int equalItemsCount = deque.Size();
            while (deque.Size() > 1 && deque.RemoveFront() == deque.RemoveTail()) 
            {
                equalItemsCount--;
                equalItemsCount--;
            }
            if (equalItemsCount == deque.Size())
            {
                return true;
            }

            return false;
        }
    }
}