namespace TaskingoApp.Exceptions
{
    public class ConflictException : ApiBaseException
    {
        public ConflictException(string message) : base(message)
        {

        }
    }
}
