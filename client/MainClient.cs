using client.Menu;
using client.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;


namespace client
{
    class MainClient
    {
       

        AbstractMenu<string> _entryMenu;
        AbstractMenu<List<string>> _authMenu;
        AbstractMenu<List<string>> _regMenu;
        AbstractMenu<string> _userMenu;



        CommunicationService _comService;
       


        


        public void StartClient()
        {
            _entryMenu = new EntryMeny();
            _entryMenu.RunMenu();
            if(_entryMenu.GetInput() == "1")
            {
                RunAuthMenu();
            }
            else if (_entryMenu.GetInput() == "2")
            {
                RunRegistrationMenu();
            }
            
        }

        private void RunAuthMenu()
        {
            _authMenu = new AuthMenu();
            _authMenu.RunMenu();
            
            _comService = new CommunicationService("1",SocketClient._sender);
            _comService.SendToServer(_authMenu.GetInput());
            List<string> answer = _comService.ReciveToServer();
            if (answer[0] == "1")
            {
                RunUserMenu();
            }
            else if(answer[0] == "2")
            {
                Console.WriteLine("Не правильно введен логин. Нажмите ENTER для продолжения.");
                Console.ReadLine();
                StartClient();
            }
            else if (answer[0] == "3")
            {
                Console.WriteLine("Не правильно введен пароль. Нажмите ENTER для продолжения.");
                Console.ReadLine();
                StartClient();
            }
            else 
                Console.WriteLine("Не известная ошибка. Нажмите ENTER для продолжения.");
                Console.ReadLine();
                StartClient();       
        }

        private void RunRegistrationMenu()
        {
            _regMenu = new RegisrationMenu();
            _regMenu.RunMenu();

            _comService = new CommunicationService("2", SocketClient._sender);
            _comService.SendToServer(_regMenu.GetInput());
            List<string> answer = _comService.ReciveToServer();
            if (answer[0] == "1")
            {
                RunUserMenu();
            }
            else
            Console.WriteLine("Не известная ошибка. Нажмите ENTER для продолжения.");
            Console.ReadLine();
            StartClient();
        }

        private void RunUserMenu()
        {
            _userMenu = new UserMenu();
            _userMenu.RunMenu();
            if (_userMenu.GetInput() == "1")
            {
                // TODO открыть список счетов
            }
            else if (_entryMenu.GetInput() == "2")
            {
                // TODO создать новый счет
            }
            else
                StartClient();
        }
    }
}
