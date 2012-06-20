using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SignalR.Hosting.Self;

namespace TimeServer.ConsoleHost
{
    class Program
    {
        static void Main(string[] args)
        {
            var srv = new TimeHubServer();
            srv.Start();

            Console.WriteLine("Server running");
            Console.ReadLine();
            Console.WriteLine("Stopping server");

            srv.Stop();
        }
    }
}
