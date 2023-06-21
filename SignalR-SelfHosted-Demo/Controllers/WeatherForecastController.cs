using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Client;
using SignalR_SelfHosted_Demo.Hubs;
using SignalR_SelfHosted_Demo.Service;

namespace SignalR_SelfHosted_Demo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly MessageService _messageService;
        public WeatherForecastController(MessageService messageService)
        {
            _messageService = messageService;
        }
        [HttpPost()]
        public async Task Post([FromBody] string message)
        {
            await _messageService.StartListener();
            await _messageService.SendAsync(message);
        }
    }
}