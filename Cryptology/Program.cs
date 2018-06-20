using Cryptology.Historical;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Cryptology
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("message.txt");
            var message = sr.ReadToEnd();
            sr.Close();
            string encrypted = PolybiusSquare.Encrypt(message);
            string decrypted = PolybiusSquare.Decrypt(encrypted);

            StreamWriter sw = new StreamWriter("output.txt");
            sw.WriteLine(decrypted);
            sw.Close();
            System.Console.WriteLine((int)Math.Sqrt(120) + 1);
           // Console.WriteLine(encrypted);
        }
    }
}
