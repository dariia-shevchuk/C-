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
}
