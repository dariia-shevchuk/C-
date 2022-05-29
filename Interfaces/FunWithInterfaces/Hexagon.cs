// See https://aka.ms/new-console-template for more information
using FunWithInterfaces;

public class Hexagon : ISuperShape
{
    /// <summary>
    /// Metoda z interfejsu ISuperShape
    /// </summary>
    public void Draw3D()
    {
        Console.WriteLine("Rysuje sześciokąt w super 3D");
    }

    /// <summary>
    /// Metoda z interfejsu IShape
    /// </summary>
    public void DrawMe()
    {
        Console.WriteLine("Rysuje sześciokąt");
    }
}