using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ap.SlMarsRover.Base
{
    public abstract class TaskBase : StpeCore
    {
        Step[] _steps;

        public TaskBase(Step[] steps, string name)
            : base(name)
        {
            _steps = steps;
        }

        public abstract int RequiredBateryPower { get; }

        public void Run()
        {
            Status = Status.Processing;
            foreach (var step in _steps)
            {
                while (step.Status != Status.Success)
                    step.DoWork();
            }
        }
    }
}

//nazwe, status, liste kroków

//nazwe, status, 


//klasa, ktora ma nazwe i status
// |
// klasa task a sama dodaje liste kroków