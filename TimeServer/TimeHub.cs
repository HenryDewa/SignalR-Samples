using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Timers;
using SignalR;
using SignalR.Hubs;

namespace TimeServer
{
    public class TimeHub : Hub
    {
        public Timer Timer { get; set; }

        public void StartTimer()
        {
            Log("Client connected");

            if (Timer == null)
            {
                Timer = new Timer(1000);

                Timer.Elapsed += (s, e) =>
                    {
                        var tm = DateTime.Now.ToLongTimeString();
                        Log("Sending " + tm + " to client");

                        // -----------------------------
                        Clients.showTime(tm);
                        // -----------------------------
                    };

                Timer.Start();
            }
        }

        void Log(string msg)
        {
            Console.WriteLine(msg);
            Trace.WriteLine(msg);
        }
    }
}