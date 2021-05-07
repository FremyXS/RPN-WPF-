using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedCalculate.WPF
{
    public class Resultes
    {
        public Resultes(double rezultX, double rezultY)
        {
            this.RezultX = rezultX;
            this.RezultY = rezultY;
        }
        public double RezultX { get; }
        public double RezultY { get; }
    }
}
