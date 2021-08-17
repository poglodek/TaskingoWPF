using TaskingoApp.ViewModel.Base;

namespace TaskingoApp.ViewModel
{
    public class ErrorViewModel : ViewModelBase
    {
        private string _errorText;
        public string ErrorText
        {
            get => _errorText;
            set
            {
                _errorText = value;
                OnPropertyChanged(ErrorText);
            }
        }

    }
}
