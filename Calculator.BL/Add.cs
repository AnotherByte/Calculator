using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calculator.BL
{
    class Add
    {
        private int miPriority;
        public int Priority
        {
            get { return miPriority; }
        }

        private double mdFirst;
        public double First
        {
            set { throw new NotImplementedException(); }
        }

        public double mdSecond
        {
            set { throw new NotImplementedException(); }
        }

        public double calc()
        {
            throw new NotImplementedException();
        }
    }
}
