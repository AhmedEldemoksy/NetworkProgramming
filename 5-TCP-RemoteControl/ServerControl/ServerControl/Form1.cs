using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerControl
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Thread myth = new Thread(new System.Threading.ThreadStart(our_server));
            myth.Start();

        }
        void our_server()
        {
            TcpListener listener = new TcpListener(5020);
            listener.Start();
            Socket mysocket = listener.AcceptSocket();
            NetworkStream myns = new NetworkStream(mysocket);
            StreamReader mysr = new StreamReader(myns);
            string order = mysr.ReadLine();
            if (order == "notepad")
                System.Diagnostics.Process.Start("notepad");
            else if (order == "calculator")
                System.Diagnostics.Process.Start("calc");
            else
                MessageBox.Show("Sorry Sir Your Request is not in my hand", order);
            listener.Stop();
            
        }
    }
}
