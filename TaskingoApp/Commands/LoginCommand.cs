using System;
using System.Threading.Tasks;
using TaskingoApp.Builder;
using TaskingoApp.Exceptions;
using TaskingoApp.Services;
using TaskingoApp.ViewModel;

namespace TaskingoApp.Commands
{
    public class LoginCommand : AsyncCommandBase
    {
        private readonly LoginViewModel _loginViewModel;
        private readonly ILoginServices _loginServices;
        private readonly ILogger _logger = new Logger();

        public LoginCommand(LoginViewModel loginViewModel, ILoginServices loginServices)
        {
            _loginServices = loginServices;
            _loginViewModel = loginViewModel;
        }

        protected override async Task ExecuteAsync(object parameter)
        {
            try
            {
                var loginSuccessful = await _loginServices.Login(_loginViewModel.Email, _loginViewModel.Password);
                if (loginSuccessful)
                    new DashboardView().Show();
            }
            catch (ApiBaseException ex)
            {
                ErrorBuilder.BuildError(ex.Message);
                _logger.Log("ErrorView|API", ex.Message);
            }
            catch (Exception ex)
            {
                _logger.Log("ErrorView|EX", ex.Message);
            }

        }
    }

}
