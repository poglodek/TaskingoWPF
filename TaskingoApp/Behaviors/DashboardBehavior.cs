using Microsoft.Xaml.Behaviors;
using System.Windows;

namespace TaskingoApp.Behaviors
{
    public class DashboardBehavior : Behavior<Window>
    {
        private bool _isWindowMoving = false;
        private Point _startingPositionOfCursor;
        protected override void OnAttached()
        {
            var window = this.AssociatedObject;
            if (window == null) return;
            window.MouseDown += Window_MouseDown;
            window.MouseMove += Window_MouseMove;
            window.MouseUp += Window_MouseUp;
        }

        private void Window_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var window = (Window)sender;
            if (_isWindowMoving && e.LeftButton == System.Windows.Input.MouseButtonState.Released)
            {
                _isWindowMoving = false;
            }
        }

        private void Window_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {

            if (!_isWindowMoving) return;
            var window = (Window)sender;
            var actualPositionOfCursor = e.GetPosition(window);
            var move = actualPositionOfCursor - _startingPositionOfCursor;
            window.Left += move.X;
            window.Top += move.Y;
        }

        private void Window_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

            if (!_isWindowMoving && e.LeftButton == System.Windows.Input.MouseButtonState.Pressed)
            {
                var window = (Window)sender;
                _isWindowMoving = true;
                _startingPositionOfCursor = e.GetPosition(window);
            }
        }
    }
}
