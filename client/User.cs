using client.MenuStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client
{
    class User
    {
        private string _name;
        private string _surname;
        private string _login;
        private List<Bill> _billList;
        private Bill _currentBill;
        

        public User(string login)
        {
            Login = login;
        }

        public User(string name, string surname, string login) 
        {
            Surname = surname;
            Login = login;
        }


        public string Name { get => _name; set => _name = value; }
        public string Surname { get => _surname; set => _surname = value; }
        public string Login { get => _login; set => _login = value; }
        internal List<Bill> BillList { get => _billList; set => _billList = value; }
        internal Bill CurrentBill { get => _currentBill; set => _currentBill = value; }
    }
}
