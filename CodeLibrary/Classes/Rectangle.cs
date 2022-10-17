using CoreLibrary.Interfaces;

namespace CoreLibrary.Classes
{
    public class Rectangle : IShape
    {
        public void DrowMe()
        {
            System.Console.WriteLine("Rysuje prostokąt w konsoli!");
        }
    }
}
