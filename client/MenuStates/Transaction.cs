using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client.MenuStates
{
    class Transaction
    {
        private string _idTransaction;
        private string _recipientId;
        private string _idBill;
        private decimal amount;
        private DateTime _transactDate;

        public Transaction(string idTransaction, string recipientId, string idBill, decimal amount, DateTime transactDate)
        {
            _idTransaction = idTransaction;
            _recipientId = recipientId;
            _idBill = idBill;
            this.amount = amount;
            _transactDate = transactDate;
        }

        public string IdTransaction { get => _idTransaction; set => _idTransaction = value; }
        public string RecipientId { get => _recipientId; set => _recipientId = value; }
        public string IdBill { get => _idBill; set => _idBill = value; }
        public decimal Amount { get => amount; set => amount = value; }
        public DateTime TransactDate { get => _transactDate; set => _transactDate = value; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(IdTransaction + ";");
            sb.Append(RecipientId + ";");
            sb.Append(IdBill + ";");
            sb.Append(Amount + ";");
            sb.Append(TransactDate);
            string transact = sb.ToString();
            return transact;
        }
    }
}
