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
    internal class Leader : IAction
    {
        //private static Leader instance;
        public IUnit leader { get; set; }
        public string Name { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public Leader(IUnit unit, string name)
        {
            leader = unit;
            Random rand = new Random();
            Name = name;
            //X = rand.Next(0, 25);
            //Y = rand.Next(0, 25);
        }
        public Leader(Leader leader)
        {
            this.leader = leader.leader.Clone();
            Name = leader.Name;
            X = leader.X;
            Y = leader.Y;
        }

        //public IUnit LeaderUnit
        //{
        //    get
        //    {
        //        return leader;
        //    }
        //}
        //public static Leader GetInstance(IUnit unit)
        //{
        //    if (instance == null)
        //    {
        //        instance = new Leader(unit);
        //    }
        //    return instance;
        //}
        public string GetInfo()
        {
            return $"Leader Info: {leader.GetInfo()}";
        }
        public int CountAction()
        {           
            return leader.Move();
        }
        public int Health()
        {
            return leader.Health; 
        }

        public bool Attack(Squad enemySquad)
        {
            WriteLine($"Лідер {Name} атакує ворога!");
            List<IUnit> units = enemySquad.GetUnits();
            List <IUnit> deadUnits = new List<IUnit>();
            for (int i = 0; i < units.Count; i++)
            {
                units[i].Health -= leader.Hit();  
                if(units[i].Health <= 0)
                {
                    WriteLine($"Ворог {units[i].TypeUnit} загинув!");
                    deadUnits.Add(units[i]);
                }
            }

            foreach (var deadUnit in deadUnits)
            {
                enemySquad.RemoveUnit(deadUnit);
            }
            if (enemySquad.GetUnits().Count == 0)
            {
                WriteLine($"Лідер {Name} переміг у бою!");
                return true;
            }     
            return false;
        }

        public bool AttackLeader(Leader enemyLeader)
        {
            WriteLine($"Лідер {Name} атакує лідера ворога!");

                enemyLeader.leader.Health = enemyLeader.leader.Health - leader.Hit();
                if (enemyLeader.leader.Health <= 0)
                {
                    WriteLine($"Лідер ворога {enemyLeader.Name} загинув!");
                    WriteLine($"Лідер {Name} переміг у бою!");
                    return true;
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
        public void Stay()
        {
            leader.Stay();
        }

        public Leader Clone()
        {
            return new Leader(this);
        }
    }
}
