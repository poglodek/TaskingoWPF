namespace TaskingoApp.Services.IServices
{
    public interface ILogger
    {
        void Log(string message);
        void Log(string prefix, string message);
    }
}