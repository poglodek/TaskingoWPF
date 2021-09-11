using System.Threading.Tasks;
using TaskingoApp.APICall;

namespace TaskingoApp.Services
{
    public class DashboardServices : IDashboardServices
    {
        public async Task<string> GetMyName()
        {
            var name = await BaseCall.MakeCall("User/GetMyName", System.Net.Http.HttpMethod.Get, null);
            return name;
        }
    }
}
