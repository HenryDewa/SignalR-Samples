using SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using System.Web;

namespace SystemMonitor.Web
{
    [HubName("randomNumber")]
    public class RandomNumberHub : Hub
    {
        Timer _timer;
        Random _rnd;

        public void init()
        {
            _rnd = new Random(42);
            _timer = new Timer();
            _timer.Interval = 1000;
            _timer.Elapsed += (s, e) => Caller.updateChart(_rnd.Next(1, 100));
            _timer.Start();
        }
    }
}