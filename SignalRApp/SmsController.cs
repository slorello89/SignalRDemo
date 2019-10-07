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
    public class SmsController : Controller
    {
        private readonly IHubContext<ChatHub> _chatHub;

        public SmsController(IHubContext<ChatHub> chatContext)
        {
            _chatHub = chatContext;
        }
        
        public IActionResult ReceiveMessage([FromQuery]SMS.SMSInbound response)
        {
            _chatHub.Clients.All.SendAsync("ReceiveMessage", response.msisdn, response.text);
            return StatusCode(204);
        }
    }
}
