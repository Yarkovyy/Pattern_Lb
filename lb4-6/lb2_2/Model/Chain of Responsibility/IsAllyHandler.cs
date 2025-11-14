using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lb2_2.@interface;

namespace lb2_2.Model.Chain_of_Responsibility
{
    internal class IsAllyHandler : ActionHandler
    {
        public ActionHandler? Successor { get; set; }
        public void Handle(ActionContext objAction)
        {
            int x = objAction.newX;
            int y = objAction.newY;
            Map map = Map.GetInstance();

            if (map[x, y] == objAction.ownerClan.GetLeader().Name)
            {
                  Console.WriteLine("Ви не можете атакувати свого лідера.");
            }
            else if (objAction.ownerClan.GetSquads().FirstOrDefault(s => s.X == x && s.Y == y) != null)
            {                
                Console.WriteLine("Ви не можете атакувати свій загін.");
            }
            else if (Successor != null)
            {
                Successor.Handle(objAction);
            }
        }
    }
}
