using System.Windows.Input;
using TaskingoApp.Commands;
using TaskingoApp.View;
using WpfTestApp.ViewModel.Base;

namespace TaskingoApp.ViewModel
{
    public class ContentViewModel : ViewModelBase
    {
        public ContentViewModel()
        {
            StartUpView();

        }


        public bool Users { get; set; }
        public bool Tasks { get; set; }


        private void StartUpView()
        {
            var viewName = Properties.Settings.Default.ActualView;
            switch (viewName)
            {
                case "Users":
                    View = new UsersView();
                    Users = true;
                    OnPropertyChanged(nameof(View));
                    break;
                case "User":
                    View = new UserView();
                    Users = true;
                    OnPropertyChanged(nameof(View));
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
        }
        private ICommand setActualView;

        public ICommand SetActualView
        {
            get
            {
                if (setActualView == null)
                    setActualView = new RelayCommand(x =>
                    {
                        if (x == null) return;
                        ChangeActualView(x as string);
                    });
                return setActualView;
            }
        }

        public void ChangeActualView(string viewName)
        {
            if (viewName == "User" && Properties.Settings.Default.UserId < 0 ||
                viewName == "Task" && Properties.Settings.Default.TaskId < 0) return;
            TaskingoApp.Properties.Settings.Default.ActualView = viewName;
            StartUpView();
        }

    }
}
