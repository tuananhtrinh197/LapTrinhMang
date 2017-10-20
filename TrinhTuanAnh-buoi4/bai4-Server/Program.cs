using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace bai4_Server
{
    class Program
    {
        static void Main(string[] args)
        {
            int rect;
            byte[] data = new byte[1024];

            TcpListener server = new TcpListener(9050);
            server.Start();

            Console.WriteLine("wait for a client ....");
            TcpClient client = server.AcceptTcpClient();
            NetworkStream ns = client.GetStream();

            Console.Write("chon lenh : ");
            string cmd = Console.ReadLine();
            data = Encoding.ASCII.GetBytes(cmd);
            ns.Write(data, 0, data.Length);

        }
    }
}
