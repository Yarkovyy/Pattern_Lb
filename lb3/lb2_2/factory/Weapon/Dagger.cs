using lb2_2.@interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lb2_2.factory.Weapon
{
    internal class Dagger: IWeapon
    {
        public void Hit()
        {
            Console.WriteLine("Удар кинжалом");
        }
    }
    
}
