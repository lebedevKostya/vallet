using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client.Menu
{
    class EntryMeny : AbstractMenu <string>
    {
        private string _menuMessage = "Меню входа";
        private string _message = "Выберите действие:\n 1-Авторизация\n 2- Регистрация\n 3- Выход\n";
        private string _choice;
        public string Choice { get => _choice; set => _choice = value; }


        public EntryMeny()
        {
            ShowMenu(_menuMessage);
        }

        

        public override void RunMenu()
        {
            Console.Clear();
            Console.WriteLine(_message);
            Choice = Console.ReadLine();
        }

        public override string GetInput()
        {
            return Choice;
        }

    }
}
