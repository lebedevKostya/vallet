using client.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client.MenuStates
{
    class TransactionListMenu : AbstractState
    {
        private String _menuMessage = " Список транзакций";
        private CommunicationService _comService;
        

        public TransactionListMenu(MainClientContext context) : base(context)
        {
            _context = context;
        }

        public override void RunMenu()
        {
            Console.Clear();
            ShowMenu(_menuMessage);
            _context.User.CurrentBill.TransacList = CommunicateWithTheServer();
            foreach (var item in _context.User.CurrentBill.TransacList)
            {
                Console.WriteLine(item.ToString());
            }

        }

        public override void StartMenu()
        {
            Console.WriteLine("Нажмите ENTER для продолжения");
            Console.ReadLine();
            _context.ChangeState(new BillMenuState(_context));
        }

        private List<Transaction> CommunicateWithTheServer()
        {
            _comService = new CommunicationService(CommunicationService.RequestCode.transaction, SocketClient._sender);
            _comService.SendToServerTransac(_context.User.CurrentBill.Id);
            return _comService.ReciveToServerTransacList();
        }
    }
}
