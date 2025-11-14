using lb2_2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lb2_2.@interface
{
    interface IAction
    {
        public bool Attack(Squad enemySquad);
        public bool AttackLeader(Leader leader);
        public void Move(int x, int y);
        public void Stay();
        public int X { get; set; }
        public int Y { get; set; }
        public int Health();
    }
}
