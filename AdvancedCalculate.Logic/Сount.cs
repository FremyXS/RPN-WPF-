using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedCalculate.Logic
{
    public class Сount
    {
        private int Num { get; set; }
        public Сount(object num)
        {
            Num = (int)num;
        }
        public static Сount operator +(Сount numOne, Сount numTwo)
            => new Сount(numOne.Num + numTwo.Num);
        public static Сount operator -(Сount numOne, Сount numTwo)
            => new Сount(numOne.Num - numTwo.Num);
        public static Сount operator *(Сount numOne, Сount numTwo)
            => new Сount(numOne.Num * numTwo.Num);
        public static Сount operator /(Сount numOne, Сount numTwo)
            => new Сount(numOne.Num / numTwo.Num);
        public static Сount operator ^(Сount numOne, Сount numTwo) 
        {
            int numMuv = numOne.Num;

            for(var i = 0; i < numTwo.Num - 1; i++)
                numOne.Num *= numMuv;

            return new Сount(numOne.Num);
        }
        public override string ToString()
            => Num.ToString();
    }
}
