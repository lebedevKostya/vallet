using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client.Menu.states
{
    class EntryState : IState
    {
        private string _menuMessage = "Меню входа";
        private string _message = "Выберите действие:\n 1-Авторизация\n 2- Регистрация\n ";
        private string _input;

        private Dictionary<string, IState> _choice;


        public EntryState(MainClientContext context) : base(context)
        {
            _context = context;
           

            _choice = new Dictionary<string, IState>
            {
                { "1",  new AuthState(_context) },
                { "2",  new RegState(_context) }
            };

        }

        //TODO проверку на пользовательский ввод
        public override void RunMenu()
        {
            ShowMenu(_menuMessage);
            Console.WriteLine(_message);
            _input = Console.ReadLine();
            _context.ChangeState(_choice[_input]);        //if (_choice == "1")
                                                          //{
                                                          //    _context.ChangeState(new AuthState(_context)) ;
                                                          //}
                                                          //else if (_choice == "2")
                                                          //{
                                                          //    _context.ChangeState(new RegState(_context));
                                                          //}

        }






    }
}
