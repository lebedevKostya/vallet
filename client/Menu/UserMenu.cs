using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client.Menu
{
    class UserMenu : AbstractMenu<string>
    {
        private string _menuMessage = " Меню Пользователя";
        private string _message = "Выберите действие:\n 1-Открыть список счетов\n 2- Открыть новый счет\n 3- Выход\n";
        private string _choice;



        public UserMenu()
        {
            ShowMenu(_menuMessage);
        }

        public override void RunMenu()
        {
            Console.Clear();
            Console.WriteLine(_message);
            _choice = Console.ReadLine();
        }
        public override string GetInput()
        {
            return _choice;
        }
    }
}
