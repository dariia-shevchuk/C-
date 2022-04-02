namespace Ap.SlMarsRover.Base
{
    public abstract class StpeCore
    {
        public string Name { get; }

        public Status Status { get; protected set; } = Status.Waiting;

        public StpeCore(string name)
        {
            Name = name;
        }
    }
}
