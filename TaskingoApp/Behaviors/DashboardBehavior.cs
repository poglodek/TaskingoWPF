using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Xaml.Behaviors;

namespace TaskingoApp.Behaviors
{
    public class DashboardBehavior : Behavior<Window>
    {
        private bool IsWindowMoving = false;
        private Point StartingPositionOfCursor;
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
            if (IsWindowMoving && e.LeftButton == System.Windows.Input.MouseButtonState.Released)
            {
                IsWindowMoving = false;
            }
        }

        private void Window_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            
            if (IsWindowMoving)
            {
                var window = (Window)sender;
                var actualPositionOfCursor = e.GetPosition(window);
                var move = actualPositionOfCursor - StartingPositionOfCursor;
                window.Left += move.X;
                window.Top += move.Y;
            }
        }

        private void Window_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
           
            if (!IsWindowMoving && e.LeftButton == System.Windows.Input.MouseButtonState.Pressed)
            {
                var window = (Window)sender;
                IsWindowMoving = true;
                StartingPositionOfCursor = e.GetPosition(window);
            }
        }
    }
}
