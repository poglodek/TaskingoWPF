namespace TaskingoApp.Exceptions
{
    public class ApiServerErrorException : ApiBaseException
    {
        public ApiServerErrorException(string message) : base(message)
        {

        }
    }
}
