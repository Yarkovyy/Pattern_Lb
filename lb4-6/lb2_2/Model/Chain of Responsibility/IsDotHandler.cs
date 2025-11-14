using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lb2_2.@interface;

namespace lb2_2.Model.Chain_of_Responsibility
{
    internal class IsDotHandler:ActionHandler
    {
        public ActionHandler? Successor { get; set; }
        public void Handle(ActionContext objAction)
        {
            Map map = Map.GetInstance();
            int x = objAction.newX;
            int y = objAction.newY;
            if (map[x, y] == ".")
            {
                objAction.objAct.Move(x, y);
                objAction.Result = true;
            }
            else
            {
                Console.WriteLine("Клітинка зайнята, спробуйте інший напрямок.");
            }
        }

    }
}
