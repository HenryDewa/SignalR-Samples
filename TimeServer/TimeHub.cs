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
    [HubName("serverTime")]
    public class TimeHub : Hub
    {
        public Timer Timer { get; set; }

        public void StartTimer()
        {
            Log("Client connected", ConsoleColor.Red);

            if (Timer == null)
            {
                Timer = new Timer(1000);

                Timer.Elapsed += (s, e) =>
                    {
                        var tm = DateTime.Now.ToLongTimeString();
                        Log("Sending " + tm + " to client", Console.ForegroundColor);

                        // -----------------------------
                        Caller.showTime(tm);
                        // -----------------------------
                    };

                Timer.Start();
            }
        }

        void Log(string msg, ConsoleColor color)
        {
            var c = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(msg);
            Console.ForegroundColor = c;
            Trace.WriteLine(msg);
        }
    }
}