using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client.MenuStates
{
    class CloseBillMenu : AbstractState
    {
        public CloseBillMenu(MainClientContext context) : base(context)
        {
            _context = context;
        }

        public override void RunMenu()
        {
            throw new NotImplementedException();
        }

        public override void StartMenu()
        {
            throw new NotImplementedException();
        }
    }
}
