using System;

namespace TaskingoApp.Exceptions
{
    public class ToManyCallsException : Exception
    {
        public ToManyCallsException(string message) : base(message)
        {

        }
    }
}
