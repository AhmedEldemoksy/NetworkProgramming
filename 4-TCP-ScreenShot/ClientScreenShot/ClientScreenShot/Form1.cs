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

namespace ClientScreenShot
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        MemoryStream ms;
        public Bitmap print_screeen()
        {
            Bitmap bitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width,Screen.PrimaryScreen.Bounds.Height);
            Graphics graph = Graphics.FromImage(bitmap as Image);
            graph.CopyFromScreen(0, 0, 0, 0, bitmap.Size);
            return bitmap;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = print_screeen();
            pictureBox1.Image = bitmap;
            MemoryStream ms = new MemoryStream();

            pictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            byte[] buffer = ms.GetBuffer();
            ms.Close();
            TcpClient client = new TcpClient("192.168.1.9", 8080);
            NetworkStream ns = client.GetStream();
            BinaryWriter br = new BinaryWriter(ns);
            br.Write(buffer);
            br.Close();
            ns.Close();
            client.Close();
            timer1.Start();          
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            button1.PerformClick();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }
    }
}
