using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTestApp.ViewModel.Base
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(params string[] nameProperty)
        {
            foreach (var property in nameProperty)
                if (property != null) PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));


        }
    }
}
