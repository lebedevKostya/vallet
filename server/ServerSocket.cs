using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace server
{
    class ServerSocket
    {
        static Socket _listenSocket;
        static int port = 8505; //порт для приема входящих запросов

        public static Socket StartServer()
        {
            //получаем адрес для запуска сокета
            IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);

            // create socket
            _listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                // связываем сокет с локальной точкой, по которой будем принимать данные
                _listenSocket.Bind(ipPoint);

                // начинаем слушать 
                _listenSocket.Listen(10);

                Console.WriteLine("Сервер запущен. Ожидание подключения...");
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return _listenSocket;

        }

        public static string Recivemessage(Socket handler)
        {
            handler = _listenSocket.Accept();
            // получаем сообщение
            StringBuilder builder = new StringBuilder();
            int bytes = 0;
            byte[] data = new byte[256]; //bufer

            do
            {
                bytes = handler.Receive(data);
                builder.Append(Encoding.Unicode.GetString(data, 0, bytes));

            }
            while (handler.Available > 0);

            string message = DateTime.Now.ToShortTimeString() + ": " + builder.ToString();
            return message;

        }

        public static void SendMessage(Socket handler)
        {
            byte[] data = new byte[256];
            string message = "2,asdasd";
            data = Encoding.Unicode.GetBytes(message);
            handler.Send(data);
           
        }

        public static void ExitSocket(Socket handler)
        {
            handler.Shutdown(SocketShutdown.Both);
            handler.Close();
        }





        static void Main(string[] args)
        {
            //получаем адрес для запуска сокета
            IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);

            // create socket
             _listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                // связываем сокет с локальной точкой, по которой будем принимать данные
                _listenSocket.Bind(ipPoint);

                // начинаем слушать 
                _listenSocket.Listen(10);

                Console.WriteLine("Сервер запущен. Ожидание подключения...");
                Socket handler = _listenSocket.Accept();
                while (true)
                {
                    
                    // получаем сообщение
                    StringBuilder builder = new StringBuilder();
                    int bytes = 0;
                    byte[] data = new byte[256]; //bufer

                    do
                    {
                        bytes = handler.Receive(data);
                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));

                    }
                    while (handler.Available > 0);

                    Console.WriteLine(DateTime.Now.ToShortTimeString() + ": " + builder.ToString());

                    string message = "2,asdasd";
                    data = Encoding.Unicode.GetBytes(message);
                    handler.Send(data);
                    //handler.Shutdown(SocketShutdown.Both);
                    //handler.Close();



                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
