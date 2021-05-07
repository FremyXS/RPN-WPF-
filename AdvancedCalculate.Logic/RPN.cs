using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedCalculate.Logic
{
    public class RPN
    {
        private static string[] Operations { get; } = { "+", "-", "*", "/", "(", ")", "^" };
        private List<string> Function { get; set; } = new List<string>();
        public Queue<object> PostFix { get; private set; } = new Queue<object>();
        private Stack<string> Stack { get; set; } = new Stack<string>();
        public RPN(List<string> function)
        {
            Function = function;
            GetPostfix();
        }
        private void GetPostfix()
        {
            foreach(var character in Function)
            {
                if(!Operations.Contains(character))
                {
                    PostFix.Enqueue(character == "x" ? character : int.Parse(character));
                }
                else if (character == "(")
                {
                    Stack.Push(character);
                }
                else if (character == ")")
                {
                    while(Stack.Count != 0 )
                    {
                        if (Stack.Peek() == "(")
                        {
                            Stack.Pop();
                            break;
                        }
                        else
                        {
                            PostFix.Enqueue(Stack.Pop());
                        }
                    }
                }
                else if (IsOperator(character))
                {
                    if (Stack.Count == 0)
                    {
                        Stack.Push(character);
                    }
                    else
                    {
                        if(GetPrior(character) > GetPrior(Stack.Peek()))
                        {
                            Stack.Push(character);
                        }
                        else if((GetPrior(character) == GetPrior(Stack.Peek())) && (character == "^"))
                        {
                            Stack.Push(character);
                        }
                        else
                        {
                            while((Stack.Count != 0) && (GetPrior(character) <= GetPrior(Stack.Peek())))
                            {
                                PostFix.Enqueue(Stack.Pop());
                            }

                            Stack.Push(character);
                        }
                    }
                }

            }

            while(Stack.Count != 0)
            {
                PostFix.Enqueue(Stack.Pop());
            }
        }
        private bool IsOperator(string character)
        {
            if (character == "+" || character == "-" || character == "*" || character == "/" || character == "^")
                return true;
            else
                return false;
        }
        private int GetPrior(string character)
        {
            return character switch
            {
                "+" => new Minus().Priority,
                "-" => new Plus().Priority,
                "*" => new Multiplication().Priority,
                "/" => new Division().Priority,
                "^" => new Degree().Priority,
                _ => throw new Exception("Неккоректный символ"),
            };
        }    
    }
}
