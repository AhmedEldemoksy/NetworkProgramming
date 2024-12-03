using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace TCPServer_2020
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Thread myThread = new Thread(new ThreadStart(our_server));
            myThread.Start();
        }
        public void our_server()
        {
            TcpListener listener = new TcpListener(5020);
            listener.Start();
            Socket connection = listener.AcceptSocket();
            NetworkStream mystream = new NetworkStream(connection);
            byte[] data = new byte[7000];
            mystream.Read(data, 0, data.Length);
            string msg = Encoding.ASCII.GetString(data); 
            MessageBox.Show(msg);
            listener.Stop();
            while (true)
            {
                our_server();
            }
        }
    }
}
