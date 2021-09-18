using System.Threading.Tasks;

namespace TaskingoApp.Services.IServices
{
    public interface IDashboardServices
    {
        Task<string> GetMyName();
        Task GetMyId();
        Task ConnectWithApi();
    }
}