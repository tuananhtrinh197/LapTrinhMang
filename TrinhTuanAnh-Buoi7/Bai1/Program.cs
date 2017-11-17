using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bai1
{
   
        
            class Server
        {
            static Socket listen;
            static Socket client;
            static IPEndPoint ipe;
            static int connections = 0;
            public static void Main()
            {
                listen = new Socket(AddressFamily.InterNetwork, SocketType.Stream,
                ProtocolType.Tcp);
                ipe = new IPEndPoint(IPAddress.Any, 9050);
                listen.Bind(ipe);
                listen.Listen(10);
                Console.WriteLine("Waiting for clients...");
                while (true)
                {
                    if (listen.Poll(1000000, SelectMode.SelectRead))
                    {
                        client = listen.Accept();
                        Thread newthread = new Thread(new ThreadStart(HandleConnection));
                        newthread.Start();
                    }
                }
            }
            static void HandleConnection()
            {
                int recv;
                byte[] data = new byte[1024];
                NetworkStream ns = new NetworkStream(client);
                connections++;
                Console.WriteLine("New client accepted: {0} active connections",
                connections);
                string welcome = "Welcome to my test server";
                data = Encoding.ASCII.GetBytes(welcome); ns.Write(data, 0, data.Length);
                while (true)
                {
                    data = new byte[1024];
                    recv = ns.Read(data, 0, data.Length);
                    if (recv == 0)
                        break;
                    ns.Write(data, 0, recv);
                }
                ns.Close();
                client.Close();
                connections--;
                Console.WriteLine("Client disconnected: {0} active connections",
                connections);
            }
        }
    }
    

