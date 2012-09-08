using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SignalR.Hubs;


namespace SkeletonTrackingClient
{
    [HubName("moveShape")]
    public class MoveShapeHub : Hub
    {
        public void MoveShape(dynamic rightHand, dynamic leftHand)
        {
            Clients.shapeMoved(Context.ConnectionId, rightHand, leftHand);
        }
    }
}