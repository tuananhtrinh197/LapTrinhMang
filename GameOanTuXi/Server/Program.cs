using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            int recv;
            byte[] data = new byte[4];

            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 9050);
            Socket newsock = new Socket(AddressFamily.InterNetwork,
            SocketType.Dgram, ProtocolType.Udp);
            newsock.Bind(ipep);

            Console.WriteLine("Waiting for a client...");

            IPEndPoint ipClient = new IPEndPoint(IPAddress.Any, 0);
            EndPoint Remote = (EndPoint)(ipClient);

            recv = newsock.ReceiveFrom(data, ref Remote);
            int clienChoosen = BitConverter.ToInt32(data, 0);

            Random rand = new Random();
            int serverChoosen = rand.Next(0, 2);

            if (clienChoosen == serverChoosen)
            {
                byte[] Result = Encoding.ASCII.GetBytes("Hoa");
                newsock.SendTo(Result, Remote);
            }
            if (clienChoosen < serverChoosen)
            {
                byte[] Resul = Encoding.ASCII.GetBytes("hua");
                newsock.SendTo(Resul, Remote);
            }
            else
            {
                byte[] Result = Encoding.ASCII.GetBytes("hang");
                newsock.SendTo(Result, Remote);
            }
        }
    }
}