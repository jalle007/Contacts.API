using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Contacts.SignalR
{
    public  class BroadcastHub : Hub
    {
        private readonly IHubContext<BroadcastHub> _hub;

        public BroadcastHub(IHubContext<BroadcastHub> hub) 
        {
            _hub = hub;
        }

        public async Task SendMessage(string message)
        {
            await _hub.Clients.All.SendAsync("ReceiveMessage", message);
        }
    }
}
 