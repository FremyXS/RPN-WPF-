using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace AdvancedCalculate.WPF
{
    public class Errors
    {        
        public static bool CheckFunction(string function)
        {
            if (!IsTrueCharacter(function) || !CheckNumberOfBraces(function))
                return false;

            return true;
        }
        private static bool IsTrueCharacter(string function)
        {
            foreach(var i in function)
            {
                if (!IsOperator(i))
                {
                    GetError(function, i);

                    return false;
                }
                else if(function.Contains('/') && function[function.IndexOf('/') + 1] == '0')
                {
                    GetError(function, i);

                    return false;
                }
            }

            return true;
        }
        private static bool IsOperator(char character)
        {
            if ((character == '+' || character == '-' || character == '*'
                || character == '/' || character == '^' || character == '(' 
                || character == ')') || (character >= '0' && character <= '9') || character == 'x')
                return true;
            else
                return false;
        }
        private static bool CheckNumberOfBraces(string function)
        {
            if(function.Count(e => e == ')') > function.Count(e => e == '('))
            {
                GetError(function, ')');
                return false;
            }
            else if (function.Count(e => e == ')') < function.Count(e => e == '('))
            {
                GetError(function, '(');
                return false;
            }
            else if(function.Count(e => e == ')') == function.Count(e => e == '('))
            {
                if (function.IndexOf('(') > function.IndexOf(')'))
                {
                    GetError(function, '(');
                    return false;
                }
                else if (function.IndexOf(')') == function.IndexOf('(') + 1)
                {
                    GetError(function, ')');
                    return false;
                }
            }
            return true;
        }
        private static void GetError(string function, char ind)
        {
            string error = function + "\n" + new string(' ', function.IndexOf(ind) + 2) + '^';
            MessageBox.Show(error);
        }

        public static bool IsStep(string value)
        {
            if(value.Length <= 0  || !IsNumber(value))
            {
                MessageBox.Show("Неккоректный ввод данных");
                return false;
            }

            return true;
        }
        private static bool IsNumber(string value)
        {
            foreach (var i in value)
            {
                if (i <'0' || i > '9')
                {
                    if (i != '-')
                    {
                        return false;
                    }
                }
            }

            return true;
        }
        public static bool CheckRange(string stepX, string startX, string endX)
        {
            if(int.Parse(stepX) > 0)
            {
                if(int.Parse(startX) >= int.Parse(endX))
                {
                    MessageBox.Show("Неккоректный ввод данных");
                    return false;
                }
            }
            else if(int.Parse(stepX) < 0)
            {
                if (int.Parse(startX) <= int.Parse(endX))
                {
                    MessageBox.Show("Неккоректный ввод данных");
                    return false;
                }
            }

            return true;
        }
    }
}
