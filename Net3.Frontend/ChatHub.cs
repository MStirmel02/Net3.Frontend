using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI.WebControls;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace Net3.Frontend
{
    [HubName("chatHub")]
    public class ChatHub : Hub
    {
        
        public Task JoinRoom(string room)
        {
            return Groups.Add(Context.ConnectionId, room);
        }

        public Task LeaveRoom(string room)
        {
            return Groups.Remove(Context.ConnectionId, room);
        }

        public async Task SendMessage(string room, string message)
        {
            await Clients.Group(room).Send("ReceiveMessage", message);
        }
    }
}