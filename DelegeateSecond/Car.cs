namespace DelegeateSecond
{
    public class Car
    {
        public delegate void CarMaintenceDelegate(Car c);



        public Car(string carName, bool isDirty, bool shouldByRotate)
        {
            CarName = carName;
            IsDirty = isDirty;
            ShouldByRotate = shouldByRotate;
        }

        public string CarName { get; }
        public bool IsDirty { get; }
        public bool ShouldByRotate { get; }
    }
}
