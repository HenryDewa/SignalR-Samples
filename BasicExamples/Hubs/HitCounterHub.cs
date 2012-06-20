using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SignalR.Hubs;

namespace BasicExamples.Hubs
{
    [HubName("hitCounter")]
    public class HitCounterHub : Hub
    {
        static int _hitCount;

        public void addHit()
        {
            _hitCount += 1;
            Clients.showHitCount(_hitCount);
        }
    }
}