using lb2_2.nterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lb2_2.Model
{
    internal class Squad
    {
        private List<IUnit> units;
        public string Name { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public Squad(string name, List<IUnit> units)
        {
            this.units = units;
            //Random rand = new Random();
            //X = rand.Next(0, 25);
            //Y = rand.Next(0, 25);
            Name = name;
        }
        public void AddUnit(Unit unit)
        {
            units.Add(unit);
        }
        public void RemoveUnit(Unit unit)
        {
            units.Remove(unit);
        }
        public IUnit LeaderUnit()
        {
            Random rand = new Random();
            IUnit leader = units[rand.Next(units.Count)];
            units.Remove(leader);
            return leader;
        }
        public void ShowSquad()
        {
            Console.WriteLine($"Squad {Name}:");
            foreach (var unit in units)
            {
                Console.WriteLine($"- {unit.GetInfo()}");
            }
        }
    }
}
