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
    internal class ElfFactory: IUnitFactory
    {
        public IWeapon CreateWeapon()
        {
            return new Dagger();
        }
        public IMovement CreateMovement()
        {
            return new FastMovement();
        }
        public int CreateHealth()
        {
            return Random.Shared.Next(75, 130);
        }
    }
}
