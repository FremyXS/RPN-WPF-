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
            return true;
        }
        private static void GetError(string function, char ind)
        {
            string error = function + "\n" + new string(' ', function.IndexOf(ind) + 1) + '^';
            MessageBox.Show(error);
        }

        public static bool IsStep(string value)
        {
            if((value.Length <= 0 ))
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
                if (i < '0' || i > '9')
                {
                    return false;
                }
            }

            return true;
        }
    }
}
