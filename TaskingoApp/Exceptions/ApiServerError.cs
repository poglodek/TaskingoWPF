namespace TaskingoApp.Exceptions
{
    public class ApiServerError : ApiBaseException
    {
        public ApiServerError(string message) : base(message)
        {

        }
    }
}
