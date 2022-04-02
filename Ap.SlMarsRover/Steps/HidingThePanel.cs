using Ap.SlMarsRover.Base;

namespace Ap.SlMarsRover.Steps
{
    public class HidingThePanel : Step
    {
        public HidingThePanel() : base("chowanie panel")
        {
        }

        protected override void OnDoWork()
        {
            Console.WriteLine("Zaczynam chowanie panele");

            Thread.Sleep(1000);
            Random r = new Random();
            Status = r.Next(1, 20) < 16 ? Status.Fail : Status.Success;
            Console.WriteLine("Kończe chowanie panele ze statusem: {0}", Status);
        }
    }
}


