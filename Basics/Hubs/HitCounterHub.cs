using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SignalR.Hubs;

namespace BasicExamples.Hubs
{
    public class HitCounterHub
        : Hub
    {
        public int HitCount
        {
            get
            {
                if (HttpContext.Current.Cache["HitCount"] == null)
                    HttpContext.Current.Cache["HitCount"] = 0;
                return Convert.ToInt32(HttpContext.Current.Cache["HitCount"]);
            }
            set
            {
                HttpContext.Current.Cache["HitCount"] = value;
            }
        }

        public void addHit()
        {
            this.HitCount += 1;
            Clients.showHitCount(this.HitCount);
        }
    }
}