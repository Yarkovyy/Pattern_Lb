using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lb2_2.@interface;

namespace lb2_2.factory.Builder
{
    internal class Director
    {
        private IBuilder builder;
        public Director(IBuilder builder)
        {
            this.builder = builder;
        }
        public IBuilder Builder
        {
            set { builder = value; }
        }
        public void BuildNewListUnits(int elf, int human, int dwarf)
        {
            for(int i = 0; i < elf; i++)
            {
                builder.AddElf();
            }
            for (int i = 0; i < human; i++)
            {
                builder.AddHuman();
            }
            for (int i = 0; i < dwarf; i++)
            {
                builder.AddDwarf();
            }
        }
    }
}
