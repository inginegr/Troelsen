using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Security.Cryptography;


namespace TempConsole
{
    class Program
    {
        
        static void Main(string[] args)
        {
            string data = "Hello crypto";

            LocalCryptography lc = new LocalCryptography();

            SymmetricAlgorithm sa = SymmetricAlgorithm.Create();

            byte[] key = lc.GenerateRandomKey(16);

            byte[] iv = lc.GenerateRandomKey(16);

            byte[] b = lc.EncriptData(data, key, iv);

            Console.WriteLine(b);

            string s = lc.DecriptData(b, key, iv);

            Console.WriteLine(s);


            Console.ReadLine();
        }
    }
}