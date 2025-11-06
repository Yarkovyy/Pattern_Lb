using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lb2_2.@interface;

namespace lb2_2.factory.Movement
{
    internal class MediumMovement:IMovement
    {
        public void Move()
        {
            Console.WriteLine("Рух зі середньою швидкістю");
        }
    }
    
}
