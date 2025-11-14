using lb2_2.@interface;
using lb2_2.Model;
using lb2_2.service.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lb2_2.service.Memento
{
    internal class ClanSnapshot:IMemento
    {
        private Clan Clan;
        public List<Squad> squads { get; }
        public Leader leader { get; }
        public bool strategy { get; }

        public ClanSnapshot(Clan clan, List<Squad> squads, Leader leader, bool strategy)
        {
            this.Clan = clan;
            this.squads = squads;
            this.leader = leader;
            this.strategy = strategy;
        }
        public void Restore()
        {
            Clan.Restore(this);
        }

    }
}
