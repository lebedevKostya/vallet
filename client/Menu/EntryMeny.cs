using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client.Menu
{
    class EntryMeny : Menu
    {
        private string _menuMessage = "Меню входа";
        private string _message = "Выберите действие:\n 1-Авторизация\n 2- Регистрация\n 3- Выход\n";
        private string _choice;
        
        private AuthMenu _authMenu;
        private RegisrationMenu _regMenu;

        private string _messageToSocket;
        public string MessageToSocket { get => _messageToSocket;}


        public EntryMeny()
        {
            ShowMenu(_menuMessage);
        }
        

        public void Run()
        {
            bool done = true;

            while (done)
            {
                Console.WriteLine(_message);
                _choice = Console.ReadLine();
                    switch (_choice)
                    {
                        case "1":
                            _authMenu = new AuthMenu();
                            _authMenu.Action();
                            _messageToSocket = _authMenu.HandleMessageToSocket();
                            done = false;
                            break;

                        case "2":
                            _regMenu = new RegisrationMenu();
                            _regMenu.Action();
                            done = false;
                            break;

                        case "3":
                            Console.Clear();
                            done = false;
                            break;

                        default:
                            Console.WriteLine("Вы ввели некорректный символ. Повторите ввод!");
                            break;
                }
            }
        }


    }
}
