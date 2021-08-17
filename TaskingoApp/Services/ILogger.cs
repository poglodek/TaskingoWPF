namespace TaskingoApp.Services
{
    public interface ILogger
    {
        void Log(string message);
        void Log(string prefix, string message);
    }
}