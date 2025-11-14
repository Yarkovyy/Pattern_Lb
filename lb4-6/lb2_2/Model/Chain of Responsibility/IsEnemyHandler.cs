using lb2_2.@interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lb2_2.Model.Chain_of_Responsibility
{
    internal class IsEnemyHandler:ActionHandler
    {
        public ActionHandler? Successor { get; set; }
        public void Handle(ActionContext objAction)
        {
            IAction objAct = objAction.objAct;
            int x = objAction.newX;
            int y = objAction.newY;
            Map map = Map.GetInstance();
            Leader enemyLeader = objAction.enemyClan.GetLeader();

            if (map[x, y] == enemyLeader.Name)
            {
                //Атакувати ворожого лідера
                if (objAct.AttackLeader(enemyLeader))
                {
                    map[enemyLeader.X, enemyLeader.Y] = ".";

                    Console.WriteLine("Лідер ворога загинув!");
                    Console.WriteLine("Ви перемогли у бою!");
                    objAction.enemyClan.RemoveLeader();
                }
                objAction.Result = true;  
            }
            else
            {
                Squad target = objAction.enemyClan.GetSquads().FirstOrDefault(s => s.X == x && s.Y == y);
                if (target == null)
                {
                    Console.WriteLine("Не вдалося знайти ворожий загін у цій клітинці.");                    
                }
                else if (objAct.Attack(target))
                {
                    map[target.X, target.Y] = ".";
                    objAction.enemyClan.GetSquads().Remove(target);

                }
                objAction.Result = true;
                Console.WriteLine($"Атака виконана по загону {target.Name} на ({x},{y}).");
            }
        }
    }
}
