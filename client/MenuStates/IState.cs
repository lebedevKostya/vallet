using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client.Menu.states
{
    public abstract class IState
    {
        protected MainClientContext _context;

        public IState(MainClientContext context)
        {
            _context = context; 
        }

        abstract public void RunMenu();  

        public void ShowMenu(String message)
        {
            Console.Clear();
            Console.WriteLine("{0,50}", message);

        }


    }
}
