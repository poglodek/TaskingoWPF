using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskingoApp.Model.Chat;
using TaskingoApp.Model.User;

namespace TaskingoApp.Services.IServices
{
    public interface IChatServices
    {
        event Action<MessageModel> ReceiveMessage;
        Task Connect();
        Task SendMessage(string message, int recipient);
        Task<List<UserModel>> GetLastUsers();
        Task<List<MessageModel>> GetMessages(int skip);
    }
}
