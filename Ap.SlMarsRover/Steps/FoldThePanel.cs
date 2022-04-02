using Ap.SlMarsRover.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ap.SlMarsRover.Steps
{
    public class FoldThePanel : Step
    {
        public FoldThePanel() 
            : base("żłóż panel")
        {
        }

        protected override void OnDoWork()
        {
            Console.WriteLine("Zaczynam " + Name);

            Thread.Sleep(1000);

            Random r = new Random();
            Status = r.Next(1, 20) < 16 ? Status.Fail : Status.Success;
            Console.WriteLine($"Kończe {Name} ze statusem: {Status}");


        }
    }

    public class UnfoldPanel : Step
    {
        public UnfoldPanel()
            : base("rozłóż panel")
        {
        }

        protected override void OnDoWork()
        {
            Console.WriteLine("Zaczynam rozkładać panele");

            Thread.Sleep(1000);

            Random r = new Random();
            Status = r.Next(1, 20) < 16 ? Status.Fail : Status.Success;
            Console.WriteLine("Kończe rozkładać panele ze statusem: {0}", Status);


        }
    }
}
