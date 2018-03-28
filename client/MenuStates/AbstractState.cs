using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client.MenuStates
{
    public abstract class AbstractState
    {
        protected MainClientContext _context;

        public AbstractState(MainClientContext context)
        {
            _context = context; 
        }

        abstract public void StartMenu();
        abstract public void RunMenu(); 
        

        public void ShowMenu(String message)
        {
            Console.Clear();
            Console.WriteLine("{0,50}", message);

        }


    }
}
