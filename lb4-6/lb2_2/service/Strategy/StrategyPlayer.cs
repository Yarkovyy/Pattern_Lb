using lb2_2.factory.Builder;
using lb2_2.@interface;
using lb2_2.Model;
using lb2_2.Model.Chain_of_Responsibility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace lb2_2.service.Strategy
{
    internal class StrategyPlayer : IStrategy
    {
        Clan ownerClan;
        ActionHandler attackChain;
        ActionHandler moveChain;

        public StrategyPlayer(Clan clan)
        {
            ownerClan = clan;

            moveChain = new BorderHandler();
            ActionHandler isDot = new IsDotHandler();
            moveChain.Successor = isDot;

            attackChain = new BorderHandler();
            ActionHandler isNotDot = new IsNotDotHandler();    
            ActionHandler isAllyHandler = new IsAllyHandler();
            ActionHandler isEnemyHandler = new IsEnemyHandler();
            attackChain.Successor = isNotDot;
            isNotDot.Successor = isAllyHandler;
            isAllyHandler.Successor = isEnemyHandler;
        }

        public bool Play(Clan enemyClan)
        {
            ActionContext context = new ActionContext();
            context.ownerClan = ownerClan;
            context.enemyClan = enemyClan;

            Map map = Map.GetInstance();
            List<Squad> mySquads = ownerClan.GetSquads();
            List<Squad> enemySquads = enemyClan.GetSquads();

            bool b = true;
            while (b)
            {
                try
                {
                    WriteLine("Доступні ваші загони:");
                    WriteLine($"0. Лідер {ownerClan.GetLeader().Name}");
                    for (int i = 0; i < mySquads.Count; i++)
                    {
                        WriteLine($"{i + 1}. Загін {mySquads[i].Name} ({mySquads[i].X},{mySquads[i].Y})");
                    }
                    WriteLine("Оберіть загон");

                    if (!int.TryParse(ReadLine(), out int choice) || choice < 0 || choice >= mySquads.Count + 1)
                    {
                        throw new Exception("Введено некоректне значення, спробуйте ще раз.");
                    }
                    if (choice == 0)
                    {
                        context.objAct = ownerClan.GetLeader();
                        int countAction = ownerClan.GetLeader().CountAction();
                        while (countAction > 0)
                        {
                            context.Result = false;
                            WriteLine($"Кількість доступних дій: {countAction}");
                            WriteLine("Оберіть дію: 1. Атакувати; 2. Стояти; 3. Рухатись");
                            string? action = ReadLine();
                            switch (action)
                            {
                                case "1":
                                    {
                                        WriteLine("Ви обрали атакувати");
                                        WriteLine("Оберіть напрямок атаки: вверх (1); вниз (2); вліво (3); вправо (4)");
                                        if (!int.TryParse(ReadLine(), out int dir) || dir < 1 || dir > 4)
                                        {
                                            WriteLine("Невірний напрямок, спробуйте ще раз.");
                                            break;
                                        }

                                        context.direction = dir;

                                        attackChain.Handle(context);

                                        if (context.Result)
                                            countAction--;
                                        break;
                                    }
                                case "2":
                                    {
                                        WriteLine("Ви обрали стояти");
                                        ownerClan.GetLeader().Stay();
                                        WriteLine("Відновлення/стояння виконано.");
                                        countAction--;
                                        break;
                                    }
                                case "3":
                                    {
                                        WriteLine("Ви обрали рухатись");
                                        WriteLine("Оберіть напрямок: вверх (1); вниз (2); вліво (3); вправо (4)");
                                        if (!int.TryParse(ReadLine(), out int direction) || direction < 1 || direction > 4)
                                        {
                                            WriteLine("Введено некоректне значення, спробуйте ще раз.");
                                        }

                                        context.direction = direction;

                                        moveChain.Handle(context);
                                        if (context.Result)
                                            countAction--;
                                        break;
                                    }
                                default:
                                    {
                                        WriteLine("Некоректна дія, спробуйте ще раз.");
                                        break; // не витрачаємо хід
                                    }
                            }
                            WriteLine("Оновлена карта:");
                            map.ShowMap();
                        }
                    }

                    else
                    {
                        choice -= 1; // Зміна вибору на індекс списку
                        context.objAct = mySquads[choice];
                        int countAction = mySquads[choice].CountAction();

                        while (countAction > 0)
                        {
                            context.Result = false;
                            WriteLine($"Кількість доступних дій: {countAction}");
                            WriteLine("Оберіть дію: 1. Атакувати; 2. Стояти; 3. Рухатись");
                            string? action = ReadLine();
                            switch (action)
                            {
                                case "1":
                                    {
                                        WriteLine("Ви обрали атакувати");
                                        WriteLine("Оберіть напрямок атаки: вверх (1); вниз (2); вліво (3); вправо (4)");
                                        if (!int.TryParse(ReadLine(), out int dir) || dir < 1 || dir > 4)
                                        {
                                            WriteLine("Невірний напрямок, спробуйте ще раз.");
                                            break;
                                        }

                                        context.direction = dir;

                                        attackChain.Handle(context);

                                        if (context.Result)
                                            countAction--;
                                        break;
                                    }
                                case "2":
                                    {
                                        WriteLine("Ви обрали стояти");
                                        mySquads[choice].Stay();
                                        WriteLine("Відновлення/стояння виконано.");
                                        countAction--;
                                        break;
                                    }
                                case "3":
                                    {
                                        WriteLine("Ви обрали рухатись");
                                        WriteLine("Оберіть напрямок: вверх (1); вниз (2); вліво (3); вправо (4)");
                                        if (!int.TryParse(ReadLine(), out int direction) || direction < 1 || direction > 4)
                                        {
                                            WriteLine("Введено некоректне значення, спробуйте ще раз.");
                                        }

                                        context.direction = direction;

                                        moveChain.Handle(context);
                                        if (context.Result)
                                            countAction--;
                                        break;
                                    }
                                default:
                                    {
                                        WriteLine("Некоректна дія, спробуйте ще раз.");
                                        break;
                                    }
                            }
                            Console.WriteLine("Оновлена карта:");
                            map.ShowMap();
                        }
                    }
                }
                catch (Exception ex)
                {
                    WriteLine(ex.Message);
                    continue;
                }
                b = false;
            }

            if(!enemyClan.HasLeader() || enemyClan.GetSquads().Count==0)
                return true;
            return false;
        }
    }
}
