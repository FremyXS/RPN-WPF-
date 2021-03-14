using System;
using System.Collections.Generic;
using System.Text;

namespace RPN_WPF_.Models
{
    public class Rezultes
    {
        public Rezultes(string rezultX, string rezultY)
        {
            this.rezultX = rezultX;
            this.rezultY = rezultY;
        }
        public string rezultX { get; set; }
        public string rezultY { get; set; }
    }
}
