using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskingoApp.Services;
using TaskingoWPF.Core.ViewModel;

namespace TaskingoApp.Commands
{
    public class LoginCommand : AsyncCommandBase
    {
        private readonly LoginViewModel _loginViewModel;
        private readonly ILoginServices _loginServices;

        public LoginCommand(LoginViewModel loginViewModel, ILoginServices loginServices)
        {
            _loginServices = loginServices;
            _loginViewModel = loginViewModel;
        }

        protected override async Task ExecuteAsync(object? parameter)
        {
            var gac = await _loginServices.Login(_loginViewModel.Email, _loginViewModel.Password);
            if (gac)
            {
                new Dashboard().Show();
            }
        }
    }
    }
}
