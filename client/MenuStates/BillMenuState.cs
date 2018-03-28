using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client.MenuStates
{
    class BillMenuState : AbstractState
    {
        Bill _currentBill;
        private string _menuMessage = "Меню счета";
        private string _message = "Выберите действие:\n 1-Перевод\n 2-Выписка\n 3-Закрыть счет\n 4-Выйти из меню счета\n ";
        private string _input;
        private Dictionary<string, IStateFactory> _choice;

        public BillMenuState(MainClientContext context) : base(context)
        {
            _context = context;
            _currentBill = _context.User.CurrentBill;
            _choice = new Dictionary<string, IStateFactory>
            {
                {"1", new TransferMenuFactory() },
                {"2", new TransactionMenuFactory() },
                {"3", new CloseBillMenuFactory () },
                {"4", new BillListMenuFactory() }
            };
        }

        public override void StartMenu()
        {
            ShowMenu(_menuMessage);
            Console.WriteLine(_currentBill.ToString());
            Console.WriteLine(_message);

        }

        public override void RunMenu()
        {
            try
            {
                _input = Console.ReadLine();
                _context.ChangeState(_choice[_input].CreateState(_context));

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
