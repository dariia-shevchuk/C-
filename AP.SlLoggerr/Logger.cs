using AP.SlLoggerr.Enums;
using System.Runtime.CompilerServices;

namespace AP.SlLoggerr
{
    public class Logger
    {
        public Logger(LogLevel level)
        {
            _level = level;
        }

        private LogLevel _level;


        public void LogTrace(string message,
            [CallerFilePath] string filePath = "", [CallerMemberName] string caller = "", [CallerLineNumber]int lineNumber = 0)
        {
            string formatedMessage = FormatMessage(message, filePath, caller, lineNumber);
            Log(formatedMessage, LogLevel.Trace);
        }


        public void LogDebug(string message,
            [CallerFilePath] string filePath = "", [CallerMemberName] string caller = "", [CallerLineNumber] int lineNumber = 0)
        {
            string formatedMessage = FormatMessage(message, filePath, caller, lineNumber);
            Log(formatedMessage, LogLevel.Debug);

        }

        public void LogInformation(string message,
            [CallerFilePath] string filePath = "", [CallerMemberName] string caller = "", [CallerLineNumber] int lineNumber = 0)

        {
            string formatedMessage = FormatMessage(message, filePath, caller, lineNumber);
            Log(formatedMessage, LogLevel.Information);

        }

        public void LogWarning(string message,
            [CallerFilePath] string filePath = "", [CallerMemberName] string caller = "", [CallerLineNumber] int lineNumber = 0)
        {

            string formatedMessage = FormatMessage(message, filePath, caller, lineNumber);
            Log(formatedMessage, LogLevel.Warning);

        }

        public void LogError(string message,
            [CallerFilePath] string filePath = "", [CallerMemberName] string caller = "", [CallerLineNumber] int lineNumber = 0)
        {
            string formatedMessage = FormatMessage(message, filePath, caller, lineNumber);
            Log(formatedMessage, LogLevel.Error);

        }

        public void LogCritical(string message,
            [CallerFilePath] string filePath = "", [CallerMemberName] string caller = "", [CallerLineNumber] int lineNumber = 0)
        {
            string formatedMessage = FormatMessage(message, filePath, caller, lineNumber);
            Log(formatedMessage, LogLevel.Critical);

        }

        private void Log(string msg, LogLevel level)
        {
            if (_level <= level)
                Console.WriteLine($"{DateTime.Now} - {level}: " + msg);
        }


        private static string FormatMessage(string message, string filePath, string caller, int lineNumber)
        {
            return "plik: " + filePath + " metoda: " + caller + " numer lini: " + lineNumber + "\n\t" + message;
        }

    }
}
