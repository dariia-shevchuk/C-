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
            Console.WriteLine("Trace: " + message);
        }

        public void LogDebug(string messagew)
        {
            Console.WriteLine(messagew);
        }

        public void LogInformation(string messagew)
        {
            Console.WriteLine(messagew);
        }

        public void LogWarning(string messagew)
        {
            Console.WriteLine(messagew);
        }

        public void LogError(string messagew)
        {
            Console.WriteLine(messagew);
        }

        public void LogCritical(string messagew)
        {
            Console.WriteLine(messagew);
        }

    }
}
