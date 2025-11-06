using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lb2_2.@interface;
using lb2_2.nterface;

namespace lb2_2.Model
{
    internal class Unit: IUnit
    {
        public int Health { get; set; }
        public string TypeUnit { get; }
        private IWeapon weapon;
        private IMovement movement;
        public Unit(IUnitFactory factory)
        {
            weapon = factory.CreateWeapon();
            movement = factory.CreateMovement();
            TypeUnit = factory.GetType().Name.Replace("Factory", "");
            Health = factory.CreateHealth();
        }
        public void Run()
        {
            movement.Move();
        }
        public void Hit()
        {
            weapon.Hit();
        }
        public string GetInfo()
        {
            return $"Unit Type: {TypeUnit}, Health: {Health}, Weapon: {weapon.GetType().Name}, Movement: {movement.GetType().Name}";
        }
    }
}
