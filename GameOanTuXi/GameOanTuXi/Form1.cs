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

namespace GameOanTuXi
{
    public partial class Form1 : Form
    {
        Socket server;
        IPEndPoint ipep;
        EndPoint remote;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
             ipep = new IPEndPoint(
                                             IPAddress.Parse("127.0.0.1"), 9050);
            server = new Socket(AddressFamily.InterNetwork,
             SocketType.Dgram, ProtocolType.Udp);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Keo";
            int a = 0;
            byte[] Send = BitConverter.GetBytes(a);
            server.SendTo(Send, (EndPoint)ipep);

            byte[] rec = new byte[20];
            server.ReceiveFrom(rec, ref remote);
            textBox2.Text = Encoding.ASCII.GetString(rec);
        }
    }
}
