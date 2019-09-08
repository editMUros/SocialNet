using Microsoft.AspNetCore.SignalR;
using SocialNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNet.Data.Hubs
{
    public class ChatHub : Hub
    {
        public async Task sendMessage(Message message) =>
            await Clients.All.SendAsync("receiveMessage", message);
    }
}
