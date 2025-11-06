using lb2_2.@interface;
using lb2_2.Model;
using lb2_2.Model.Decorator;
using lb2_2.nterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace lb2_2.factory.Builder
{
    internal class ListUnitDecBuilder:IBuilder
    {
        private List<IUnit> units = new List<IUnit>();
        public void Reset()
        {
            units = new List<IUnit>();
        }
        public void AddElf()
        {
            units.Add(new UnitDecorator(new Unit(new ElfFactory())));
        }
        public void AddDwarf()
        {
            units.Add(new UnitDecorator(new Unit(new DwarfFactory())));
        }
        public void AddHuman()
        {
            units.Add(new UnitDecorator(new Unit(new HumanFactory())));
        }
        public List<IUnit> GetResult()
        {
            List<IUnit> returnUnits = units;
            this.Reset();
            return returnUnits;
        }
    }
}
