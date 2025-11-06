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
        public int Health 
        { 
            get => unit.Health; 
            set => unit.Health = value;
        }
        public string TypeUnit 
        { 
            get => unit.TypeUnit;
        }
        public void Hit()
        {
            unit.Hit();
        }
        public void Run()
        {
            unit.Run();
        }
        public string GetInfo()
        {
            return $"Name: {Name}; Age: {Age}; Height: {Height} {unit.GetInfo()}";
        }
    }
}
