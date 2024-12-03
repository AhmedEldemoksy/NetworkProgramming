using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace chat_client
{
    class Program
    {
        static void Main(string[] args)
        {
            //How send data using udp - socket
            IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9050);
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            string welcome = "Hello, are you there?";
            byte[] data = Encoding.ASCII.GetBytes(welcome);
            server.SendTo(data, data.Length, SocketFlags.None, ipEndPoint);

            //How recieve data from udp - socket.
            IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0); 
            EndPoint Remote = (EndPoint)sender; 
            data = new byte[1024];
            int dataLength = server.ReceiveFrom(data, ref Remote); 
            Console.WriteLine("Message received from {0}:", Remote.ToString()); 
            Console.WriteLine(Encoding.ASCII.GetString(data, 0, dataLength)); 

            while (true) 
            { 
                string input = Console.ReadLine();
                if (input == "exit") 
                    break;
                server.SendTo(Encoding.ASCII.GetBytes(input), Remote);
                data = new byte[1024]; 
                
                dataLength = server.ReceiveFrom(data, ref Remote); 
                string Data = Encoding.ASCII.GetString(data, 0, dataLength); 
                Console.WriteLine(Data);
            } 
            Console.WriteLine("Stopping client");                
            server.Close();
        }

    }
}
