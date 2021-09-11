using System.Threading.Tasks;

namespace TaskingoApp.Services
{
    public interface IDashboardServices
    {
        Task<string> GetMyName();
    }
}