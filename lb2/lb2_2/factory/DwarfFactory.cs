using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lb2_2.@interface;

namespace lb2_2.factory
{
    internal class DwarfFactory: IUnitFactory
    {
        public IWeapon CreateWeapon()
        {
            return new Musket();
        }
        public IMovement CreateMovement()
        {
            return new SlowMovement();
        }
    }
}
