using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace UDP_ServerText
{
    public partial class server : Form
    {
        private int messageNumber = 0;

        public server()
        {
            InitializeComponent();
        }
        private void server_Load(object sender, EventArgs e)
        {
            Thread t = new Thread(new ThreadStart(serverConnection));
            t.Start();
        }
        private void serverConnection()
        {
            UdpClient udpServer = new UdpClient(8080);
            //IP + port
            IPEndPoint RemoteIPEndPoint = new IPEndPoint(IPAddress.Any, 0);

            byte [] receivedBytes = udpServer.Receive(ref RemoteIPEndPoint);

            string strMessage = Encoding.ASCII.GetString(receivedBytes);
            messageNumber++;

            string msg = RemoteIPEndPoint.Address.ToString() +
                             ":" + RemoteIPEndPoint.Port.ToString() +
                             " Message " + messageNumber + " :  " + strMessage;

            TextBox.CheckForIllegalCrossThreadCalls = false;

            clientMessage.Text += msg + "\r\n";
            udpServer.Close();
            while (true)
            {
                serverConnection();
            }
        }

       
    }
}
