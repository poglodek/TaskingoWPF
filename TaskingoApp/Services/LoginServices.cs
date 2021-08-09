using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TaskingoApp.Services
{
    public class LoginServices : ILoginServices
    {
        public async Task<bool> Login(string email, string password)
        {
            await Task.Delay(5000);
            MessageBox.Show("say hello");
            return true;
        }
    }
}
