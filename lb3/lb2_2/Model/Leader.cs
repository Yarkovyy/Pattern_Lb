using lb2_2.nterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lb2_2.Model
{
    internal class Leader
    {
        private static Leader instance;
        private IUnit leader;
        public int X { get; set; }
        public int Y { get; set; }
        public Leader(IUnit unit)
        {
            leader = unit;
            Random rand = new Random();
            X = rand.Next(0, 25);
            Y = rand.Next(0, 25);
        }

        public IUnit LeaderUnit
        {
            get
            {
                return leader;
            }
        }
        public static Leader GetInstance(IUnit unit)
        {
            if (instance == null)
            {
                instance = new Leader(unit);
            }
            return instance;
        }
        public string GetInfo()
        {
            return $"Leader Info: {leader.GetInfo()}";
        }
    }
}
