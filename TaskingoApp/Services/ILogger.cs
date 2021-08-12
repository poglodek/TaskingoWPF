namespace TaskingoApp.Services
{
    public interface ILogger
    {
        public void Log(string message);
        void Log(string prefix, string message);
    }
}