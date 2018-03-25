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
        private string _comunicationProtocol;
        private Socket _sender;
        private string _request;
        private List<string> _afterParse;

        
        
        public CommunicationService(string CommunicationProtocol, Socket sender)
        {
            _comunicationProtocol = CommunicationProtocol;
            _sender = sender;
            _afterParse = new List<string>() ;
            
        }

        public  void SendToServer( List<String> inputHand)
        {
            inputHand.Insert(0, _comunicationProtocol);
            _request = String.Join(",", inputHand);
            SocketClient.SendMessage(SocketClient._sender, _request);

        }

        public  List<string> ReciveToServer() 
        {
           string answer = SocketClient.ReciveMessage(SocketClient._sender);
            _afterParse = answer.Split(',').ToList();
            return _afterParse;
            
        }
    }
}
