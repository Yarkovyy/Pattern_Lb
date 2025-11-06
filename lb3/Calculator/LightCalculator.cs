using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    internal class LightCalculator:ICalculator
    {
        ICalculator fullCalculator = new FullCalculator();
        public LightCalculator(ICalculator calculator) 
        {
            fullCalculator = calculator;
        }
        public double Add(double a, double b)
        {
            if (a == 0) return b;
            if (b == 0) return a;
            return fullCalculator.Add(a, b);
        }
        public double Subtract(double a, double b)
        {
            if (a == 0) return -b;
            if (b == 0) return a;
            return fullCalculator.Subtract(a, b);
        }
        public double Multiply(double a, double b)
        {
            if(a==0||b==0) return 0;
            return fullCalculator.Multiply(a,b);
        }
        public double Divide(double a, double b)
        {
            if(a==0||b!=0) return 0;
            if(b==0) throw new DivideByZeroException();
            return fullCalculator.Divide(a,b);
        }
    }
}
