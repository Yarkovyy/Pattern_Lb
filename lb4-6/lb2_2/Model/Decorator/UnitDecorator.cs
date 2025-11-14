using lb2_2.@interface;
using lb2_2.nterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lb2_2.Model.Decorator
{
    internal class UnitDecorator: IUnit
    {
        IUnit unit;        
        public string Name { get; set; }
        public int Age { get; set; }
        public int Height { get; set; }
        public UnitDecorator(IUnit unit)
        {
            this.unit = unit;
            Random rand = new Random();
            Name = "Unit_" + rand.Next(9999);
            Age = rand.Next(18, 90);
            Height = rand.Next(120, 200);
        }
        public UnitDecorator(IUnit unit, string name, int age, int height, int health)
        {
            this.unit = unit;
            Name = name;
            Age = age;
            Height = height;
            Health = health;
        }

        public int Health 
        { 
            get => unit.Health; 
            set => unit.Health = value;
        }
        public string TypeUnit 
        { 
            get => unit.TypeUnit;
        }
        public int Hit()
        {
            return unit.Hit();
        }
        public int Move()
        {
            return unit.Move();
        }
        public void Stay()
        {
            unit.Stay();
        }
        public string GetInfo()
        {
            return $"Name: {Name}; Age: {Age}; Height: {Height} {unit.GetInfo()}";
        }
        public IUnit Clone()
        {
            return new UnitDecorator(unit.Clone(), Name, Age, Height, Health);
        }
    }
}
