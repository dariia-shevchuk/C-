using AP.SlLoggerr;

namespace LoggerExampleApp
{
    public class FileLogger : LoggerBase
    {
        public override void SendLog(string msg)
        {
            File.AppendAllLines("Log.txt", new string[] { msg });
        }
    }
}
