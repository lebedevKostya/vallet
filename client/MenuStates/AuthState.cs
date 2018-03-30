using client.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client.MenuStates
{
    class AuthState : AbstractState
    {
        private String _menuMessage = " Меню Авторизации ";
        private String login;
        private String password;
        private List<String> _input;
        private CommunicationService _comService;
        private Dictionary<string, IStateFactory> _choice;

        public AuthState(MainClientContext context) : base(context)
        {
            _context = context;
            _input = new List<string>();
            _choice = new Dictionary<string, IStateFactory>
            {
                {"1", new UserMenuStateFactory() },
                {"2", new EntryStateFactory() },
                {"3", new EntryStateFactory() }
            };

        }

        public override void StartMenu()
        {
            Console.Clear();
            ShowMenu(_menuMessage);
            Console.WriteLine("Введите логин: ");
            login = Console.ReadLine();
            Console.WriteLine("Введите пароль: ");
            password = Console.ReadLine();
            _input.Add(login);
            _input.Add(password);
        }

        public override void RunMenu()
        {
            List<string> answer = CommunicateWithTheServer(_input);
            try
            {
                if (answer[0] == "1")
                {
                    _context.User = new User(_input[0]);
                    _context.ChangeState(_choice[answer[0]].CreateState(_context));
                }
                else
                {
                    if (answer[0] == "2")
                    {
                        Console.WriteLine("Не правильный логин. Нажмите ENTER для продолжения.");
                        Console.ReadLine();
                    }
                    else if (answer[0] == "3")
                    {
                        Console.WriteLine("Не правильный пароль. Нажмите ENTER для продолжения.");
                        Console.ReadLine();
                    }
                    _context.ChangeState(_choice[answer[0]].CreateState(_context));
                }
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("Неизвестная ошибка.Нажмите ENTER для продолжения.");
                Console.ReadLine();
                _context.ChangeState(new EntryState(_context));
            }
        }


        private List<string> CommunicateWithTheServer(List<string> input)
        {
            _comService = new CommunicationService(CommunicationService.RequestCode.auth, SocketClient._sender);
            _comService.SendToServer(_input);
            return _comService.ReciveToServer();
        }

    }
}
