using AP.SlLoggerr.Enums;

namespace AP.SlLoggerr
{
    public class Logger
    {
        public Logger(LogLevel level)
        {
            _level = level;
        }

        private LogLevel _level;


        public void LogTrace(string message)
        {
            Log(message, LogLevel.Trace);
        }

        public void LogDebug(string message)
        {
            Log(message, LogLevel.Debug);

        }

        public void LogInformation(string message)
        {
            Log(message, LogLevel.Information);

        }

        public void LogWarning(string message)
        {
            Log(message, LogLevel.Warning);

        }

        public void LogError(string message)
        {
            Log(message, LogLevel.Error);

        }

        public void LogCritical(string message)
        {
            Log(message, LogLevel.Critical);

        }

        private void Log(string msg, LogLevel level)
        {
            if (_level <= level)
                Console.WriteLine($"{level}: " + msg);
        }

    }
}
