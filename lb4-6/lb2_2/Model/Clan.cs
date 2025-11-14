using lb2_2.factory;
using lb2_2.factory.Builder;
using lb2_2.@interface;
using lb2_2.service.Memento;
using lb2_2.service.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lb2_2.service.Memento;

namespace lb2_2.Model
{
    internal class Clan
    {
        private List<Squad> squads;
        private Leader leader;
        private IStrategy strategy;
        public Clan(bool adInfo, bool strategy, char clanSymb)
        {
            if (strategy)
            {
                this.strategy = new StrategyPlayer(this);
            }
            else
            {
                this.strategy = new StrategyBot(this);
            }
            Map map = Map.GetInstance();
            squads = new List<Squad>();
            Random rand = new Random();
            int numberOfSquads = rand.Next(1, 6);

            int ElfCount, DwarfCount, HumanCount;
            if (adInfo)
            {
                ListUnitDecBuilder builder = new ListUnitDecBuilder();
                Director director = new Director(builder);
                for (int i = 0; i < numberOfSquads; i++)
                {
                    ElfCount = rand.Next(1, 6);
                    DwarfCount = rand.Next(1, 6);
                    HumanCount = rand.Next(1, 6);
                    director.BuildNewListUnits(ElfCount, HumanCount, DwarfCount);
                    squads.Add(new Squad($"{clanSymb}{i}", builder.GetResult()));
                }
            }
            else
            {
                ListUnitsBuilder builder = new ListUnitsBuilder();
                Director director = new Director(builder);
                for (int i = 0; i < numberOfSquads; i++)
                {
                    ElfCount = rand.Next(1, 6);
                    DwarfCount = rand.Next(1, 6);
                    HumanCount = rand.Next(1, 6);
                    director.BuildNewListUnits(ElfCount, HumanCount, DwarfCount);
                    squads.Add(new Squad($"S{i}", builder.GetResult()));
                }
            }
            //кординати генерація
            int x, y;
            for (int i = 0; i < squads.Count; i++)
            {
                map.findEmptySpot(out x, out y);
                map[x, y] = squads[i].Name;
                squads[i].X = x;
                squads[i].Y = y;
            }

            int leaderIndex = rand.Next(0, squads.Count);

            leader = new Leader(squads[leaderIndex].LeaderUnit(), clanSymb.ToString());      

            map.findEmptySpot(out x, out y);
            map[x, y] = leader.Name;
            leader.X = x;
            leader.Y = y;
        }

        public Clan(List<Squad> squads, Leader leader, IStrategy strategy)
        {
            this.squads = squads;
            this.leader = leader;
            this.strategy = strategy;
        }
        public void DisplayCordinates()
        {
            Console.WriteLine("Кординати загонів:");
            foreach (var squad in squads)
            {
                Console.WriteLine($"Загон {squad.Name}: ({squad.X}, {squad.Y})");
            }
            Console.WriteLine($"Лідер: ({leader.X}, {leader.Y})");
        }
        public void ShowClan()
        {
            Console.WriteLine("Клан:");
            foreach (var squad in squads)
            {
                squad.ShowSquad();
            }
            Console.WriteLine($"Лідер: {leader.GetInfo()}");
        }

        public bool Play(Clan enemyClan)
        {
            return strategy.Play(enemyClan);
        }

        public int CountSquad()
        {
            return squads.Count;
        }
        public List<Squad> GetSquads()
        {
            return squads;
        }
        public Leader GetLeader()
        {
            return leader;
        }
        public void RemoveLeader()
        {
            Map map = Map.GetInstance();
            if (leader != null)
            {
                map[leader.X, leader.Y] = ".";
                leader = null;
            }
        }
        public bool HasLeader()
        {
            return leader != null;
        }

        public ClanSnapshot Save()
        {
            bool strategyType;
            if (strategy.GetType() == typeof(StrategyBot))
                strategyType = false;
            else
                strategyType = true;

            List<Squad> copySquad = new List<Squad>();
            foreach (var squad in squads)
            {
                copySquad.Add(squad.Clone());
            }
                
            return new ClanSnapshot(this, copySquad, leader.Clone(), strategyType);
        }
        public void Restore(IMemento memento)
        {
            if (!(memento is ClanSnapshot))
            {
                throw new Exception("Unknown memento class " + memento.ToString());
            }
            
            leader = ((ClanSnapshot)memento).leader;
            squads = ((ClanSnapshot)memento).squads;
            if (((ClanSnapshot)memento).strategy)
                this.strategy = new StrategyPlayer(this);
            else
                this.strategy = new StrategyBot(this);}
    }
}
