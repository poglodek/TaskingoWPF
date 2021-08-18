using System.Windows.Input;
using TaskingoApp.Commands;
using TaskingoApp.View;
using TaskingoApp.ViewModel.Base;

namespace TaskingoApp.ViewModel
{
    public class DashboardViewModel : ViewModelBase
    {
        public DashboardViewModel()
        {
            View = new ContentView();
        }



        #region ICommand

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
