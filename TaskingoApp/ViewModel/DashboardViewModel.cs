using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TaskingoApp.Commands;
using TaskingoApp.Services;
using TaskingoApp.View;
using TaskingoApp.ViewModel.Base;

namespace TaskingoApp.ViewModel
{
    public class DashboardViewModel : ViewModelBase
    {
        private readonly IDashboardServices _dashboardServices = new DashboardServices();
        public DashboardViewModel()
        {
            View = new ContentView();
            Task.Run(() =>
            {
                var nameFromApi = _dashboardServices.GetMyName().Result;
                Application.Current.Dispatcher.Invoke(() =>
                {
                    Name = nameFromApi;
                });
            });
            var loginScreen = Application.Current.Windows[0];
            loginScreen.Close();

        }

        private string name;
        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged(nameof(name));
            }
        }

        #region Commands

        private ICommand _setView;

        public ICommand SetView
        {
            get
            {
                return _setView ?? (_setView = new RelayCommand(x => { ChangeView(x as string); }));
            }
        }

        public void ChangeView(string viewName)
        {
            TaskingoApp.Properties.Settings.Default.ActualView = viewName;
            View = new ContentView();
        }


        #endregion
    }
}
