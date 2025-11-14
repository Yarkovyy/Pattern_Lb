using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lb2_2.@nterface
{
    interface IUnit
    {
        public int Hit();
        public int Move();
        public void Stay();
        public int Health { get; set; }
        public string GetInfo();        
        public string TypeUnit { get; }
        public IUnit Clone();
    }
}
