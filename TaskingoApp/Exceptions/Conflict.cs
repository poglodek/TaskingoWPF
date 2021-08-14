namespace TaskingoApp.Exceptions
{
    public class Conflict : ApiBaseException
    {
        public Conflict(string message) : base(message)
        {

        }
    }
}
