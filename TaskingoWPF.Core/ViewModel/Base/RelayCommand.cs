using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfTestApp.ViewModel.Base
{
    public class RelayCommand : ICommand
    {
        private Action<object> _Execute;
        private Func<object, bool> _CanExecute;

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this._Execute = execute ?? throw new ArgumentNullException("Null Execute");
            this._CanExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            if (_CanExecute == null) return true;
            return _CanExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _Execute(parameter);
        }

        public event EventHandler? CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }
}
