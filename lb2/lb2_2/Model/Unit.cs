using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lb2_2.@interface;

namespace lb2_2.Model
{
    internal class Unit
    {
        public string TypeUnit { get; }
        private IWeapon weapon;
        private IMovement movement;
        public Unit(IUnitFactory factory)
        {
            weapon = factory.CreateWeapon();
            movement = factory.CreateMovement();
            TypeUnit = factory.GetType().Name.Replace("Factory", "");
        }
        public void Run()
        {
            movement.Move();
        }
        public void Hit()
        {
            weapon.Hit();
        }
    }
}
