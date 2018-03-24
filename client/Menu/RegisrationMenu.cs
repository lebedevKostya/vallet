using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client.Menu
{
    class RegisrationMenu : AbstractMenu
    {
        private string _menuMessage = " Меню Регистрации ";
        private string _name;
        private string _surname;
        private string _login;
        private string _password;

        private List<string> _input;
        

        public RegisrationMenu()
        {
            Console.Clear();
            ShowMenu(_menuMessage);
            _input = new List<string>();
        }

       

        public override void RunMenu()
        {
            Console.WriteLine("Введите имя: ");
            _name = Console.ReadLine();
            _input.Add(_name);
            Console.WriteLine("Введите фамилию: ");
            _surname = Console.ReadLine();
            _input.Add(_surname);
            Console.WriteLine("Введите логин: ");
            _login = Console.ReadLine();
            _input.Add(_login);
            Console.WriteLine("Введите пароль: ");
            _password = Console.ReadLine();
            _input.Add(_password);
        }

    }
}
