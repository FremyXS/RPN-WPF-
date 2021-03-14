using System;
using System.Collections.Generic;
using System.Linq;

namespace RPN.Logic
{
    public class RPN
    {
        private static Queue<string> queue = new Queue<string>();
        private static Stack<string> stack = new Stack<string>();
        public static string[] GetPostfix(string function)
        {
            queue.Clear();

            Transform(function);

            return queue.ToArray();
        }
        private static void Transform(string function)
        {
            foreach (var i in function)
            {
                if (!Priority.AllOperations.Contains(i.ToString()) && !Priority.Parenthesis.Contains(i.ToString()))
                {
                    queue.Enqueue(i.ToString());
                }
                else if (Priority.AllOperations.Contains(i.ToString()))
                {
                    GetOperations(i.ToString());
                }
                else if (i.ToString() == "(")
                {
                    stack.Push(i.ToString());
                }
                else if (i.ToString() == ")")
                {
                    GetRightParenthesis();
                }
            }

            GetLastCharacters();
        }
        private static void GetOperations(string i)
        {

            if ((stack.Count() == 0 || stack.Peek() == "(") || (Priority.PriorityOfSecond.Contains(i.ToString()) && Priority.PriorityOfFirst.Contains(stack.Peek())))
            {
                stack.Push(i.ToString());
            }
            else if (Priority.PriorityOfFirst.Contains(i.ToString()) && (Priority.PriorityOfSecond.Contains(stack.Peek()) || Priority.PriorityOfFirst.Contains(stack.Peek())) || Priority.PriorityOfSecond.Contains(i.ToString()) && Priority.PriorityOfSecond.Contains(stack.Peek()))
            {
                do
                {
                    queue.Enqueue(stack.Pop());

                    if (stack.Count == 0)
                        break;

                } while (!Priority.PriorityOfFirst.Contains(stack.Peek()) || stack.Peek() != "(");

                stack.Push(i.ToString());
            }
        }
        private static void GetRightParenthesis()
        {
            do
            {
                queue.Enqueue(stack.Pop());

            } while (stack.Peek() != "(");

            if (stack.Peek() == "(")
                stack.Pop();
        }
        private static void GetLastCharacters()
        {
            while (stack.Count > 0)
                queue.Enqueue(stack.Pop());
        }

    }
}
