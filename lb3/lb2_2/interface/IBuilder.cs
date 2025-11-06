using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lb2_2.@interface
{
    interface IBuilder
    {
        public void Reset();
        public void AddElf();
        public void AddDwarf();
        public void AddHuman();
    }
}
