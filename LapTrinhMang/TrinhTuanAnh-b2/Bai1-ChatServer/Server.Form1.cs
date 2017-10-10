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

namespace Bai1_ChatServer
{
    public partial class Form1 : Form
    {
        private Socket server;

        public object client { get; private set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //truoc khi Bind phai co IPEndpoit
            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 12345);
            //sau do Bind
            server.Bind(ipep);
            // va listen ,so socket toi da o day la 1
            server.Listen(10);
            client = server.Accept();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            byte[] data = Encoding.ASCII.GetBytes(textBox2.Text);
            client.Send(data);
            listBox1.Items.Add("server:" + textBox2.Text);
            textBox2.Text = "";


            // khoi tao moi data de khong bi loi
            data = new byte[1024];
            client.Recieve(data);
            listBox1.Items.Add("Client :" + Encoding.ASCII.GetString(data));
        }
    }
    }




