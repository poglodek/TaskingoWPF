using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TaskingoApp;
using TaskingoApp.Commands;
using TaskingoApp.Model;
using TaskingoApp.Services;
using WpfTestApp.ViewModel.Base;

namespace TaskingoWPF.Core.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        private Login login = new Login();

        
        public LoginViewModel()
        {
            LoginCommand = new LoginCommand(this, new LoginServices());
        }
        public string Email
        {
            get => login.Email;
            set
            {
                login.Email = value;
                OnPropertyChanged(nameof(Email));
            }
        } 

        public string Password
        {
            get => login.Password;
            set
            {
                login.Password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        public ICommand LoginCommand { get; }

        

        private bool IsEmailValid(string email)
        {
            try
            {
                var mail = new MailAddress(email);
                if (email.Length > 5) return true;
                return false;
            }
            catch
            {
                return false;
            }
        }
    }

}
