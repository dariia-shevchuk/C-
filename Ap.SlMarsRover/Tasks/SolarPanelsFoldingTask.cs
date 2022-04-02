using Ap.SlMarsRover.Base;
using Ap.SlMarsRover.Steps;

namespace Ap.SlMarsRover.Tasks
{
    // Składanie paneli słonecznych
    //  - żłóż panel status ok
    //  - schowanie - status ok
    //  - zamknięcie kalpy - status ok
    // Składanie paneli słonecznych Ok
    public class SolarPanelsFoldingTask : TaskBase
    {
        public SolarPanelsFoldingTask()
            : base(new Step[] {
                new FoldThePanel(), new HidingThePanel(), new ClosingTheFlap()
            }, "Składanie paneli słonecznych")
        {
        }

        public override int RequiredBateryPower { get; } = 5;
    }
}
