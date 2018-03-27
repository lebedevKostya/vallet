using System;
using System.Net.Sockets;
using client.Menu;
using client.Menu.states;

namespace client
{
    class Program
    {
        public static void Main()
        {
            SocketClient.StartClient();
            MainClientContext st = new MainClientContext();
            while (st.getState() != null)
                st.RunMenu();
           
            
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