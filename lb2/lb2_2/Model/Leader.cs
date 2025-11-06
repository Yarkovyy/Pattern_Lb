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
        private Unit leader;
        public int X { get; set; }
        public int Y { get; set; }
        public Leader(Unit unit)
        {
            leader = unit;
            Random rand = new Random();
            X = rand.Next(0, 25);
            Y = rand.Next(0, 25);
        }

        public Unit LeaderUnit
        {
            get
            {
                return leader;
            }
        }

        public static Leader GetInstance(Unit unit)
        {
            if (instance == null)
            {
                instance = new Leader(unit);
            }
            return instance;
        }
    }
}
