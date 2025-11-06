using lb2_2.factory;
using lb2_2.factory.Builder;
using lb2_2.@interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lb2_2.Model
{
    internal class Clan
    {
        private List<Squad> squads;
        private Map map;
        private Leader leader;
        public Clan(bool adInfo)
        {
            map = Map.GetInstance();
            squads = new List<Squad>();
            Random rand = new Random();
            int numberOfSquads = rand.Next(1, 4);

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
                    squads.Add(new Squad($"S{i}", builder.GetResult()));
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

            map.NewMap();
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

            leader = Leader.GetInstance(squads[leaderIndex].LeaderUnit());
            map.findEmptySpot(out x, out y);
            map[x, y] = "L";
            leader.X = x;
            leader.Y = y;
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
        public void ShowMap()
        {
            map.ShowMap();
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
    }
}
