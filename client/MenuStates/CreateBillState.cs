using client.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client.MenuStates
{
    class CreateBillState : AbstractState
    {
        private String _menuMessage = "Меню создания нового счета ";
        private string _message = "Подтвердите создание нового счета. 1 - создать счет , 2 - Выйти в меню пользователя ";
        private CommunicationService _comService;
        private string _input;

        public CreateBillState(MainClientContext context) : base(context)
        {
            _context = context;
        }

        public override void RunMenu()
        {
            Console.Clear();
            ShowMenu(_menuMessage);
            ShowMenu(_message);

        }

        public override void StartMenu()
        {
            _input = Console.ReadLine();
            if(_input == "1")
            {
                List<string> answer = CommunicateWithTheServer();
                if (answer[0] == "1")
                {
                    Console.WriteLine(answer[1]);
                    Console.ReadLine();
                    _context.ChangeState(new BillListState(_context));
                }
                else
                {
                    Console.WriteLine("Ошибка попробуйте еще раз ");
                    Console.ReadLine();
                    RunMenu();
                }

            }
            else
                _context.ChangeState(new UserMenuState(_context));

        }

        private List<string> CommunicateWithTheServer()
        {
            _comService = new CommunicationService(CommunicationService.RequestCode.createBill, SocketClient._sender);
            _comService.SendToServer();
            return _comService.ReciveToServer();
        }
    }
}
