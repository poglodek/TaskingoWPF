using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskingoApp.View;

namespace TaskingoApp.Builder
{
    public class ErrorBuilder
    {
        public static void BuildError(string errorMessage)
        {
            var error = new ErrorView {ErrorMessage = {Text = errorMessage}};
            error.Show();
        }
    }
}
