using System.Threading.Tasks;

namespace TaskingoApp.Services.IServices
{
    public interface ILoginServices
    {
        public Task<bool> Login(string email, string password);
        public Task ForgotPassword(string email);
    }
}