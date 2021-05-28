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

            DeleteInfinity();
        }
        private double Counting(double x)
        {
            Stack<double> Rezult = new();
            List<double> nums = new();

            foreach (var character in PostFix)
            {
                if (character is double || character.ToString() == "x" || character is int)
                {
                    Rezult.Push(character.ToString() == "x"? x : Convert.ToDouble(character));
                }
                else
                {
                    nums.Add(Rezult.Pop());
                    nums.Add(Rezult.Pop());

                    Rezult.Push(GetResult(nums, (string)character));
                }
            }

            return (double)Rezult.Pop();
        }
        private double GetResult(List<double> nums, string character)
        {
            return character switch
            {
                "+" => new Plus().Evaluate(nums),
                "-" => new Minus().Evaluate(nums),
                "*" => new Multiplication().Evaluate(nums),
                "/" => new Division().Evaluate(nums),
                "^" => new Degree().Evaluate(nums),
                _ => throw new Exception("Неккоректный оператор"),
            };
        }
        private void DeleteInfinity()
        {
            double zero = 0;
            if (AllResultes.ContainsKey(0))
            {
                if (AllResultes[0] == 1/zero)
                {
                    AllResultes.Remove(0);
                }
            }
        }
    }
}
