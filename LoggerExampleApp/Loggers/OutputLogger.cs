using AP.SlLoggerr;
using System.Diagnostics;

namespace LoggerExampleApp
{
    public class OutputLogger : LoggerBase
    {
        public override void SendLog(string msg)
        {
            Debug.WriteLine(msg);
        }
    }
}
