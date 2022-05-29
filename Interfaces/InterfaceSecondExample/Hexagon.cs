namespace InterfaceSecondExample
{
    public class Hexagon : IShape
    {

        /// <summary>
        /// Metoda z interfejsu IShape
        /// </summary>
        public void DrawMe()
        {
            Console.WriteLine("Rysuje sześciokąt");
        }
    }
}