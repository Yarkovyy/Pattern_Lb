using lb2_2.factory;
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
        private string[,] map = new string[25,25];
        private Leader leader;
        public Clan()
        {
            squads = new List<Squad>();
            Random rand = new Random();
            int numberOfSquads = rand.Next(1, 4);
            for (int i = 0; i < numberOfSquads; i++)
            {
                squads.Add(new Squad($"S{i}"));
            }

            int ElfCount = rand.Next(1, 6);
            int DwarfCount = rand.Next(1, 6); 
            int HumanCount = rand.Next(1, 6); 

            for (int i = 0; i < squads.Count; i++)
            {
                for (int j = 0; j < ElfCount; j++)
                {
                    squads[i].AddUnit(new Unit(new ElfFactory()));
                }
                for (int j = 0; j < DwarfCount; j++)
                {
                    squads[i].AddUnit(new Unit(new DwarfFactory()));
                }                
                for (int j = 0; j < HumanCount; j++)
                {
                    squads[i].AddUnit(new Unit(new HumanFactory()));
                }
                
            }

            this.NewMap();
            //кординати генерація
            bool b;
            int x,y;
            for(int i=0; i < squads.Count; i++)
            {
                b=true;
                while (b)
                {
                    x= rand.Next(map.GetLength(0));
                    y = rand.Next(map.GetLength(1));
                    if (map[x,y] == ".")
                    {
                        b=false;
                        map[x,y]=squads[i].Name;
                        squads[i].X = x;
                        squads[i].Y = y;
                    }
                }
            }

            int leaderIndex = rand.Next(0, squads.Count);
            leader = Leader.GetInstance(squads[leaderIndex].LeaderUnit());

            b = true;
            while (b)
            {
                x = rand.Next(map.GetLength(0));
                y = rand.Next(map.GetLength(1));
                if (map[x, y] == ".")
                {
                    b = false;
                    map[x, y] = "L";
                    leader.X = x;
                    leader.Y = y;
                }
            }
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
            int rows = map.GetLength(0);
            int cols = map.GetLength(1);
            Console.WriteLine("--------------");
            // Верхній заголовок з номерами стовпців
            Console.Write("    ");
            for (int j = 0; j < cols; j++)
                Console.Write($"{j,3}"); 
            Console.WriteLine();

            // Основна сітка карти
            for (int i = 0; i < rows; i++)
            {
                Console.Write($"{i,3} "); 
                for (int j = 0; j < cols; j++)
                {                    
                    Console.Write($"{map[i, j],3}");
                }
                Console.WriteLine();
            }
            Console.WriteLine("--------------");
        }
        public void NewMap()
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                    map[i, j] = ".";
            }
        }

        public void ShowClan()
        {
            Console.WriteLine("Клан:");
            foreach (var squad in squads)
            {
                squad.ShowSquad();
            }
            Console.WriteLine($"Лідер: {leader.LeaderUnit.TypeUnit}");
        }

        //public void UpdateMap()
        //{
        //    for (int i = 0; i < map.GetLength(0); i++)
        //    {
        //        for (int j = 0; j < map.GetLength(1); j++)
        //            map[i, j] = ". ";
        //    }
        //}
    }
}
