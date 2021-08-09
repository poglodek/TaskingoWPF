using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskingoWPF.Core.Model
{
    public class Login
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public Login(string email, string password)
        {
            Email = password;
            Password = password;
        }
        public void Log(Login login)
        {
            var i = 0; //TODO login here
        }
    }
}
