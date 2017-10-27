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

namespace Client
{
    public partial class Client : Form
    {
        public Socket client { get; private set; }

        public Client()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 12345);


        }

        private void button4_Click(object sender, EventArgs e)
        {
            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 12345);
            client.Connect(ipep);
            byte[] data;
            data = new byte[1024];
            client.Receive(data);
            listBox1.Items.Add("Server :" + Encoding.ASCII.GetString(data));

        }

        private void button5_Click(object sender, EventArgs e)
        {
            byte[] data;
            data = Encoding.ASCII.GetBytes(textBox2.Text);
            client.Send(data);
            listBox1.Items.Add("Client:" + textBox2.Text);
            data = new byte[1024];
            client.Receive(data);
            listBox1.Items.Add("Sever :" + Encoding.ASCII.GetString(data));
        }
    }
    }

