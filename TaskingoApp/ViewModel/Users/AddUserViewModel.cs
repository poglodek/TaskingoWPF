using System.Threading.Tasks;
using TaskingoApp.Model;
using TaskingoApp.ViewModel.Base;

namespace TaskingoApp.ViewModel.Users
{
    public class AddUserViewModel : ViewModelBase
    {
        private UserModel _userModel;

        public AddUserViewModel()
        {
            _userModel = new UserModel();
        }

        public AddUserViewModel(UserModel user)
        {
            _userModel = user;
        }
        #region Getters

        public string FirstName
        {
            get => _userModel.FirstName;
            set
            {
                _userModel.FirstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        } 

        public string LastName
        {
            get => _userModel.LastName;
            set
            {
                _userModel.LastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }

        public string Address
        {
            get => _userModel.Address;
            set
            {
                _userModel.Address = value;
                OnPropertyChanged(nameof(Address));
            }
        }

        public string Email
        {
            get => _userModel.Email;
            set
            {
                _userModel.Email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        public int Phone
        {
            get => _userModel.Phone;
            set
            {
                _userModel.Phone = value;
                OnPropertyChanged(nameof(Phone));
            }
        }

        public override string ToString()
        {
            return _userModel.ToString();
        }
        #endregion

        #region Commands



        #endregion
    }
}
