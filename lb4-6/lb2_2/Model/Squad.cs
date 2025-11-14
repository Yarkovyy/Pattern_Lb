using lb2_2.factory.Builder;
using lb2_2.@interface;
using lb2_2.nterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace lb2_2.Model
{
    internal class Squad: IAction
    {
        private List<IUnit> units;
        public string Name { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public Squad(string name, List<IUnit> units)
        {
            this.units = units;
            Name = name;
        }
        public Squad(string name, List<IUnit> units, int x, int y)
        {
            this.units = units;
            Name = name;
            X = x;
            Y = y;
        }
        public void AddUnit(Unit unit)
        {
            units.Add(unit);
        }
        public List<IUnit> GetUnits()
        {
            return units;
        }
        public void RemoveUnit(IUnit unit)
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
        public int Health()
        {
            int sum = 0;
            for (int i = 0; i < units.Count(); i++)
            {
                sum += units[i].Health;
            }
            return sum / units.Count();
        }
        public int CountAction()
        {
            int count = 0;
            for (int i = 0; i<units.Count(); i++)
            {
                count += units[i].Move();
            }
            return count/units.Count();
        }
        public bool Attack(Squad enemySquad)
        {
            WriteLine($"Загін {Name} атакує ворога!");
            for (int i = 0; i < units.Count; i++)
            {
                IUnit randomUnit = enemySquad.units[new Random().Next(enemySquad.units.Count)];
                randomUnit.Health = randomUnit.Health - units[i].Hit();
                if(randomUnit.Health <= 0)
                {
                    enemySquad.RemoveUnit(randomUnit);
                    WriteLine($"Ворог {randomUnit.TypeUnit} загинув!");
                    if (enemySquad.units.Count == 0)
                    {
                        WriteLine($"Загін {Name} переміг у бою!");
                        return true;
                    }
                }                
            }
            return false;
        }
        public bool AttackLeader(Leader leader)
        {             
            WriteLine($"Загін {Name} атакує лідера ворога!");
            foreach (var unit in units)
            {
                leader.leader.Health = leader.leader.Health - unit.Hit()/20;
                if (leader.leader.Health <= 0)
                {
                    WriteLine($"Лідер ворога {leader.Name} загинув!");
                    WriteLine($"Загін {Name} переміг у бою!");
                    return true;
                }
            }
            return false;
        }
        public void Move(int newX, int newY)
        {
            Map map = Map.GetInstance();
            map[X, Y] = ".";
            map[newX, newY] = Name;
            X = newX;
            Y = newY;
            WriteLine($"Загін {Name} перемістився до ({newX},{newY}).");
        }

        public Squad Clone()
        {

            List<IUnit> copyUnits = new List<IUnit>();
            foreach (var unit in units) 
            {
                copyUnits.Add(unit.Clone());
            }

            return new Squad(Name, copyUnits, X, Y);
        }
        public void Stay()
        {
            foreach (var unit in units)
            {
                unit.Stay();
            }
            WriteLine($"Загін {Name} відпочиває і відновлює здоров'я.");
        }
    }
}
