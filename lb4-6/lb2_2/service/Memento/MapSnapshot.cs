using lb2_2.@interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lb2_2.Model;

namespace lb2_2.service.Memento
{
    internal class MapSnapshot:IMemento
    {
        private Map map;
        public string[,] mapArray;
        public MapSnapshot(Map map, string[,] newMap)
        {
            this.map = map;
            this.mapArray = newMap;
        }
        public void Restore()
        {
            map.Restore(this);
        }
    }
}
