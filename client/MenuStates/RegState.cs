using client.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client.MenuStates
{
    class RegState : AbstractState
    {
        private string _menuMessage = " Меню Регистрации ";
        private string _name;
        private string _surname;
        private string _login;
        private string _password;
        private List<string> _input;
        private CommunicationService _comService;


        public RegState(MainClientContext context) : base ( context)
        {
            Console.Clear();
            _context = context;
            Console.Clear();
            _input = new List<string>();
        }

        public override void StartMenu()
        {
            Console.Clear();
            ShowMenu(_menuMessage);
            Console.WriteLine("Введите имя: ");
            _name = Console.ReadLine();
            Console.WriteLine("Введите фамилию: ");
            _surname = Console.ReadLine();
            Console.WriteLine("Введите логин: ");
            _login = Console.ReadLine();
            Console.WriteLine("Введите пароль: ");
            _password = Console.ReadLine();
            _input.Add(_name);
            _input.Add(_surname);
            _input.Add(_login);
            _input.Add(_password);
        }

        public override void RunMenu()
        {
            List<string> answer = CommunicateWithTheServer(_input);
            if (answer[0] == "1")
            {
                _context.User = new User(_input[2]);
                _context.ChangeState(new UserMenuState(_context));
            }
            else
            {
                Console.WriteLine("Не известная ошибка. Нажмите ENTER для продолжения.");
                Console.ReadLine();
                _context.ChangeState(new EntryState(_context));
            }
        }

        private List<string> CommunicateWithTheServer(List<string> input)
        {
            _comService = new CommunicationService(CommunicationService.RequestCode.reg, SocketClient._sender);
            _comService.SendToServer(_input);
            return _comService.ReciveToServer();
        }



    }
}

