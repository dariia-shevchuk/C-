using Ap.SlMarsRover.Base;
using Ap.SlMarsRover.Steps;

namespace Ap.SlMarsRover.Tasks
{
    // Rozkłądanie paneli słonecznych 
    // - otworz kalpe - status ok
    // - wystawienie paneli - staus ok 
    // - rozłożenie paneli - ok
    // Rozkłądanie paneli słonecznych - status ok
    public class SolarPanelsUnfoldingTask : TaskBase
    {
        public SolarPanelsUnfoldingTask()
            : base(new Step[]
            {
                new OpeningTheFlap(), new UnfoldPanel()
            }, "Rozkłądanie paneli słonecznych")
        {
        }

        public override int RequiredBateryPower { get; } = 5;
    }

}
