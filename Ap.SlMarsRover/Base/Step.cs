using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ap.SlMarsRover.Base
{


    public abstract class Step : StpeCore
    {
        protected Step(string name) 
            : base(name)
        {
        }

        public void DoWork()
        {
            Status = Status.Processing;
            OnDoWork();
        }

        protected abstract void OnDoWork();
    }
}
