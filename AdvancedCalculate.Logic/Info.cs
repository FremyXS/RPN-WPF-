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
            List<string> listFunction = new List<string>();
            string sybvol = "";
            foreach (var character in function)
            {
                if (IsNumber(character))
                {
                    sybvol += character;
                }
                else
                {
                    listFunction.Add(sybvol);
                    listFunction.Add(character.ToString());
                    sybvol = "";
                }
            }

            listFunction.Add(sybvol);

            DeleteSpace(ref listFunction);

            return listFunction;
        }
        private static bool IsNumber(char character)
        {
            if (character >= '0' && character <= '9' || character == 'x') 
                return true;
            else 
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
    }
}
