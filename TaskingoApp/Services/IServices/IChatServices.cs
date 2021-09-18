using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
