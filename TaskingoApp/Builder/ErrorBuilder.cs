using System.Windows;
using TaskingoApp.View;

namespace TaskingoApp.Builder
{
    public class ErrorBuilder
    {
        public static void BuildError(string errorMessage)
        {
            
            Application.Current.Dispatcher.Invoke(() =>
            {
                var error = new ErrorView { ErrorMessage = { Text = errorMessage } };
                error.Show();
            });
            
        }
    }
}
