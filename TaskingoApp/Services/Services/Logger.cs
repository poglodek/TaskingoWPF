using System;
using System.IO;
using TaskingoApp.Builder;
using TaskingoApp.Services.IServices;

namespace TaskingoApp.Services.Services
{
    public class Logger : ILogger
    {
        private const string Path = "log/";

        public void Log(string message)
        {
            Log("INFO", message);
        }
        public void Log(string prefix, string message)
        {
            var loggingMessage = $"|{DateTime.Now}|{prefix}|{message}";
            LogToFile(loggingMessage);
        }

        private void LogToFile(string message)
        {
            var today = DateTime.Now.ToString("dd-MM-yyyy");
            var logFile = $"{Path}log-{today}.log";
            if (!File.Exists(logFile))
                CreateFile(today, logFile);
            else
                try
                {
                    using var streamWriter = File.AppendText(logFile);
                    streamWriter.WriteLine(message);
                }
                catch
                {
                    PopupBuilder.Build("Cannot log error. Please contact with Admin");
                }
        }

        private void CreateFile(string today, string log)
        {
            try
            {
                Directory.CreateDirectory(Path);
                File.Create(log);
            }
            catch
            {
                PopupBuilder.Build("Cannot create a log file. Please contact with Admin");
            }

        }
    }
}
