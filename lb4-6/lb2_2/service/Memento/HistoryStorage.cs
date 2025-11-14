using lb2_2.@interface;
using lb2_2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lb2_2.Model;

namespace lb2_2.service.Memento
{
    internal class HistoryStorage
    {
        private List<IMemento> clan1Mementos = new List<IMemento>();
        private List<IMemento> clan2Mementos = new List<IMemento>();
        private List<IMemento> mapMementos = new List<IMemento>();
        private Clan clan1 = null;
        private Clan clan2 = null;
        private Map map = null;
        public HistoryStorage(Clan clan1, Clan clan2)
        {
            this.clan1 = clan1;
            this.clan2 = clan2;
            map = Map.GetInstance();
        }
        public void MakeBackup()
        {
            Console.WriteLine("Контрольну точку створено");
            clan1Mementos.Add(clan1.Save());
            clan2Mementos.Add(clan2.Save());
            mapMementos.Add(map.Save());
        }
        public void Undo()
        {
            if(clan1Mementos.Count() == 0 || clan2Mementos.Count() == 0 || mapMementos.Count() == 0)
            {
                Console.WriteLine("Контрольні точки відсутні");
                return;
            }
            var clan1M = clan1Mementos.Last();
            var clan2M = clan2Mementos.Last();
            var mapM = mapMementos.Last();

            clan1Mementos.Remove(clan1M);
            clan2Mementos.Remove(clan2M);
            mapMementos.Remove(mapM);

            try
            {
                clan1.Restore(clan1M);
                clan2.Restore(clan2M);
                map.Restore(mapM);
                Console.WriteLine("Контрольну точку відновлено");
            }
            catch (Exception ex)
            {
                this.Undo();
            }

        }

    }
}
