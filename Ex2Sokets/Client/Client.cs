using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.IO;

namespace Client
{
    class Program
    {
        private string rmsg = "";
        private string wmsg = "";
        static void Main(string[] args)
        {
            Program Client = new Program();
            Client.Run();
        }

        private void Run()
        {
            TcpClient client = new TcpClient("localhost", 5000);
            NetworkStream stream = client.GetStream();
            StreamReader read = new StreamReader(stream);
            StreamWriter write = new StreamWriter(stream);
            write.AutoFlush = true;

            do
            {
                rmsg = read.ReadLine();
                Console.WriteLine("Server: " + rmsg);
                wmsg = Console.ReadLine();
                write.WriteLine(wmsg);

            }
            while (wmsg != "exit");
            Console.ReadKey();
        }
        
        
        
    }
    
}