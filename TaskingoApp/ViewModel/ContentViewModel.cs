using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TaskingoApp.Commands;
using TaskingoApp.Services;
using TaskingoApp.View;
using TaskingoApp.ViewModel.Base;

namespace TaskingoApp.ViewModel
{
    public class ContentViewModel : ViewModelBase
    {
        private readonly IUsersServices _usersServices = new UsersServices();
        public ContentViewModel()
        {
            StartUpView();

        }

        public bool Users { get; set; }
        public bool AddUsers { get; set; }
        public bool EditUsers { get; set; }
        public bool Tasks { get; set; }


        private void StartUpView()
        {
            HideTools();
            var viewName = Properties.Settings.Default.ActualView;
            switch (viewName)
            {
                case "Users":
                    View = new UsersView();
                    Users = true;
                    OnPropertyChanged(nameof(Users));
                    break;
                case "User":
                    View = new UserView();
                    Users = true;
                    OnPropertyChanged(nameof(Users));
                    break;
                case "AddUser":
                    View = new AddUserView();
                    AddUsers = true;
                    OnPropertyChanged(nameof(AddUsers));
                    break;
                case "EditUser":
                    View = new EditUserView();
                    EditUsers = true;
                    OnPropertyChanged(nameof(EditUsers));
                    break;
                default:
                    View = new HomeView();
                    OnPropertyChanged(nameof(View));
                    break;

            }
        }
        private void HideTools()
        {
            Users = false;
            Tasks = false;
            EditUsers = false;
            AddUsers = false;
            OnPropertyChanged(nameof(Users), nameof(Tasks), nameof(AddUsers), nameof(EditUsers));
        }
        private ICommand _setActualView;

        public ICommand SetActualView
        {
            get
            {
                return _setActualView ?? (_setActualView = new RelayCommand(x =>
                {
                    if (x == null) return;
                    ChangeActualView(x as string);
                }));
            }
        }
        private ICommand _deleteUser;

        public ICommand DeleteUser
        {
            get
            {
                return _deleteUser ?? (_deleteUser = new RelayCommand(x =>
                {
                    Task.Run(() =>
                    {
                        if (_usersServices.DeleteUserById(Properties.Settings.Default.UserId).Result)
                        {
                            Application.Current.Dispatcher.Invoke(() =>
                            {
                                ChangeActualView("Users");
                            });
                        }
                    });
                }, x => Properties.Settings.Default.UserId > -1 ));
            }
        }

        public void ChangeActualView(string viewName)
        {
            if (viewName == "User" && Properties.Settings.Default.UserId < 0 ||
                viewName == "EditUser" && Properties.Settings.Default.UserId < 0 ||
                viewName == "Task" && Properties.Settings.Default.TaskId < 0) 
                return;
            TaskingoApp.Properties.Settings.Default.ActualView = viewName;
            StartUpView();
        }




    }
}
