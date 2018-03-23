using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client.Menu
{
    class RegisrationMenu : Menu
    {
        private String login;
        private String password;
        private String[] input = new String[2];

        public RegisrationMenu()
        {
            Console.WriteLine("Введите логин: ");
            login = Console.ReadLine();

            Console.WriteLine("Введите пароль: ");
            password = Console.ReadLine();

            

        }
        public void Action()
        { }
    }
}
