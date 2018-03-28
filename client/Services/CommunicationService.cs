using client.MenuStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace client.Services
{
    class CommunicationService 
    {
        private RequestCode _comunicationProtocol;
        private Socket _sender;
        private string _request;
        private List<string> _afterParse;
        private List<Bill> _billList;
         
       public enum RequestCode : int 
        {
            auth = 1,
            reg,
            billList,
            createBill,
            transfer,
            transaction,
            closeBill
        }
        
        
        public CommunicationService(RequestCode CommunicationProtocol, Socket sender)
        {
            _comunicationProtocol = CommunicationProtocol;
            _sender = sender;
            _afterParse = new List<string>() ;
            
            
        }

        public void SendToServer()
        {
            _request = (_comunicationProtocol.ToString() + ",");
            SocketClient.SendMessage(SocketClient._sender, _request);

        }

        public  void SendToServer( List<String> inputHand)
        {
            inputHand.Insert(0, _comunicationProtocol.ToString());
            _request = String.Join(",", inputHand);
            SocketClient.SendMessage(SocketClient._sender, _request);

        }

        public  List<string> ReciveToServer() 
        {
           string answer = SocketClient.ReciveMessage(SocketClient._sender);
            _afterParse = answer.Split(',').ToList();
            return _afterParse;
            
        }

        public List<Bill> ReciveToServerBill()
        {
            _billList = new List<Bill>();
            string answer = SocketClient.ReciveMessage(SocketClient._sender);
            if (answer == "no_bill")
            {
                Bill bill = new Bill(answer);
                _billList.Add(bill);
            }
            else
            {
                _afterParse = answer.Split(',').ToList();
                foreach (var item in _afterParse)
                {
                    string[] separated = item.Split(';');
                    Bill bill = new Bill(separated[0], separated[1], DateTime.Parse(separated[2]), Decimal.Parse(separated[3]));
                    _billList.Add(bill);
                }
            }
            return _billList;
        }
        
        public string ReciveToServ()
        {
            string answer = SocketClient.ReciveMessage(SocketClient._sender);
            return answer;

        }
           


        
    }
}
