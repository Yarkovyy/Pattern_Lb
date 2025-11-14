using lb2_2.@interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lb2_2.Model.Chain_of_Responsibility
{
    internal class ActionContext
    {
        public IAction objAct;
        public Clan ownerClan;
        public Clan enemyClan;
        public int direction;
        public int newX, newY;
        public bool Result = false;

        public ActionContext() { }

        public ActionContext(IAction objAct, Clan ownerClan, Clan enemyClan, int direction)
        {
            this.objAct = objAct;
            this.ownerClan = ownerClan;
            this.enemyClan = enemyClan;
            this.direction = direction;
        }
    }
}
