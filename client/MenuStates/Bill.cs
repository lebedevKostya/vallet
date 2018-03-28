using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client.MenuStates
{
    class Bill
    {
        private string _id;
        private string _login;
        private DateTime _createDate;
        private decimal _amount;

        public Bill(string no_bill)
        {
            Id = "Нет счетов";
        }
        public Bill(string id, string login, DateTime createDate, decimal amount)
        {
            Id = id;
            Login = login;
            CreateDate = createDate;
            Amount = amount;
        }

        public string Id { get => _id; set => _id = value; }
        public string Login { get => _login; set => _login = value; }
        public DateTime CreateDate { get => _createDate; set => _createDate = value; }
        public decimal Amount { get => _amount; set => _amount = value; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(_id + ";");
            sb.Append(_login + ";");
            sb.Append(_createDate + ";");
            sb.Append(_amount);
            string bill = sb.ToString();

            return bill;
        }
    }
}
