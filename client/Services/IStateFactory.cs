using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client.MenuStates
{
     public abstract class IStateFactory
    {
        abstract public AbstractState CreateState(MainClientContext context);
    }


    public class EntryStateFactory : IStateFactory
    {
        public override AbstractState CreateState(MainClientContext context)
        {
            return new EntryState(context);
        }
    }

    public class AuthStateFactory : IStateFactory
    {
        public override AbstractState CreateState(MainClientContext context)
        {
            return new AuthState(context);
        }
    }

    public class RegStateFactory : IStateFactory
    {
        public override AbstractState CreateState(MainClientContext context)
        {
            return new RegState(context);
        }
    }

    public class UserMenuStateFactory : IStateFactory
    {
        public override AbstractState CreateState(MainClientContext context)
        {
            return new UserMenuState(context);
        }
    }

    public class BillListMenuFactory : IStateFactory
    {
        public override AbstractState CreateState(MainClientContext context)
        {
            return new BillListState(context);
        }
    }

    public class CreateBillMenuFactoty : IStateFactory
    {
        public override AbstractState CreateState(MainClientContext context)
        {
            return new CreateBillState(context);
        }
    }

    public class TransferMenuFactory : IStateFactory
    {
        public override AbstractState CreateState(MainClientContext context)
        {
            return new TransferMenuState(context);
        }
    }

    public class TransactionMenuFactory : IStateFactory
    {
        public override AbstractState CreateState(MainClientContext context)
        {
            return new TransactionListMenu(context);
        }
    }

    public class CloseBillMenuFactory : IStateFactory
    {
        public override AbstractState CreateState(MainClientContext context)
        {
            return new CloseBillMenu(context);
        }
    }

}
