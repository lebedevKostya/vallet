using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client.Menu
{
    abstract class AbstractMenu <T>
    {

        abstract public void RunMenu();
        abstract public T GetInput();

        public void ShowMenu(String message)
        {
          Console.WriteLine("{0,50}",message);
        }
    }
}
