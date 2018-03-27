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
        static string address = "127.0.0.1";
        public static Socket _sender;

        public static Socket StartClient()
        {
            IPEndPoint remoteEP = new IPEndPoint(IPAddress.Parse(address), 8505);
            _sender = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                _sender.Connect(remoteEP);
                Console.Clear();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            return _sender;

        }


        public static void SendMessage(Socket sender, string message)
        {
            
            byte[] data = Encoding.Unicode.GetBytes(message);
            sender.Send(data);

        }



        public static string ReciveMessage(Socket sender)
        {
           byte [] data = new byte[256]; // буфер для ответа
            StringBuilder builder = new StringBuilder();
            int bytes = 0; // количество полученных байт

            do
            {
                bytes = sender.Receive(data, data.Length, 0);
                builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
            }
            while (sender.Available > 0);
            return builder.ToString();
           
        }

        public static void ExitSocket(Socket sender)
        {
            sender.Shutdown(SocketShutdown.Both);
            sender.Close();
            Console.ReadLine();
        }

    }
}






       