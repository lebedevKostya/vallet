using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client.Menu
{
    class AuthMenu : Menu
    {
        private String _menuMessage = " Меню Авторизации ";
        private String login;
        private String password;

        private String[] input = new String[2];
        public string[] Input { get => input; }

        private AuthService _authService;

        public AuthMenu()
        {
            _authService = new AuthService();
            Console.Clear();
            ShowMenu(_menuMessage);
        }

        public void Action()
        {
            Console.WriteLine("Введите логин: ");
            login = Console.ReadLine();

            Console.WriteLine("Введите пароль: ");
            password = Console.ReadLine();

            Input[0] = login;
            Input[1] = password;

        }
        public string HandleMessageToSocket()
        {
           return  _authService.GenerateRequest(Input);
        }

        

        
    }
}
