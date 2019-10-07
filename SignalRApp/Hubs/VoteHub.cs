using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace SignalRApp.Hubs
{
    public class VoteHub : Hub
    {
        public enum Fruit
        {
            other,
            bannana,
            orange,
            strawberry,
            peach,
            watermelon
        }
        public async Task ForwardVote(string fruit)
        {
            await Clients.All.SendAsync("ReceiveVote", fruit);
        }
    }
}
