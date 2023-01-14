namespace FunWithGeneric
{
    public class Point<T> where T : struct
    {
        public Point(T x, T y)
        {
            X = x;
            Y = y;
        }

        public T X { get; private set; }

        public T Y { get; private set; }

        public void Reset()
        {

            X = default(T);
            Y = default(T);
        }

        public override string ToString()
        {
            return $"X: {X}, Y: {Y}";
        }
    }
}
