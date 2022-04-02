using Ap.SlMarsRover.Base;

namespace Ap.SlMarsRover
{
    // Rozkłądanie paneli słonecznych 
    // - otworz kalpe - status ok
    // - wystawienie paneli - staus ok 
    // - rozłożenie paneli - ok
    // Rozkłądanie paneli słonecznych - status ok
    public class SolarPanelsUnfoldingTask
    {
        private byte _requiredBateryPower = 5;

        private Status _status = Status.Waiting;


        Step[] _steps;

        public SolarPanelsUnfoldingTask(Step[] steps)
        {
            _steps = steps;
        }

        public void Run()
        {
            _status = Status.Processing;
            foreach (var step in _steps)
            {
                while (step.Status == Status.Success)
                    step.DoWork();
            }
        }

    }

    // Składanie paneli słonecznych
    //  - żłóż panel status ok
    //  - schowanie - status ok
    //  - zamknięcie kalpy - status ok
    // Składanie paneli słonecznych Ok
    public class SolarPanelsFoldingTask
    {
        private byte _requiredBateryPower = 5;

        private Status _status = Status.Waiting;

        Step[] _steps;

        public SolarPanelsFoldingTask(Step[] steps)
        {
            _steps = steps;
        }

        public void Run()
        {
            _status = Status.Processing;
            foreach (var step in _steps)
            {
                while(step.Status == Status.Success)
                step.DoWork();
            }
        }
    }

}
