using System.Windows;
using TaskingoApp.View;

namespace TaskingoApp.Builder
{
    public class PopupBuilder
    {
        public static void Build(string errorMessage)
        {

            Application.Current.Dispatcher.Invoke(() =>
            {
                var info = new InfoPopupView { Message = { Text = errorMessage } };
                info.Show();
            });

        }
    }
}
