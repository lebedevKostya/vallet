﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client.Menu
{
    abstract class Menu
    {
        public void ShowMenu(String message)
        {
          Console.WriteLine("{0,50}",message);
        }
    }
}
