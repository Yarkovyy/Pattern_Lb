using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lb2_2.@interface;
using lb2_2.factory.Weapon;
using lb2_2.factory.Movement;

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
        public int CreateHealth()
        {
            return Random.Shared.Next(130, 200);
        }
    }
}
