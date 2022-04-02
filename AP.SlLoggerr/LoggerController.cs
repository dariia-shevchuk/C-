using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.SlLoggerr
{
    public class LoggerController
    {
        private LoggerBase[] _loggerBases;

        public LoggerController(LoggerBase[] loggerBases)
        {
            _loggerBases = loggerBases;
        }


        internal void Log(string msg)
        {
            foreach (var loggerBase in _loggerBases)
            {
                loggerBase.SendLog(msg);
            }

        }
    }
}
