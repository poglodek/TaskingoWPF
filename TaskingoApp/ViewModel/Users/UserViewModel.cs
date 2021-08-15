using System.Windows;
using System.Windows.Input;
using TaskingoApp.Commands;
using TaskingoApp.Model;
using WpfTestApp.ViewModel.Base;

namespace TaskingoApp.ViewModel.Users
{
    public class UserViewModel : ViewModelBase
    {
        private UserModel userModel;

        public UserViewModel()
        {
            userModel = new UserModel();
        }

        public UserViewModel(UserModel user)
        {
            userModel = user;
        }
        #region Getters

        public int Id
        {
            get => userModel.Id;
        }
        public string FirstName
        {
            get => userModel.FirstName;
        }
        public string LastName
        {
            get => userModel.LastName;
        }
        public string Address
        {
            get => userModel.Address;
        }
        public string Email
        {
            get => userModel.Email;
        }
        public int Phone
        {
            get => userModel.Phone;
        }

        public override string ToString()
        {
            return userModel.ToString();
        }
        #endregion

        #region Commands

        private ICommand setView;

        public ICommand SetView
        {
            get
            {
                if (setView == null)
                    setView = new RelayCommand(x =>
                    {
                        
                       
                        //ChangeView(x as string);
                    });
                return setView;
            }
        }

        #endregion
    }
}
