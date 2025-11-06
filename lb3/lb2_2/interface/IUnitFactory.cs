using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lb2_2.@interface
{
    internal interface IUnitFactory
    {
        public IWeapon CreateWeapon();
        public IMovement CreateMovement();
        public int CreateHealth();
    }
}
