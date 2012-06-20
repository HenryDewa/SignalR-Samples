using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SignalR.Hubs;

namespace SiteMonitor.Web.Hubs
{
    public class SiteMonitorNotificationHub : Hub
    {
        public void ReceiveMonitorUpdate(dynamic monitorUpdate)
        {
            Clients.notifySiteStatus(monitorUpdate);
        }

        public void AddSiteToGui(string url)
        {
            Clients.notifySiteAdded(url);
        }

        public void RemoveSiteFromGui(string url)
        {
            Clients.notifySiteRemoved(url);
        }

        public void AddSite(string url)
        {
            Clients.SiteAdded(url);
        }

        public void RemoveSite(string url)
        {
            Clients.SiteRemoved(url);
        }
    }
}