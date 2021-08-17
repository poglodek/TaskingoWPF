namespace TaskingoApp.Exceptions
{
    public class ForbiddenException : ApiBaseException
    {
        public ForbiddenException(string message) : base(message)
        {

        }
    }
}
