using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedCalculate.WPF
{
    public class Resultes
    {
        public Resultes(int rezultX, int rezultY)
        {
            this.rezultX = rezultX;
            this.rezultY = rezultY;
        }
        public int rezultX { get; }
        public int rezultY { get; }
    }
}
