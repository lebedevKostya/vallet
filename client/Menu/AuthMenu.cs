using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client.Menu
{
    class AuthMenu : AbstractMenu<List<string>>
    {
        private String _menuMessage = " Меню Авторизации ";
        private String login;
        private String password;
        private List<String> _input;
        



        public AuthMenu()
        {
            Console.Clear();
            ShowMenu(_menuMessage);
            _input = new List<string>();
        }

    

        public override void RunMenu()
        {
            Console.WriteLine("Введите логин: ");
            login = Console.ReadLine();
            _input.Add(login);
            Console.WriteLine("Введите пароль: ");
            password = Console.ReadLine();
            _input.Add(login);

        }
        public override List<string> GetInput()
        {
            return _input;
        }
  

        

        
    }
}
