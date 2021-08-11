using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TaskingoApp.Exceptions;
using TaskingoApp.Services;
using TaskingoApp.ViewModel;
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
            try
            {
                var loginSuccessful = await _loginServices.Login(_loginViewModel.Email, _loginViewModel.Password);
                if (loginSuccessful)
                {
                    new Dashboard().Show();
                }
            }
            catch (ApiBaseException ex)
            {
                MessageBox.Show(ex.Message, "Response", MessageBoxButton.OK);
            }
            catch (Exception ex)
            {
                //log to file
            }
            
        }
    }
    
}
