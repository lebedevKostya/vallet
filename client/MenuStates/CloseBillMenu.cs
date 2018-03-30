using client.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client.MenuStates
{
    class CloseBillMenu : AbstractState
    {
        private String _menuMessage = "Меню закрытия счета ";
        private CommunicationService _comService;
        private List<string> _input;
        List<String>  _answer;


        public CloseBillMenu(MainClientContext context) : base(context)
        {
            _context = context;
        }

        public override void StartMenu()
        {
            Console.Clear();
            ShowMenu(_menuMessage);
            if(_context.User.CurrentBill.Amount != 0)
            {
                Console.WriteLine("На счету есть ДС. Нажмите ENTER для перевода");
                Console.ReadLine();
                _context.ChangeState(new TransferMenuState(_context));
            }
            else
            {
                _input = new List<string>();
                _input.Add(_context.User.CurrentBill.Id);
                _answer = CommunicateWithTheServer();
            }
            
        }

        public override void RunMenu()
        {
            if(_answer[0] == "1")
            {
                Console.WriteLine("Счет закрыт!");
                Console.ReadLine();
                _context.ChangeState(new UserMenuState(_context));
            }
            else
            {
                Console.WriteLine("Ошибка при закрытие. Повторите");
                Console.ReadLine();
                _context.ChangeState(new BillMenuState(_context));
            }
           
        }

        private List<string> CommunicateWithTheServer()
        {
            _comService = new CommunicationService(CommunicationService.RequestCode.closeBill, SocketClient._sender);
            _comService.SendToServer(_input);
            return _comService.ReciveToServer();
        }
    }
}
