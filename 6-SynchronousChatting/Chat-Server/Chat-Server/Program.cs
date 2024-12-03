using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Chat_Server
{
    class Program
    {
        static void Main(string[] args)
        {
            int dataLength;
            byte[] data = new byte[1024];
            IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Any, 9050); 
            Socket newsock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            newsock.Bind(ipEndPoint);

            Console.WriteLine("Waiting for a client...");
            //recieve data from client Hello are you there?
            IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);
            EndPoint Remote = (EndPoint)(sender);
            dataLength = newsock.ReceiveFrom(data, ref Remote); 
            Console.WriteLine("Message received from {0}:", Remote.ToString()); 
            Console.WriteLine(Encoding.ASCII.GetString(data, 0, dataLength));

            //send welcome to my test serve to sender client.
            string welcome = "Welcome to my test server"; 
            data = Encoding.ASCII.GetBytes(welcome); 
            newsock.SendTo(data, data.Length, SocketFlags.None, Remote);
            while (true)
            {
                data = new byte[1024]; 
                dataLength = newsock.ReceiveFrom(data, ref Remote); 
                Console.WriteLine(Encoding.ASCII.GetString(data, 0, dataLength));

                Console.WriteLine("**RECIEVED**");
                string seen = Console.ReadLine(); 
                data = Encoding.ASCII.GetBytes(seen);
                newsock.SendTo(data, data.Length, SocketFlags.None, Remote);
            }
        }
    }
}
