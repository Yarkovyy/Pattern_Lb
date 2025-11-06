using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lb2_2.factory.Weapon;
using lb2_2.factory.Movement;
using lb2_2.@interface;


namespace lb2_2.factory
{
    internal class HumanFactory: IUnitFactory
    {
        public IWeapon CreateWeapon()
        {
            return new Sword();
        }
        public IMovement CreateMovement()
        {
            return new MediumMovement();
        }
        public int CreateHealth()
        {
            return Random.Shared.Next(100, 150);
        }
    }
}
