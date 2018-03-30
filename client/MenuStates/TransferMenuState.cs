using client.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client.MenuStates
{
    class TransferMenuState : AbstractState
    {
        private string _menuMessage = "Меню перевода";
        private List<string> _input;
        private string _idRecipient;
        private string _idBill;
        private string _amount;
        private CommunicationService _comService;



        public TransferMenuState(MainClientContext context) : base(context)
        {
            _context = context;
            _idBill = _context.User.CurrentBill.Id;
            _input = new List<string>();

        }

        public override void StartMenu()
        {
            Console.Clear();
            ShowMenu(_menuMessage);
            Console.WriteLine("Введите ID счета получателя");
            _idRecipient = Console.ReadLine();
            Console.WriteLine("Введите сумму перевода");
            _amount = Console.ReadLine();
            _input.Add(_idRecipient);
            _input.Add(_idBill);
            _input.Add(_amount);

        }

        public override void RunMenu()
        {
            string answer = CommunicateWithTheServer(_input);
            if(answer == "1")
            {
                Console.WriteLine("Перевод прошел удачно. Нажмите ENTER для продолжения ");
                Console.ReadLine();
            }
            else if(answer == "2")
            {
                Console.WriteLine("Недостаточно средств. Нажмите ENTER для продолжения ");
                Console.ReadLine();
            }
            else if(answer == "0")
            {
                Console.WriteLine("Нет такого счета. Нажмите ENTER для продолжения ");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Неизвестная ошибка. Нажмите ENTER для продолжения ");
                Console.ReadLine();
            }
            _context.ChangeState(new BillMenuState(_context));
        }

        private string CommunicateWithTheServer(List<string> input)
        {
            _comService = new CommunicationService(CommunicationService.RequestCode.transfer, SocketClient._sender);
            _comService.SendToServer(_input);
            return _comService.ReciveToServ();
        }
    }
}
