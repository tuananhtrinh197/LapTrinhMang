using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TestTCP_UDP
{
    class Program
    {
        static void Main(string[] args)
        {
            string IPAdress;
            int port;
            string protocol;
            
            Console.Write("nhap host ip: ");
            IPAdress = Console.ReadLine();
            Console.Write("Nhap port : ");
            port = Convert.ToInt32(Console.ReadLine());
            Console.Write("nhap protocol : ");
            protocol = Console.ReadLine();

            switch(protocol)
            {
                case "TCP":

                    IPEndPoint ip = new IPEndPoint(IPAddress.Parse(IPAdress), port);
                    TcpClient client = new TcpClient();
                    try
                    {
                        client.Connect(ip);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("host: { 0}:{ 1} is close ", IPAdress, port);
                        Console.WriteLine(ex);
                        Environment.Exit(0);

                    }
                    Console.WriteLine("host: {0}:{1} is open", IPAdress, port);
                    break;
                case "UDP":
                    break;
            }

        }
    }
}
