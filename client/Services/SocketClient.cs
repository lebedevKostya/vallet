using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace client
{
    class SocketClient
    {
        //static string address = "127.0.0.1";
        public static Socket _sender;

        public static Socket StartClient()
        {
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint remoteEP = new IPEndPoint(ipAddress, 11000);

            // Create a TCP/IP  socket.  
            _sender = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            // Connect the socket to the remote endpoint. Catch any errors.  
            _sender.Connect(remoteEP);

            Console.WriteLine("Socket connected to {0}",
            _sender.RemoteEndPoint.ToString());


            //IPEndPoint remoteEP = new IPEndPoint(IPAddress.Parse(address), 11000);
            //_sender = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //try
            //{
            //    _sender.Connect(remoteEP);

            //}

            //catch (Exception ex)
            //{
            //    Console.Clear();
            //    Console.WriteLine(ex.Message);
            //    //StartClient();

            //}
            return _sender;

        }


        public static void SendMessage(Socket sender, string message)
        {

            byte[] data = Encoding.ASCII.GetBytes(message);
            sender.Send(data);

        }



        public static string ReciveMessage(Socket sender)
        {
            byte[] data = new byte[1024]; // буфер для ответа
            //StringBuilder builder = new StringBuilder();
            int bytes = 0; // количество полученных байт

            //do
            //{
            //    bytes = sender.Receive(data, data.Length, 0);
            //    builder.Append(Encoding.ASCII.GetString(data, 0, bytes));
            //}
            //while (sender.Available > 0);

            //return builder.ToString();
            bytes = sender.Receive(data);
            string answer = Encoding.ASCII.GetString(data, 0, bytes);

            return answer;

        }

        public static void ExitSocket(Socket sender)
        {
            sender.Shutdown(SocketShutdown.Both);
            sender.Close();
            Console.ReadLine();
        }

    }
}






