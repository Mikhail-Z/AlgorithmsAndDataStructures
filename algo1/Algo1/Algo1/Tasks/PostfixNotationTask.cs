using System;
using AlgorithmsDataStructuresStack;

namespace AlgorithmsDataStructuresTasks
{
    public static class PostfixNotationTask
    {
        public static double Solve(string postfixExpression)
        {
            Stack<int> _numbers = new Stack<int>();
            var tokens = postfixExpression.Split();
            foreach (var token in tokens)
            {
                int number;
                if (Int32.TryParse(token, out number))
                {
                    _numbers.Push(number);
                }
                else
                {
                    if (token == "=")
                    {
                        break;
                    }

                    var value2 = _numbers.Pop();
                    var value1 = _numbers.Pop();
                    var currentResult = CalculateExpression(value1, value2, token);
                    _numbers.Push(currentResult);
                }
            }
            return _numbers.Pop();
        }

        private static int CalculateExpression(int value1, int value2, string operation)
        {
            if (operation == "+")
            {
                return value1 + value2;
            }
            else if (operation == "*")
            {
                return value1 * value2;
            }
            else if (operation == "-")
            {
                return value1 - value2;
            }
            else
            {
                throw new ArgumentException();
            }
        }

    }
}