using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using TaskingoApp.Commands;
using TaskingoApp.Model;
using TaskingoApp.Services;
using TaskingoApp.ViewModel.Base;

namespace TaskingoApp.ViewModel.Users
{
    public class EditUserViewModel : ViewModelBase
    {
        private UserModel _userModel;
        private IUsersServices _usersServices = new UsersServices();
        private IRoleServices _roleServices = new RoleServices();
        public List<string> RoleNames { get; set; }

        public EditUserViewModel()
        {
            _userModel = new UserModel();
            GetUserByApi();
        }

        private void GetUserByApi()
        {
            Task.Run(() =>
            {
                _userModel = _userModel.GetUserFromApiById().Result;
                RoleNames = _roleServices.GetRolesName();
                OnPropertyChanged(nameof(FirstName), nameof(LastName), nameof(Id), nameof(Phone), nameof(Email), nameof(Address), nameof(RoleNames), nameof(Role));
            });

        }
        #region Getters

        public int Id
        {
            get => _userModel.Id;
            set
            {
                _userModel.Id = value;
                OnPropertyChanged(nameof(Id));
            }
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
        private ICommand _editUser;

        public ICommand EditUser
        {
            get
            {
                return _editUser ?? (_editUser = new RelayCommand(x =>
                {
                    Task.Run(() =>
                    {
                        _usersServices.EditUser(Properties.Settings.Default.UserId, _userModel).Wait();
                        GetUserByApi();
                    });
                }));
            }
        }


        #endregion
    }
}
