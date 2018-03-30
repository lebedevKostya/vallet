using client.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client.MenuStates
{
    class BillListState : AbstractState
    {
        private String _menuMessage = " Список счетов ";
        private string _message = "Введите ID счета или 0 для возврата в меню пользователя";
        private CommunicationService _comService;
        private string _input;

        public BillListState(MainClientContext context) : base(context)
        {
            _context = context;

        }

        public override void StartMenu()
        {
            Console.Clear();
            ShowMenu(_menuMessage);
            _context.User.BillList = CommunicateWithTheServer();
            foreach (var item in _context.User.BillList)
            {
                Console.WriteLine(item.ToString());
            }
            
        }

        public override void RunMenu()
        {
            Console.WriteLine(_message);
            _input = Console.ReadLine();
            if (_input == "0")
            {
                _context.ChangeState(new UserMenuState(_context));
            }
            else
            {
                foreach (var item in _context.User.BillList)
                {
                    if(_input == item.Id)
                    {
                        _context.User.CurrentBill = item;
                        _context.ChangeState(new BillMenuState(_context));
                    }
                    else
                    {
                        Console.WriteLine("Ошибка ввода. Повторите ввод");
                        RunMenu();
                    }
                }
            }
        }


        private List<Bill> CommunicateWithTheServer()
        {
            _comService = new CommunicationService(CommunicationService.RequestCode.billList, SocketClient._sender);
            _comService.SendToServer();
            return _comService.ReciveToServerBillList();
        }
    }
}
