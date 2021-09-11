using System.Net.Http;
using System.Threading.Tasks;
using TaskingoApp.APICall;
using TaskingoApp.Model;

namespace TaskingoApp.Services
{
    public class LoginServices : ILoginServices
    {
        public async Task<bool> Login(string email, string password)
        {
            var login = new LoginModel
            {
                Email = email,
                PasswordHashed = password
            };
            var token = await BaseCall.MakeCall("User/Login", HttpMethod.Post, login);
            if (string.IsNullOrEmpty(token)) return false;
            BaseCall.Token = token;
            return true;
        }

        public async Task ForgotPassword(string email)
        {
            await BaseCall.MakeCall($"user/ForgotPassword?email={email}", HttpMethod.Post, null);
        }
    }
}
