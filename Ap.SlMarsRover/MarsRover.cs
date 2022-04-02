using Ap.SlMarsRover.Base;
using Ap.SlMarsRover.Tasks;
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
        private SolarPanelsFoldingTask solarPanelsFoldingTask;
        private SolarPanelsUnfoldingTask solarPanelsUnfoldingTask;  

        public MarsRover(Logger logger)
        {
            logger.LogInformation("Czesc tu konstruktor łazika marsjańskiego");
            solarPanelsFoldingTask = new SolarPanelsFoldingTask();
            solarPanelsUnfoldingTask = new SolarPanelsUnfoldingTask();

        }

        public void RunTasks()
        {
            solarPanelsFoldingTask.Run();
            Console.WriteLine("----------------------");
            solarPanelsUnfoldingTask.Run();

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
