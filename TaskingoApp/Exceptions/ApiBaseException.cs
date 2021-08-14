using System;

namespace TaskingoApp.Exceptions
{
    public class ApiBaseException : Exception
    {
        public ApiBaseException(string message) : base(message)
        {

        }
    }
}
