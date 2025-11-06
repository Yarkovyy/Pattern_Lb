using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lb2_2.@nterface
{
    interface IUnit
    {
        public void Hit();
        public void Run();
        public int Health { get; set; }
        public string GetInfo();        
        public string TypeUnit { get; }
    }
}
