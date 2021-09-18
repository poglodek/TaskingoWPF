using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using TaskingoApp.Commands;
using TaskingoApp.Model.User;
using TaskingoApp.Services;
using TaskingoApp.Services.IServices;
using TaskingoApp.Services.Services;
using TaskingoApp.ViewModel.Base;

namespace TaskingoApp.ViewModel.Users
{
    public class AddUserViewModel : ViewModelBase
    {
        private readonly UserCreateModel _userModel;
        private IUsersServices _usersServices = new UsersServices();
        private IRoleServices _roleServices = new RoleServices();
        public List<string> RoleNames { get; set; }
        public AddUserViewModel()
        {
            _userModel = new UserCreateModel();
            GetRoleByApi();
        }

        #region Getters

        private void GetRoleByApi()
        {
            Task.Run(() =>
            {
                RoleNames = _roleServices.GetRolesName().Result;
                OnPropertyChanged(nameof(RoleNames));
            });

        }
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
        public string Role
        {
            get => _userModel.Role;
            set
            {
                _userModel.Role = value;
                OnPropertyChanged(nameof(Role));
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
        private ICommand _addNewUser;

        public ICommand AddNewUser
        {
            get
            {
                return _addNewUser ?? (_addNewUser = new RelayCommand(x =>
                {
                    Task.Run(() =>
                    {
                        var respone = _usersServices.AddNewUser(_userModel).Result;
                        if (!respone) return;
                        ClearForm();
                    });

                }));
            }
        }

        private void ClearForm()
        {
            FirstName = "";
            LastName = "";
            Address = "";
            Email = "";
            Phone = 0;
        }

        #endregion
    }
}
