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
using System.Threading;
using System.Net.Sockets;

namespace SerVer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }
        Socket server;
        IPEndPoint ipe;
        List<Socket> lstClient = new List<Socket>();
        string myIP = "";
        Thread xuliClient;
        public void LayIP()
        {
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress diachi in host.AddressList)
            {
                if(diachi.AddressFamily.ToString()=="InterNetwork")
                {
                    myIP = diachi.ToString();
                }
            }
            ipe = new IPEndPoint(IPAddress.Parse(myIP), 2001);
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
        }
        private void rtbMain_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LayIP();
            xuliClient = new Thread(new ThreadStart(LangNghe));
            xuliClient.IsBackground = true;
            xuliClient.Start();
        }
        public void LangNghe()
        {
            server.Bind(ipe);
            server.Listen(3);
            while (true)
            {
                Socket sk = server.Accept();
                lstClient.Add(sk);
                Thread clientProcess = new Thread(myThreadClient);
                clientProcess.IsBackground = true;
                clientProcess.Start(sk);

                
                rtbMain.AppendText("Chap Nhan ket noi tu" + sk.RemoteEndPoint.ToString());
                rtbMain.ScrollToCaret();

            }
        }
        public void myThreadClient(object obj)
        {
            Socket clientSK = (Socket)obj;
            while (true)
            {
                byte[] buff = new byte[1024];
                int recv = clientSK.Receive(buff);
                foreach(Socket sk in lstClient)
                {
                    sk.Send(buff, buff.Length, SocketFlags.None);
                }
            }
        }

        private void btnListen_Click(object sender, EventArgs e)
        {

        }

        private void rtbMain_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
