using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TaskingoApp.Builder;
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
            Properties.Settings.Default.MonthOfTasks = DateTime.Now.ToString("MM/yyyy");
        }

        public string TaskFilter
        {
            get => Properties.Settings.Default.TaskFilter;
            set
            {
                Properties.Settings.Default.TaskFilter = value.Substring(38);
                OnPropertyChanged(nameof(TaskFilter));
                StartUpView();
            }
        }

        public string MonthOfTasks
        {
            get => Properties.Settings.Default.MonthOfTasks;
            set
            {
                var dateTime =DateTime.Parse( value);
                Properties.Settings.Default.MonthOfTasks = dateTime.ToString("MM/yyyy");
                OnPropertyChanged(nameof(MonthOfTasks));
            }
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
                case "Tasks":
                    View = new TasksView();
                    Tasks = true;
                    OnPropertyChanged(nameof(Tasks));
                    break;
                case "Task":
                    View = new TaskView();
                    Tasks = true;
                    OnPropertyChanged(nameof(Tasks));
                    break;
                case "EditTask":
                    View = new EditTaskView();
                    Tasks = true;
                    OnPropertyChanged(nameof(Tasks));
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
        private ICommand _showUsersTasks;
        public ICommand ShowUsersTasks
        {
            get
            {
                return _showUsersTasks ?? (_showUsersTasks = new RelayCommand(x =>
                {
                    PopupBuilder.Build("Go to page with Tasks. Type email in searching TextBox on top. :)");
                }));
            }
        }

        public void ChangeActualView(string viewName)
        {
            if (viewName == "User" && Properties.Settings.Default.UserId < 0 ||
                viewName == "EditUser" && Properties.Settings.Default.UserId < 0 ||
                viewName == "EditTask" && Properties.Settings.Default.TaskId < 0 ||
                viewName == "Task" && Properties.Settings.Default.TaskId < 0) 
                return;
            TaskingoApp.Properties.Settings.Default.ActualView = viewName;
            StartUpView();
        }




    }
}
