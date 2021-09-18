using System.Threading.Tasks;
using TaskingoApp.APICall;
using TaskingoApp.Services.IServices;

namespace TaskingoApp.Services.Services
{
    public class DashboardServices : IDashboardServices
    {
        private readonly IChatServices _chatServices = new ChatServices();
        public async Task<string> GetMyName()
        {
            var name = await BaseCall.MakeCall("User/GetMyName", System.Net.Http.HttpMethod.Get, null);
            return name;
        }
        public async Task GetMyId()
        {
            var id = await BaseCall.MakeCall("User/GetMyId", System.Net.Http.HttpMethod.Get, null);
            Properties.Settings.Default.MyId = int.Parse(id);
        }

        public async Task ConnectWithApi()
        {
            await _chatServices.Connect();
        }
    }
}
