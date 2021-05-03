using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedCalculate.Logic
{
    public class Calculate
    {
        private object[] PostFix { get; set; }
        public static Dictionary<int, int> AllResultes { get; } = new Dictionary<int, int>();
        public static List<int> allRes { get; } = new List<int>();
        public static List<int> allX { get; } = new List<int>();
        public Calculate(object[] postfix, int start, int end, int step)
        {
            PostFix = postfix;
            AllResultes.Clear();

            GetRezultes(start, end, step);
        }
        private void GetRezultes(int start, int end, int step)
        {
            for(var i = start; i <= end; i += step)
            {
                AllResultes.Add(i, Counting(i));
                allRes.Add(Counting(i));
                allX.Add(i);
            }            
        }
        private int Counting(int x)
        {
             Stack<object> Rezult = new Stack<object>();
             Сount numOne, numTwo;

            foreach (var character in PostFix)
            {
                if (character is int || (string)character == "x")
                {
                    Rezult.Push(character.ToString() == "x"? x : character);
                }
                else
                {
                    numTwo = new Сount(Rezult.Pop());
                    numOne = new Сount(Rezult.Pop());

                    Rezult.Push(int.Parse(GetResult(numOne, numTwo, (string)character)));
                }
            }

            return (int)Rezult.Pop();
        }
        private string GetResult(Сount numOne, Сount numTwo, string character)
        {
            switch (character)
            {
                case "+":
                    return (numOne + numTwo).ToString();
                case "-":
                    return (numOne - numTwo).ToString();
                case "*":
                    return (numOne * numTwo).ToString();
                case "/":
                    return (numOne / numTwo).ToString();
                case "^":
                    return (numOne ^ numTwo).ToString();
                default:
                    return "";
            }
        }
    }
}
