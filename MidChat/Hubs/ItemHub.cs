using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MidChat.Hubs
{
    public class ItemHub : Hub
    {
        public async override Task OnConnectedAsync()
        {
            await Clients.Caller.SendAsync("OnConnected", Context.ConnectionId);
        }

        public async Task ConnectGroup(string itemId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, itemId.ToString());
        }
    }
}
