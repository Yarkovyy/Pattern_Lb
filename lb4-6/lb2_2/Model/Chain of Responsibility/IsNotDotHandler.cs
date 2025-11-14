using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lb2_2.Model.Chain_of_Responsibility
{
    internal class IsNotDotHandler: ActionHandler
    {
        public ActionHandler? Successor { get; set; }
        public void Handle(ActionContext objAction)
        {
            int x = objAction.newX;
            int y = objAction.newY;
            Map map = Map.GetInstance();
            if (map[x, y] == ".")
            {
                Console.WriteLine("У цій клітинці немає загону для атаки.");
                objAction.Result = false;
            }
            else if (Successor != null)
            {                
                Successor.Handle(objAction);
            }
        }
    }
}
