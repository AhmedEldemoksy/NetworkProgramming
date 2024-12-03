using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asynchronous_chat_Server
{
    public partial class Form1 : Form
    {
        private Socket server;
        private byte[] _buffer = new byte[1024];
        public Form1()
        {
            InitializeComponent();

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            ListBox.CheckForIllegalCrossThreadCalls = false;
            connection();
        }
        private void connection()
        {
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream,
            ProtocolType.Tcp);
            server.Bind(new IPEndPoint(IPAddress.Any, 5020));
            server.Listen(5);
            status.Items.Add("Waiting for client...");
            server.BeginAccept(new AsyncCallback(AcceptConn), server);
        }
        private void AcceptConn(IAsyncResult iar)
        {
            Socket oldConnection = (Socket)iar.AsyncState;
            Socket client = (Socket)oldConnection.EndAccept(iar);
            status.Items.Add("Connected to: " + client.RemoteEndPoint.ToString());
            string welcome = "Welcome to my server";
            byte[] x = Encoding.ASCII.GetBytes(welcome);
            client.BeginSend(x, 0, x.Length, SocketFlags.None,
            new AsyncCallback(SendData), client);
            oldConnection.BeginAccept(new AsyncCallback(AcceptConn), oldConnection);
        }
        private void SendData(IAsyncResult iar)
        {
            Socket client = (Socket)iar.AsyncState;
            int sent = client.EndSend(iar);
            client.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None,
            new AsyncCallback(ReceiveData), client);
        }
        private void ReceiveData(IAsyncResult iar)
        {
            Socket client = (Socket)iar.AsyncState;
            int recv = client.EndReceive(iar);
            if (recv == 0)
            {
                client.Close();
                status.Items.Add("Waiting for client...");
                server.BeginAccept(new AsyncCallback(AcceptConn), server);
                return;
            }
            else
            {
                string receivedData = Encoding.ASCII.GetString(_buffer, 0, recv);
                results.Items.Add(receivedData);
                byte[] message2 = Encoding.ASCII.GetBytes(receivedData);
                client.BeginSend(message2, 0, message2.Length, SocketFlags.None,
                new AsyncCallback(SendData), client);
            }
        }

    }
}
