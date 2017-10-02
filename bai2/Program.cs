using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace bai2
{
    class Program
    {
      
            static void Main(string[] args)
        {
            Console.Write("Nhap ten mien hoac ip: ");
            string host = Console.ReadLine();

            IPHostEntry e = Dns.GetHostEntry(host);
            Console.WriteLine("Hostname: {0}", e.HostName);

            // In tên miền
            foreach (string s in e.Aliases)
                Console.WriteLine("\t+ Alias: {0} \n", s);

            // Danh sách điạ chỉ IP
            foreach (IPAddress i in e.AddressList)
                Console.WriteLine("\t+ IP: {0}", i);
            Console.ReadKey();
        }
    }
        
  }

