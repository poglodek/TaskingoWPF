using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using TaskingoApp.Commands;
using TaskingoApp.Components;
using TaskingoApp.Model;
using TaskingoApp.ViewModel.Base;

namespace TaskingoApp.ViewModel.Users
{
    public class UsersViewModel : ViewModelBase
    {
        private UsersModel _usersModel;

        public AsyncObservableCollection<UserViewModel> UsersViewModels { get; set; } = new AsyncObservableCollection<UserViewModel>();
        private static AsyncObservableCollection<UserViewModel> UsersFromApi { get; set; } = new AsyncObservableCollection<UserViewModel>();
        public void CopyFromModel()
        {
            UsersViewModels.Clear();
            UsersFromApi.Clear();
            foreach (var user in _usersModel)
                UsersFromApi.Add(new UserViewModel(user));
            UsersViewModels.AddRange(UsersFromApi);

        }

        private string _searchingUser;

        public string SearchingUser
        {
            get => _searchingUser;
            set
            {
                _searchingUser = value;
                ShowUsers();
            }
        }

        private void ShowUsers()
        {
            if (string.IsNullOrEmpty(_searchingUser))
                DownloadUsers();
            var searchingUsersFromApi = UsersFromApi.Where(
                x => x.FirstName.ToUpper().Contains(_searchingUser.ToUpper()) || x.LastName.ToUpper().Contains(_searchingUser.ToUpper())).ToList();
            UsersViewModels.Clear();
            UsersViewModels.AddRange(searchingUsersFromApi);
        }


        public UsersViewModel()
        {
            _usersModel = new UsersModel();
            DownloadUsers();

        }
        private void DownloadUsers()
        {
            Task.Run(() =>
            {
                _usersModel.GetUsersModelsList().Wait();
                CopyFromModel();
            });
        }
        private ICommand _selectItem;

        public ICommand SelectItem
        {
            get
            {
                return _selectItem ?? (_selectItem = new RelayCommand(x =>
                {
                    if (x == null || ((int)x) > 0) return;
                    var selectedUserId = UsersViewModels[(int)x].Id;
                    Properties.Settings.Default.UserId = selectedUserId;
                }));
            }
        }
    }
}
