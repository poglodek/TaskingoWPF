namespace TaskingoApp.Exceptions
{
    public class Unauthorized : ApiBaseException
    {
        public Unauthorized(string message) : base(message)
        {

        }

    }
}
