using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    internal interface ICalculator
    {
        public double Add(double a, double b);
        public double Subtract(double a, double b);
        public double Multiply(double a, double b);
        public double Divide(double a, double b);
    }
}
