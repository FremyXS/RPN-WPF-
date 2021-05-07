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
        public static Dictionary<double, double> AllResultes { get; } = new Dictionary<double, double>();
        public Calculate(object[] postfix, double start, double end, double step)
        {
            PostFix = postfix;
            AllResultes.Clear();

            GetRezultes(start, end, step);
        }
        private void GetRezultes(double start, double end, double step)
        {
            for(var i = start; i <= end; Math.Round(i += step, 2))
            {
                AllResultes.Add( Math.Round(i, 2), Counting(i));
            }            
        }
        private double Counting(double x)
        {
             Stack<double> Rezult = new();
             double numOne, numTwo;

            foreach (var character in PostFix)
            {
                if (character is double || character.ToString() == "x" || character is int)
                {
                    Rezult.Push(character.ToString() == "x"? x : Convert.ToDouble(character));
                }
                else
                {
                    numTwo = Rezult.Pop();
                    numOne = Rezult.Pop();

                    Rezult.Push(GetResult(numOne, numTwo, (string)character));
                }
            }

            return (double)Rezult.Pop();
        }
        private double GetResult(double numOne, double numTwo, string character)
        {
            return character switch
            {
                "+" => new Plus().Evaluate(numOne, numTwo),
                "-" => new Minus().Evaluate(numOne, numTwo),
                "*" => new Multiplication().Evaluate(numOne, numTwo),
                "/" => new Division().Evaluate(numOne, numTwo),
                "^" => new Degree().Evaluate(numOne, numTwo),
                _ => throw new Exception("Неккоректный оператор"),
            };
        }
    }
}
