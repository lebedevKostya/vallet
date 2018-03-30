using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client.MenuStates
{
    class EntryState : AbstractState
    {
        private string _menuMessage = "Меню входа";
        private string _message = "Выберите действие:\n 1-Авторизация\n 2- Регистрация\n ";
        private string _input;
        private Dictionary<string, IStateFactory> _choice;


        public EntryState(MainClientContext context) : base(context)
        {
            _context = context;
            _choice = new Dictionary<string, IStateFactory>
            {
                {"1", new AuthStateFactory() },
                {"2", new RegStateFactory() }
            };
        }

        public override void StartMenu()
        {
            Console.Clear();
            ShowMenu(_menuMessage);
            ShowMenu(_message);
           
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
