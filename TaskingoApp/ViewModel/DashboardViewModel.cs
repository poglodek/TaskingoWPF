using TaskingoApp.View;
using WpfTestApp.ViewModel.Base;

namespace TaskingoApp.ViewModel
{
    public class DashboardViewModel : ViewModelBase
    {
        public DashboardViewModel()
        {
            actualView = new UsersView();
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
    }
}
