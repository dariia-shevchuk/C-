using Ap.SlMarsRover.Base;
using AP.SlLoggerr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ap.SlMarsRover
{
    public class MarsRover
    {
        byte bateryPower = 100;

        public MarsRover(Logger logger)
        {
            logger.LogInformation("Czesc tu konstruktor łazika marsjańskiego");
        }
    }



    public enum Status
    {
        Success,
        Fail,
        Waiting,
        Processing
    }
}
