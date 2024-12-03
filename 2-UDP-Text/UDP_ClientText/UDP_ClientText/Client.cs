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

namespace UDP_ClientText
{
    public partial class client : Form
    {
        public client()
        {
            InitializeComponent();
        }

        private void send_Click(object sender, EventArgs e)
        {
            if (!userMessage.Text.Equals(""))
            {
                string message = userMessage.Text;

                UdpClient x = new UdpClient();

                x.Connect("", 8080);

                byte[] y = Encoding.ASCII.GetBytes(message);

                x.Send(y, y.Length);
                x.Close();
            }
            else
            {
                MessageBox.Show("Enter Message First");
            }
        }

    }
}
