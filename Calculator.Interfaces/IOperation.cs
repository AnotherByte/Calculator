using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calculator.Interfaces
{
    interface IOperation
    {
        int miPriority { get; }

        double mdFirst { set; }
        double mdSecond { set; }

        double calc();
    }
}
