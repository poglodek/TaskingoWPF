using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using TaskingoApp.Components;
using TaskingoApp.Model;
using WpfTestApp.ViewModel.Base;

namespace TaskingoApp.ViewModel.Users
{
    public class UsersViewModel : ViewModelBase
    {
        private UsersModel usersModel;

        public AsyncObservableCollection<UserViewModel> usersViewModels { get; set; } = new AsyncObservableCollection<UserViewModel>();

        public void CopyFromModel()
        {
            usersViewModels.Clear();
            foreach (var user in usersModel)
                usersViewModels.Add(new UserViewModel(user));

        }

        public UsersViewModel()
        {
            usersModel = new UsersModel();

            Task.Run(() =>
            {
                usersModel.GetUsersModelsList().Wait();
                CopyFromModel();
            });


        }
    }
}
