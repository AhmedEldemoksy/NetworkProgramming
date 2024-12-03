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

namespace TCPClient2020
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            byte[] dataBuffer;
            dataBuffer = Encoding.ASCII.GetBytes(textBox1 .Text );
            TcpClient myclient = new TcpClient("127.0.0.1", 5020);
            NetworkStream mystream = myclient.GetStream();
            mystream.Write(dataBuffer, 0, dataBuffer.Length);
            mystream.Close();
            myclient.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
