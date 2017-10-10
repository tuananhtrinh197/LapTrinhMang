using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BaitapUDP
{
    class Program
    {
        static void Main(string[] args)
        { 
            //
       string s = "hello world";
        string k = "123";

            //3des ,128 bit key
            // bien k thanh key 128 bit
            MD5CryptoServiceProvider hash = new MD5CryptoServiceProvider();
            byte[] key = hash.ComputeHash(Encoding.ASCII.GetBytes(k));

            // tao doi tuong 3des
            TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider();
            tripDes.Key = key;
            tripDes.Mode = CipherMode.CBC;
            tripDes.Padding = PaddingMode.PKCS7;


            // ma hoa

            ICryptoTransform crypt = tripDes.CreateEncryptor();
            byte[] mess = Encoding.ASCII.GetBytes(s);
            byte[] resutl = crypt.TransformFinalBlock(mess, 0, mess.Length);

            String res = Convert.ToBase64String(resutl);
            Console.WriteLine("{ 0} duoc ma hoa thanh { 1}", s, res);

            //giai ma
/*
            ICryptoTransform decry = tripDes.CreateDecryptor();
            byte[] des = decry.TransformFinalBlock(resutl, 0, resutl.Length);
            string strDes = Encoding.ASCII.GetString(des);
            Console.WriteLine("{0} duoc giai ma thanh {1}", res, strDes);
            */
        }
    }
}
