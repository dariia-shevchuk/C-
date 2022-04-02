using Ap.SlMarsRover.Base;

namespace Ap.SlMarsRover.Steps
{
    public class OpeningTheFlap : Step
    {
        public OpeningTheFlap() : base("otwieranie kalpy")
        {
        }

        protected override void OnDoWork()
        {

            Console.WriteLine("Zaczynam otwierać klape");

            Thread.Sleep(1000);
            Random r = new Random();
            Status = r.Next(1, 20) < 16 ? Status.Fail : Status.Success;
            Console.WriteLine("Kończe otwierać klape ze statusem: {0}", Status);
        }
    }
}


