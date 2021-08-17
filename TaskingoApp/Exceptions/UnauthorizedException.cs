namespace TaskingoApp.Exceptions
{
    public class UnauthorizedException : ApiBaseException
    {
        public UnauthorizedException(string message) : base(message)
        {

        }

    }
}
