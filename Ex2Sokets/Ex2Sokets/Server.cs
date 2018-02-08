using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Threading;
using System.IO;

namespace Ex2Sokets
{
    class Server
    {
        static bool running;
        private string wmsg = "";
        private string rmsg = "";
        static void Main(string[] args)
        {
            running = true;
            Server pr = new Server();
            pr.Run();
            
            
        }
        public void Run()
        {
            TcpListener listener = new TcpListener(IPAddress.Any, 5000);
            listener.Start();
            while (running)
            {
                Socket client = listener.AcceptSocket();
                new Thread(new ThreadStart(() => ThreadRun(client))).Start();
                //Thread clientThread = new Thread(() => ThreadRun(client));
                //clientThread.Start();
            }
        }
        public void ThreadRun(Socket client)
        {
            NetworkStream stream = new NetworkStream(client);
            StreamWriter writer = new StreamWriter(stream);
            StreamReader reader = new StreamReader(stream);
            writer.AutoFlush = true;
            writer.WriteLine("Ready!!!");
            do
            {
                rmsg = reader.ReadLine();
                if (rmsg == "time")
                {
                    wmsg = DateTime.Now.ToString("h:mm:ss tt");
                    writer.WriteLine(wmsg);
                }
                else
                {
                    wmsg = "Unknown command";
                    writer.WriteLine(wmsg);
                }

            } while (running);
            Console.ReadKey();

        }
    }
}
