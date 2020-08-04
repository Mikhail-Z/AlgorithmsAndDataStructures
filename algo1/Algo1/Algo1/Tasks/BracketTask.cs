using System.Collections.Generic;

namespace AlgorithmsDataStructuresTasks
{
    public static class BracketTask
    {
        public static bool Solve(string inputString)
        {
            var stack = new Stack<char>();
            foreach (var bracket in inputString)
            {
                if (bracket == '(')
                {
                    stack.Push(bracket);
                }
                else
                {
                    if (stack.Pop() == default(char))
                    {
                        return false;
                    }
                }
            }

            if (stack.Count > 0)
            {
                return false;
            }

            return true;
        }
    }
}