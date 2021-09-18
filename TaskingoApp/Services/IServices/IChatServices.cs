using System;
using System.Threading.Tasks;

namespace TaskingoApp.Services.IServices
{
    public interface IChatServices
    {
        event Action<string> ReceiveMessage;
        Task Connect();
        Task SendMessage(string message, int recipient);
    }
}