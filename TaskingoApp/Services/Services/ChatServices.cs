using Microsoft.AspNetCore.SignalR.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskingoApp.APICall;
using TaskingoApp.Model.Chat;
using TaskingoApp.Model.User;
using TaskingoApp.Services.IServices;

namespace TaskingoApp.Services.Services
{
    public class ChatServices : IChatServices
    {
        public event Action<MessageModel> ReceiveMessage;
        public static HubConnection Connection = new HubConnectionBuilder()
            .WithAutomaticReconnect()
            .WithUrl(Properties.Settings.Default.ApiUrl + "chat")
            .Build();

        public ChatServices()
        {
            Connection.On<MessageModel>("ReceiveMessage", (x) => ReceiveMessage?.Invoke(x));
        }
        public async Task Connect()
        {
            await Connection.StartAsync();
            await Connection.SendAsync("GetMyId", Properties.Settings.Default.MyId);
        }

        public async Task SendMessage(string message, int recipient)
        {
            await Connection.SendAsync("SendMessage", message, recipient);
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
