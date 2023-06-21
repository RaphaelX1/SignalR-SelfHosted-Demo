using Microsoft.AspNetCore.SignalR.Client;

namespace SignalR_SelfHosted_Demo.Service
{
    public class MessageService
    {
        private  HubConnection _hubConnection;
        public async Task StartListener()
        {
            //TODO: Obter url do httpcontext
            _hubConnection = new HubConnectionBuilder()
              .WithUrl($"https://localhost:7282/sendmessage")
              .WithAutomaticReconnect()
              .Build();

            _hubConnection.On<string>("ReadMessageAsync", (message) =>
            {
                Console.WriteLine(message);
            });

            await _hubConnection.StartAsync();
        }

        public async Task SendAsync(string message)
        {
            await _hubConnection.SendAsync("SendMessageAsync", message);
        }
    }
}
