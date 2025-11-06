using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lb2_2.Model
{
    internal class Map
    {
        private static Map instance;

        private string[,] map = new string[25, 25];
        public Map() { }

        public static Map GetInstance()
        {
            if (instance == null)
            {
                instance = new Map();
            }
            return instance;
        }
        public void NewMap()
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                    map[i, j] = ".";
            }
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
        public void findEmptySpot(out int x, out int y)
        {
            Random rand = new Random();
            x = rand.Next(map.GetLength(0));
            y = rand.Next(map.GetLength(1));
            bool b = true;
            while (b)
            {
                if (map[x, y] == ".")
                {
                    return;
                }
                x = rand.Next(map.GetLength(0));
                y = rand.Next(map.GetLength(1));
            }
        }
        public string this[int x, int y]
        {
            get => map[x, y];
            set => map[x, y] = value;
        }

    }
}
