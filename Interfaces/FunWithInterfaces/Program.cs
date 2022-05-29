// See https://aka.ms/new-console-template for more information
using FunWithInterfaces;

Console.WriteLine("*** Interface the problem ***");
var c1 = new Circle();
Print(c1);
var r1 = new Rectangle();
Print(r1);

Console.ReadLine();

static void Print(IShape shape)
{
    shape.DrawMe();
}