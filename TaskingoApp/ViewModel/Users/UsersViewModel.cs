using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using TaskingoApp.Commands;
using TaskingoApp.Components;
using TaskingoApp.Model;
using WpfTestApp.ViewModel.Base;

namespace TaskingoApp.ViewModel.Users
{
    public class UsersViewModel : ViewModelBase
    {
        private UsersModel usersModel;

        public AsyncObservableCollection<UserViewModel> usersViewModels { get; set; } = new AsyncObservableCollection<UserViewModel>();
        private static AsyncObservableCollection<UserViewModel> usersFromApi { get; set; } = new AsyncObservableCollection<UserViewModel>();
        public void CopyFromModel()
        {
            usersViewModels.Clear();
            usersFromApi.Clear();
            foreach (var user in usersModel)
                usersFromApi.Add(new UserViewModel(user));
            usersViewModels.AddRange(usersFromApi);

        }

        private string searchingUser;

        public string SearchingUser
        {
            get => searchingUser;
            set
            {
                searchingUser = value;
                ShowUsers();
            }
        }

        private void ShowUsers()
        {
            if (string.IsNullOrEmpty(searchingUser))
                DownloadUsers();
            var searchingUsersFromApi = usersFromApi.Where(
                x => x.FirstName.ToUpper().Contains(searchingUser.ToUpper()) || x.LastName.ToUpper().Contains(searchingUser.ToUpper())).ToList();
            usersViewModels.Clear();
            usersViewModels.AddRange(searchingUsersFromApi);
        }


        public UsersViewModel()
        {
            usersModel = new UsersModel();
            DownloadUsers();

        }
        private void DownloadUsers()
        {
            Task.Run(() =>
            {
                usersModel.GetUsersModelsList().Wait();
                CopyFromModel();
            });
        }
        private ICommand selectItem;

        public ICommand SelectItem
        {
            get
            {
                if (selectItem == null) selectItem = new RelayCommand(x =>
                {
                    if (x == null) return;
                    var selectedUserId = usersViewModels[(int)x].Id;
                    Properties.Settings.Default.UserId = selectedUserId;
                });
                return selectItem;
            }
        }
    }
}
