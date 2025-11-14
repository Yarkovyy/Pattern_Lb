using lb2_2.Model.Chain_of_Responsibility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lb2_2
{
    interface ActionHandler
    {
        public ActionHandler? Successor { get; set; }
        public void Handle(ActionContext actionContext);

    }
}
