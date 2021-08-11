using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskingoApp.View;
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
