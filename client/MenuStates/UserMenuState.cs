using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client.Menu.states
{
    class UserMenuState : IState
    {
        private string _menuMessage = " Меню Пользователя";
        private string _message = "Выберите действие:\n 1-Открыть список счетов\n 2- Открыть новый счет\n 3- Выход\n";
        private string _input;
        



        public UserMenuState(MainClientContext context) : base(context) 
        {
            _context = context;
           
        }

        public override void RunMenu()
        {
            ShowMenu(_menuMessage);
            Console.WriteLine(_message);
            _input = Console.ReadLine();
            if (_input == "1")
            {
                Console.WriteLine("Список счетов");//_context.ChangeState(new BillLIstState(_context));
            }
            else if (_input == "2")
            {
                Console.WriteLine("Создать счет");
                // _context.ChangeState(new CreateMenuState(_context));
            }
            else if (_input == "3")
            {
                _context.ChangeState(new EntryState(_context));
            }
            else
                RunMenu();
        }



    }
}
