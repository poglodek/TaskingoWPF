using System.Threading.Tasks;
using TaskingoApp.Model;
using TaskingoApp.ViewModel.Base;

namespace TaskingoApp.ViewModel.Users
{
    public class UserViewModel : ViewModelBase
    {
        private UserModel _userModel;

        public UserViewModel()
        {
            _userModel = new UserModel();
            if (Properties.Settings.Default.ActualView == "User")
                GetUserByApi();


        }

        private void GetUserByApi()
        {
            Task.Run(() =>
            {
                _userModel = _userModel.GetUserFromApiById().Result;
                OnPropertyChanged(nameof(FirstName), nameof(LastName), nameof(Id), nameof(Phone), nameof(Email), nameof(Address));
            });

        }
        public UserViewModel(UserModel user)
        {
            _userModel = user;
        }
        #region Getters

        public int Id => _userModel.Id;

        public string FirstName => _userModel.FirstName;

        public string LastName => _userModel.LastName;

        public string Address => _userModel.Address;

        public string Email => _userModel.Email;

        public int Phone => _userModel.Phone;

        public override string ToString()
        {
            return _userModel.ToString();
        }
        #endregion

        #region Commands



        #endregion
    }
}
