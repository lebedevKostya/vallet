using client.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client.Menu.states
{
    class AuthState : IState
    {
        private String _menuMessage = " Меню Авторизации ";
        private String login;
        private String password;
        private List<String> _input;

        private CommunicationService _comService;


        public AuthState(MainClientContext context) : base(context)
        {
            _context = context;         
            _input = new List<string>();
        }



        public override void RunMenu()
        {
            ShowMenu(_menuMessage);
            Console.WriteLine("Введите логин: ");
            login = Console.ReadLine();
            Console.WriteLine("Введите пароль: ");
            password = Console.ReadLine();
            _input.Add(login);
            _input.Add(login);

          
            List<string> answer = CommunicateWithTheServer(_input);
            if (answer[0] == "1")
            {
                _context.ChangeState(new UserMenuState(_context));
            }
            else if (answer[0] == "2")
            {
                Console.WriteLine("Не правильный логин. Нажмите ENTER для продолжения.");
                Console.ReadLine();
                _context.ChangeState(new EntryState(_context));
            }
            else if (answer[0] == "2")
            {
                Console.WriteLine("Не правильный пароль. Нажмите ENTER для продолжения.");
                Console.ReadLine();
                _context.ChangeState(new EntryState(_context));
            }
            else
                Console.WriteLine("Не известная ошибка");
                Console.ReadLine();
                _context.ChangeState(new EntryState(_context));

        }

        private List<string> CommunicateWithTheServer(List<string> input)
        {
            _comService = new CommunicationService(CommunicationService.RequestCode.reg, SocketClient._sender);
            _comService.SendToServer(_input);
            return _comService.ReciveToServer();
        }

    }
}
