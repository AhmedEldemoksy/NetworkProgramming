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

namespace Asynchronous_chat_client
{
    public partial class Form1 : Form
    {
        private Socket client;
        private byte[] _buffer = new byte[1024];
        private int attempts = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ListBox.CheckForIllegalCrossThreadCalls = false;
        }

        private void connect_Click(object sender, EventArgs e)
        {
            Socket newSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            if (!textBox1.Text.Equals(" "))
            {
                IPEndPoint iep = new IPEndPoint(IPAddress.Parse(textBox1.Text), 5020);
                newSocket.BeginConnect(iep, new AsyncCallback(Connected),newSocket);
                status.Items.Add("Connecting...");
                attempts++;
                status.Items.Add("Attempt(s): " + attempts.ToString());
            }
            else
            {
                MessageBox.Show("Enter server IP");
            }
        }
        private void Connected(IAsyncResult iar)
        {
            client = (Socket)iar.AsyncState;
            client.EndConnect(iar);
            status.Items.Add("Connected to: " + client.RemoteEndPoint.ToString());
            client.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None,
            new AsyncCallback(ReceiveData), client);
        }
        private void disconnect_Click(object sender, EventArgs e)
        {
            client.Disconnect(false);
            status.Items.Add("Disconnected");
        }

        private void send_Click(object sender, EventArgs e)
        {
            byte[] strMessage = Encoding.ASCII.GetBytes(textBox2.Text);
            textBox2.Clear();
            textBox2.Focus();
            client.BeginSend(strMessage, 0, strMessage.Length, SocketFlags.None, new AsyncCallback(SendData), client);
        }
        private void SendData(IAsyncResult iar)
        {
            Socket remote = (Socket)iar.AsyncState;
            int sent = remote.EndSend(iar);
            remote.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveData), remote);
        }
        private void ReceiveData(IAsyncResult iar)
        {
            Socket remote = (Socket)iar.AsyncState;
            int recv = remote.EndReceive(iar);
            string stringData = Encoding.ASCII.GetString(_buffer, 0, recv);
            results.Items.Add(stringData);
        }
       
    }
}
