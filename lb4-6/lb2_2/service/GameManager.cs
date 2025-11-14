using lb2_2.@interface;
using lb2_2.Model;
using lb2_2.service.Memento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lb2_2.service
{
    internal class GameManager
    {
        Clan clan1, clan2;
        Map map = Map.GetInstance();
        bool controlPointMode = false;
        HistoryStorage history;
        public GameManager(Clan clan1, Clan clan2, bool ControlPointMode)
        {
            this.clan1 = clan1;
            this.clan2 = clan2;
            controlPointMode = ControlPointMode;
            history = new HistoryStorage(clan1 , clan2);
        }

        public void StartGame()
        {
            map.ShowMap();
            while (clan1.CountSquad()>0 && clan2.CountSquad() > 0)
            {
                if (controlPointMode)
                {
                    Console.WriteLine("Зберегти гру (save); відкотити гру (restore)");
                    string choice = Console.ReadLine();
                    switch (choice.ToLower())
                    {
                        case "save":
                            {
                                //зберегти
                                history.MakeBackup();
                                break;
                            }
                        case "restore":
                            {
                                //відновити
                                history.Undo();
                                map.ShowMap();
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Збереження/відновлення було відхилено");
                                break;
                            }
                    }
                }

                Console.WriteLine("Новий раунд бою!");

                // клан1 робить хід проти клан2
                if(clan1.Play(clan2))
                {
                    Console.WriteLine("Клан 1 переміг у бою!");
                    break;
                }

                // клан2 робить хід проти клан1
                if(clan2.Play(clan1))
                {
                    Console.WriteLine("Клан 2 переміг у бою!");
                    break;
                }                 
            }
        }

    }
}
