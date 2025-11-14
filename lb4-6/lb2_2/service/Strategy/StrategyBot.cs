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
    internal class StrategyBot : IStrategy
    {
        Clan ownerClan;
        ActionHandler attackChain;
        ActionHandler moveChain;

        public StrategyBot(Clan clan)
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
                    Random random = new Random();
                    int choice = random.Next(0, ownerClan.CountSquad() + 1);
                    if (choice == 0)
                    {
                        WriteLine("Ви обрали лідера");

                        context.objAct = ownerClan.GetLeader();
                        int countAction = ownerClan.GetLeader().CountAction();
                        while (countAction > 0)
                        {
                            context.Result = false;
                            //Пошук ворога
                            int enemyDir = FindEnemyDirection(enemyClan, context.objAct.X, context.objAct.Y);
                            if (enemyDir != 0)
                            {
                                context.direction = enemyDir;
                                attackChain.Handle(context);
                                if (context.Result)
                                    countAction--;
                            }
                            else if (context.objAct.Health() < 50)
                            {
                                context.objAct.Stay();
                                countAction--;
                            }
                            else
                            {
                                context.direction = random.Next(1, 4);
                                moveChain.Handle(context);
                                if (context.Result)
                                    countAction--;
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
                            //Пошук ворога
                            int enemyDir = FindEnemyDirection(enemyClan, context.objAct.X, context.objAct.Y);
                            if (enemyDir != 0)
                            {
                                context.direction = enemyDir;
                                attackChain.Handle(context);
                                if (context.Result)
                                    countAction--;
                            }
                            else if (context.objAct.Health() < 50)
                            {
                                context.objAct.Stay();
                                countAction--;
                            }
                            else
                            {
                                context.direction = random.Next(1, 4);
                                moveChain.Handle(context);
                                if (context.Result)
                                    countAction--;
                            }
                            WriteLine("Оновлена карта:");
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
            if (!enemyClan.HasLeader() || enemyClan.GetSquads().Count == 0)
                return true;
            return false;
        }


        private int FindEnemyDirection(Clan enemyClan, int x, int y)
        {
            // directions: 1 = up, 2 = down, 3 = left, 4 = right, 0 = none
            Leader enemyLeader = enemyClan.GetLeader();

            // up
            int nx = x - 1, ny = y;
            if (nx >= 0)
            {
                if (enemyLeader != null && enemyLeader.X == nx && enemyLeader.Y == ny)
                    return 1;
                if (enemyClan.GetSquads().Any(s => s.X == nx && s.Y == ny))
                    return 1;
            }

            // down
            nx = x + 1; ny = y;
            if (nx <= 24)
            {
                if (enemyLeader != null && enemyLeader.X == nx && enemyLeader.Y == ny)
                    return 2;
                if (enemyClan.GetSquads().Any(s => s.X == nx && s.Y == ny))
                    return 2;
            }

            // left
            nx = x; ny = y - 1;
            if (ny >= 0)
            {
                if (enemyLeader != null && enemyLeader.X == nx && enemyLeader.Y == ny)
                    return 3;
                if (enemyClan.GetSquads().Any(s => s.X == nx && s.Y == ny))
                    return 3;
            }

            // right
            nx = x; ny = y + 1;
            if (ny <= 24)
            {
                if (enemyLeader != null && enemyLeader.X == nx && enemyLeader.Y == ny)
                    return 4;
                if (enemyClan.GetSquads().Any(s => s.X == nx && s.Y == ny))
                    return 4;
            }

            return 0;
        }
    }
}
