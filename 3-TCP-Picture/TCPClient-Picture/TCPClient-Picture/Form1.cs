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
using System.IO;

namespace TCPClient_Picture
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.ShowDialog();
            string path = openFileDialog1.FileName;
            pictureBox1.Image = Image.FromFile(path);
            textBox2.Text = path;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
            byte[] buffer = ms.GetBuffer(); 
            ms.Close();
            TcpClient client = new TcpClient(textBox1.Text, 8080);
            NetworkStream networkstream = client.GetStream();
            BinaryWriter binarywriter = new BinaryWriter(networkstream);
            binarywriter.Write(buffer);
            binarywriter.Close();
            networkstream.Close();
            client.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
