using System;
using System.Net.Sockets;
using client.Menu;


namespace client
{
    class Program
    {
        public static void Main()
        {

            SocketClient.StartClient();
            while (true)
            {
                
                MainClient client = new MainClient();
                client.StartClient();
                Console.ReadLine();
            }
           
            
        }
    }
}
/*
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                   AuthMenu authmenu = new AuthMenu();
                   String[] inputHand = authmenu.Input;
                   AuthService authService = new AuthService(inputHand);
                   SocketClient.SendMessage(socket, authService.GenerateRequest());
                   ResponseHandler authhandler = new ResponseHandler(SocketClient.ReciveMessage(socket));
                    authhandler.DoAnswer(); 
                   

                    Console.ReadLine();
                    break;
                case "2":
                    Console.WriteLine("Case 2");
                    break;
                default:
                    Console.WriteLine("Default case");
                    break;
            }
           




        }
    }
}
*/