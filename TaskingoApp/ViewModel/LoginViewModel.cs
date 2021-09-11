using System.Net.Mail;
using System.Windows.Input;
using TaskingoApp.Commands;
using TaskingoApp.Model;
using TaskingoApp.Services;
using TaskingoApp.ViewModel.Base;

namespace TaskingoApp.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        private readonly LoginModel _loginModel = new LoginModel();


        public LoginViewModel()
        {
            LoginCommand = new LoginCommand(this, new LoginServices());
        }
        public string Email
        {
            get => _loginModel.Email;
            set
            {
                _loginModel.Email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        public string Password
        {
            get => _loginModel.PasswordHashed;
            set
            {
                _loginModel.PasswordHashed = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        public ICommand LoginCommand { get; }



        private bool IsEmailValid(string email)
        {
            try
            {
                var mail = new MailAddress(email);
                return email.Length > 5;
            }
            catch
            {
                return false;
            }
        }
    }

}
