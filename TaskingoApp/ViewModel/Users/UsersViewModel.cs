using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using TaskingoApp.Components;
using TaskingoApp.Model;
using TaskingoApp.Services;
using TaskingoApp.View;
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
            if(string.IsNullOrEmpty(searchingUser))
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
    }
}
