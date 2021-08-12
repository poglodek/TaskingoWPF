using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
                Password = password
            };
            var token = await BaseCall.MakeCall("login", HttpMethod.Post, login);
            if (string.IsNullOrEmpty(token)) return false;
            BaseCall.Token = token;
            return true;
        }
    }
}
