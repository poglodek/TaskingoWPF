using System.Threading.Tasks;

namespace TaskingoApp.Services
{
    public interface ILoginServices
    {
        public Task<bool> Login(string email, string password);
        public Task ForgotPassword(string email);
    }
}