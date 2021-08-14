using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TaskingoApp.Commands
{
    public abstract class AsyncCommandBase : ICommand
    {
        private bool isExecuting;
        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter)
        {
            return !isExecuting;
        }

        public async void Execute(object parameter)
        {
            isExecuting = true;
            await ExecuteAsync(parameter);
            isExecuting = false;
        }

        protected abstract Task ExecuteAsync(object parameter);
    }
}
