using AP.SlLoggerr;

namespace LoggerExampleApp
{
    public class NewSomStufLogger : LoggerBase
    {
        public override void SendLog(string msg)
        {
            var oldColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(msg);

            Console.ForegroundColor = oldColor;
        }
    }
}
