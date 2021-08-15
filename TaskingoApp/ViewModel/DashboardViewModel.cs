using System.Windows.Input;
using TaskingoApp.Commands;
using TaskingoApp.View;
using WpfTestApp.ViewModel.Base;

namespace TaskingoApp.ViewModel
{
    public class DashboardViewModel : ViewModelBase
    {
        public DashboardViewModel()
        {
            ActualView = new HomeView();
        }

        private object actualView;

        public object ActualView
        {
            get => actualView;
            set
            {
                actualView = value;
                OnPropertyChanged(nameof(actualView));
            }
        }
        #region ICommand

        private ICommand setView;

        public ICommand SetView
        {
            get
            {
                if (setView == null)
                    setView = new RelayCommand(x =>
                    {
                        ChangeView(x as string);
                    });
                return setView;
            }
        }

        private void ChangeView(string viewName)
        {
            if(string.IsNullOrEmpty(viewName)) return;
            switch (viewName)
            {
                case "Users": 
                    ActualView =  new UsersView();
                    break;
                default:
                    ActualView = new HomeView();
                    break;
                   
            }

        }

        #endregion
    }
}
