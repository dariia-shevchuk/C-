using Ap.SlMarsRover.Base;

namespace Ap.SlMarsRover.Steps
{
    public class ClosingTheFlap : Step
    {
        public ClosingTheFlap() : base("zamknięcie kalpy")
        {
        }

        protected override void OnDoWork()
        {

            Console.WriteLine("Zaczynam zamykać klape");

            Thread.Sleep(1000);
            Random r = new Random();
            Status = r.Next(1, 20) < 16 ? Status.Fail : Status.Success;
            Console.WriteLine("Kończe zamykać klape ze statusem: {0}", Status);
        }
    }
}


