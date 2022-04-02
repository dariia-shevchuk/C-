using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ap.SlMarsRover.Base
{
    public abstract class Step
    {
        public Step(string name)
        {
            Nmae = name;
        }
        public string Nmae { get; }

        internal Status Status { get; }

        public void DoWork()
        {
            Status = Status.Processing;
            OnDoWork();
        }

        protected abstract void OnDoWork();
    }
}
