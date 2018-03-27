using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client.Menu.states
{

    public class MainClientContext 
    {
        private IState _state;


       public MainClientContext()
        {
            _state = new EntryState(this);
          
        }


        public IState getState()
        {
            return _state;
        }

        public void ChangeState(IState state)
        {
            _state = state;
        }

        public void RunMenu()
        {
            _state.RunMenu();
        }





    }
}
