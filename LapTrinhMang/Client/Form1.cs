using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using myStruct;
namespace Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }
        Socket client;
        IPEndPoint ipe;
        Thread ketnoi;
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            ketnoi = new Thread(new ThreadStart(KetNoiDenServer));
            ketnoi.IsBackground = true;
            ketnoi.Start();
        }
        public void KetNoiDenServer()
        {
            ipe = new IPEndPoint(IPAddress.Parse(txtIPServer.Text), 2001);
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            client.Connect(ipe);
            Thread langnghe = new Thread(LangNgheDuLieu);
            langnghe.IsBackground = true;
            langnghe.Start(client);
        }
        public void LangNgheDuLieu(Object obj)
        {
            Socket sk = (Socket)obj;
            while (true)
            {
                byte[] buff = new byte[1024];
                int recv = client.Receive(buff);
                HamMaHoa(buff);
            }
        }

        private void HamMaHoa(byte[] buff)
        {
            myStruct.Structure str = new Structure();
            MemoryStream stream = new MemoryStream(buff);
            BinaryFormatter bformat = new BinaryFormatter();
            str = (Structure)bformat.Deserialize(stream);

            
            rtbMain.AppendText(str.TextChat);
            rtbMain.ScrollToCaret();
        }

        private void lbFont_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (fontDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK) ;
            {
                rtbTextChat.Font = fontDialog1.Font;
            }
        }

        private void lbColor_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (colorDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK) ;
            {
                rtbTextChat.ForeColor = colorDialog1.Color;
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            Structure str = new Structure();
            str.TextChat = rtbTextChat.Text;
            str.MyFont = rtbTextChat.Font;
            str.MyColor = rtbTextChat.ForeColor;

            MemoryStream stream = new MemoryStream();
            BinaryFormatter bformat = new BinaryFormatter();
            bformat.Serialize(stream, str);
            byte[] buff = new byte[1024];
            buff = stream.ToArray();
            client.Send(buff);
            rtbTextChat.Text = "";
        }
    }
}
