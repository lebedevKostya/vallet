﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client.Menu
{
    class EntryMeny : AbstractMenu
    {
        private string _menuMessage = "Меню входа";
        private string _message = "Выберите действие:\n 1-Авторизация\n 2- Регистрация\n 3- Выход\n";
        private string _choice;

        private AuthMenu _authMenu;
        private RegisrationMenu _regMenu;

        public EntryMeny()
        {
            ShowMenu(_menuMessage);
        }

        public override void RunMenu()
        {
            Console.Clear();
            Console.WriteLine(_message);
            _choice = Console.ReadLine();
        }

    }
}
