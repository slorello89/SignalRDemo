using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Nexmo.Api;
using SignalRApp.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRApp
{
    public class VoteController : Controller
    {
        private readonly IHubContext<ChatHub> _chatHub;

        public VoteController(IHubContext<ChatHub> chatContext)
        {
            _chatHub = chatContext;
        }
        
        public IActionResult CastVote([FromQuery]SMS.SMSInbound response)
        {
            _chatHub.Clients.All.SendAsync("ReceiveMessage", response.msisdn, response.text);
            return StatusCode(204);
        }
    }
}
