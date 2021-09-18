using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using TaskingoApp.Services.IServices;

namespace TaskingoApp.Services.Services
{
    public class ChatServices : IChatServices
    {
        public event Action<string> ReceiveMessage;
        public static HubConnection _connection = new HubConnectionBuilder()
            .WithAutomaticReconnect()
            .WithUrl(Properties.Settings.Default.ApiUrl+"chat")
            .Build();

        public ChatServices()
        {
            _connection.On<string>("ReceiveMessage", (x) => ReceiveMessage?.Invoke(x));
        }
        public async Task Connect()
        {
            await _connection.StartAsync();
            await _connection.SendAsync("GetMyId", Properties.Settings.Default.MyId);
        }

        public async Task SendMessage(string message, int recipient)
        {
            await _connection.SendAsync("SendMessage", message, recipient);
        }
    }
}
