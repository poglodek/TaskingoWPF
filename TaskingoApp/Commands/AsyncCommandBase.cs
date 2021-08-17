using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TaskingoApp.Commands
{
    public abstract class AsyncCommandBase : ICommand
    {
        private bool _isExecuting;
        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter)
        {
            return !_isExecuting;
        }

        public async void Execute(object parameter)
        {
            _isExecuting = true;
            await ExecuteAsync(parameter);
            _isExecuting = false;
        }

        protected abstract Task ExecuteAsync(object parameter);
    }
}
