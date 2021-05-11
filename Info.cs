using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedCalculate.Logic
{
    public static class Info
    {        
        public static List<string> GetFunctionList(string function)
        {
            List<char> functionList = GetList(function);
            List<string> listFunction = new();
            string sybvol = "";

            for(var i = 0; i < functionList.Count; i++)
            {
                if (IsNumber(functionList[i], functionList))
                {
                    sybvol += functionList[i];
                }
                else
                {
                    listFunction.Add(sybvol);
                    listFunction.Add(functionList[i].ToString());
                    DeleteCharacters(ref functionList, ref i);
                    sybvol = "";
                }
            }

            listFunction.Add(sybvol);

            DeleteSpace(ref listFunction);

            return listFunction;
        }
        private static bool IsNumber(char character, List<char> function)
        {
            if (character >= '0' && character <= '9' || character == 'x')
            {
                return true;
            }
            else if (character == '-')
            {
                if (function.IndexOf(character) == 0)
                {
                    return true;
                }
                else if ((function[function.IndexOf(character) - 1] < '0'
                ||function[function.IndexOf(character) - 1] > '9')
                && function[function.IndexOf(character) - 1] != 'x')
                {
                    return true;
                }
            }

            return false;
                
        }
        private static void DeleteSpace(ref List<string> listFunction)
        {
            if (listFunction.Contains(""))
            {
                listFunction.Remove("");
                DeleteSpace(ref listFunction);
            }
        }
        private static List<char> GetList(string function)
        {
            List<char> functionList = new(); 
            foreach(var i in function)
            {
                functionList.Add(i);
            }

            return functionList;
        }
        private static void DeleteCharacters(ref List<char> function, ref int index)
        {
            for(var i = 0; i < index; i++)
            {
                function.RemoveAt(0);
            }

            index = 0;
        }
    }
}
