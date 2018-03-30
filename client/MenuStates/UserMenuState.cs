using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client.MenuStates
{
    class UserMenuState : AbstractState
    {
        private string _menuMessage = " Меню Пользователя";
        private string _message = "Выберите действие:\n 1-Открыть список счетов\n 2- Открыть новый счет\n 3- Выход\n";
        private string _input;
        private Dictionary<string, AbstractState> _choice;

        public UserMenuState(MainClientContext context) : base(context) 
        {
            _context = context;
            _choice = new Dictionary<string, AbstractState>
            {
                { "1",  new BillListState(_context) },
                { "2",  new CreateBillState(_context) },
                { "3",  new EntryState(_context) }
            };
        }

        public override void StartMenu()
        {
            Console.Clear();
            ShowMenu(_menuMessage);
            Console.WriteLine(_message);
            
        }

        public override void RunMenu()
        {
            try
            {
                _input = Console.ReadLine();
                _context.ChangeState(_choice[_input]);

            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("Некорректный ввод. Нажмите ENTER для повторного ввода.");
                Console.ReadLine();
                StartMenu();
            }
        }
    }
}
