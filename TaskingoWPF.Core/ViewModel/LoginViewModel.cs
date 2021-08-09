using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TaskingoWPF.Core.Model;
using WpfTestApp.ViewModel.Base;

namespace TaskingoWPF.Core.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        private Login login;

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
        private ICommand loginInTo;

        public ICommand LoginInTo
        {
            get
            {
                if (loginInTo == null) loginInTo = new RelayCommand(x =>
                {
                    login.Log(x as Login);
                }, x => Email.Length > 5 && Password.Length > 5);
                return loginInTo;
            }
        }
    }

}
