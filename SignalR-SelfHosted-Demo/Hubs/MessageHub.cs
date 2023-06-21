using Microsoft.AspNetCore.SignalR;

namespace SignalR_SelfHosted_Demo.Hubs
{
    public class MessageHub : Hub
    {
        public async Task SendMessageAsync(string message)
        {
            await Clients.All.SendAsync("ReadMessageAsync", message);
        }
    }
}
