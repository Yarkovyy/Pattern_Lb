using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lb2_2.@interface;

namespace lb2_2.Model.Chain_of_Responsibility
{
    internal class BorderHandler : ActionHandler
    {
        public ActionHandler? Successor { get; set; }
        public void Handle(ActionContext objAction)
        {
            int dir = objAction.direction;
            int x = objAction.objAct.X;
            int y = objAction.objAct.Y;
            switch (dir)
            {
                case 1:
                    {
                        x -= 1;
                        break; // вверх
                    }
                case 2:
                    {
                        x += 1;
                        break; // вниз
                    }
                case 3:
                    {
                        y -= 1;
                        break; // вліво
                    }
                case 4:
                    {
                        y += 1;
                        break; // вправо
                    }
            }


            if (x < 0 || x > 24 || y < 0 || y > 24)
            {
                Console.WriteLine("Рух/атака у цьому напрямку неможливий (вихід за межі).");
            }
            else
            {
                if (Successor != null)
                {
                    objAction.newX = x;
                    objAction.newY = y;
                    Successor.Handle(objAction);
                }
            }
        }
    }
}
