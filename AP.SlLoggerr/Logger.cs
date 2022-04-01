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
            if(_level <= LogLevel.Trace)
                Console.WriteLine("Trace: " + message);
        }

        public void LogDebug(string messagew)
        {
            if (_level <= LogLevel.Debug)
                Console.WriteLine("Debug: " + messagew);
        }

        public void LogInformation(string messagew)
        {
            if (_level <= LogLevel.Information)
                Console.WriteLine("Information: "+ messagew);
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
