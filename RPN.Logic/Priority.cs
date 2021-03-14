using System;
using System.Collections.Generic;
using System.Text;

namespace RPN.Logic
{
    public class Priority
    {
        private static string[] priorityOfFirst = { "+", "-" };
        public static string[] PriorityOfFirst { get { return priorityOfFirst; } }

        private static string[] priorityOfSecond = { "*", "/" };
        public static string[] PriorityOfSecond { get { return priorityOfSecond; } }

        private static string[] parenthesis = { "(", ")" };
        public static string[] Parenthesis { get { return parenthesis; } }

        private static string[] allOperations = { "+", "-", "*", "/" };
        public static string[] AllOperations { get { return allOperations; } }
    }
}
