using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCPServer_Picture2020
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

     

        private void Form1_Load(object sender, EventArgs e)
        {
            Thread myThread = new Thread(new ThreadStart(Recived_image));
            myThread.Start();
        }
        void Recived_image()
        {
            TcpListener listener = new TcpListener(8080);
            listener.Start();
            Socket connection = listener.AcceptSocket();
            NetworkStream mystream = new NetworkStream(connection);
            pictureBox1.Image = Image.FromStream(mystream);
            listener.Stop();
            if (connection.Connected == true)
            { while (true)
                {
                    Recived_image();
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog savefiledialog = new SaveFileDialog();
            savefiledialog.Filter = "JPEG Image(*.jpg)|*.jpg";
            if (savefiledialog.ShowDialog() == DialogResult.OK)
            {
                string mypic_path = savefiledialog.FileName;
                pictureBox1.Image.Save(mypic_path);
            }
        }
    }
}
