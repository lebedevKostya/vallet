using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client.MenuStates
{

    public class MainClientContext 
    {
        private AbstractState _state;
        private User _user;
        internal User User { get => _user; set => _user = value; }

        public MainClientContext()
        {
            _state = new EntryState(this);
          
        }


        public AbstractState getState()
        {
            return _state;
        }

        public void ChangeState(AbstractState state)
        {
            _state = state;
        }

        public void RunMenu()
        {
            _state.RunMenu();
        }
        public void StartMenu()
        {
            _state.StartMenu();
        }





    }
}
