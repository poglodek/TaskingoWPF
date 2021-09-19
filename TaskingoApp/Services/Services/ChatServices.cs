using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using Newtonsoft.Json;
using TaskingoApp.APICall;
using TaskingoApp.Model.Chat;
using TaskingoApp.Model.User;
using TaskingoApp.Services.IServices;

namespace TaskingoApp.Services.Services
{
    public class ChatServices : IChatServices
    {
        public event Action<MessageModel> ReceiveMessage;
        public static HubConnection _connection = new HubConnectionBuilder()
            .WithAutomaticReconnect()
            .WithUrl(Properties.Settings.Default.ApiUrl+"chat")
            .Build();

        public ChatServices()
        {
            _connection.On<MessageModel>("ReceiveMessage",(x) => ReceiveMessage?.Invoke(x));
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

        public async Task<List<UserModel>> GetLastUsers()
        {
            var jsonUser = await BaseCall.MakeCall($"Message/LastUsers", System.Net.Http.HttpMethod.Get, null);
            var user = JsonConvert.DeserializeObject<List<UserModel>>(jsonUser);
            return user;
        }
        public async Task<List<MessageModel>> GetMessages(int skip)
        {
            var jsonMessages = await BaseCall.MakeCall($"Message/{Properties.Settings.Default.UserId}/{skip}", System.Net.Http.HttpMethod.Get, null);
            var messages = JsonConvert.DeserializeObject<List<MessageModel>>(jsonMessages);
            messages.Reverse();
            return messages;
        }
    }
}
