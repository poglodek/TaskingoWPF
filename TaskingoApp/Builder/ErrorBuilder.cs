﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskingoApp.View;

namespace TaskingoApp.Builder
{
    public class ErrorBuilder
    {
        public static void ShowError(string errorMessage)
        {
            var error = new Error {ErrorMessage = {Text = errorMessage}};
            error.Show();
        }
    }
}
