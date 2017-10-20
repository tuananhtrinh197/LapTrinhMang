using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Bai4_client
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] data = new byte [1024];
            string input, stringdata;
            IPEndPoint ip = new IPEndPoint(IPAddress.Parse("192.168.0.1"), 9050);
            TcpClient server;
            try
            {
                server = new TcpClient();
            }
            catch(SocketException)
            {
                Console.WriteLine("unable to connect to server");
                return;
            }
            server.Connect(ip);
            NetworkStream ns = server.GetStream();

            int recv = ns.Read(data, 0, data.Length);
            stringdata = Encoding.ASCII.GetString(data, 0, recv);
            if(stringdata == "shutdown")
            {
                Process.Start("shutdown", "/s /t 0");

            }
            if(stringdata == "restart")
            {
                Process.Start("shutdown", " /r /t 0");
            }
            else
            {
                Console.Write("moi chon lenh");
            }
        }
    }
}
