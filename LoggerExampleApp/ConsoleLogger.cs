using AP.SlLoggerr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerExampleApp
{
    public class ConsoleLogger : LoggerBase
    {
        public override void SendLog(string msg)
        {
            Console.WriteLine(msg);
        }
    }

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
