using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientControl
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TcpClient myclient = new TcpClient(textBox1.Text, 5020);
            NetworkStream ns = myclient.GetStream();
            StreamWriter sw = new StreamWriter(ns);
            sw.WriteLine(textBox2.Text);
            sw.Close();
            ns.Close();
            myclient.Close();
        }
    }
}
