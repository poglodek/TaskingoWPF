using WpfTestApp.ViewModel.Base;

namespace TaskingoApp.ViewModel
{
    public class ErrorViewModel : ViewModelBase
    {
        private string errorText;
        public string ErrorText
        {
            get => errorText;
            set
            {
                errorText = value;
                OnPropertyChanged(ErrorText);
            }
        }

    }
}
