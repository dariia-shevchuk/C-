// See https://aka.ms/new-console-template for more information
using FunWithInterfaces;

Console.WriteLine("*** Interface the problem ***");
var c1 = new Circle();
Print(c1);
var r1 = new Rectangle();
Print(r1);

IPerson p1 = new Employee("Jacek");
GetData(p1);

var customer = new Customer("Ewa");
GetData(customer);

IPerson prist = new Prist("Tadeusz");
GetData(prist);

Console.WriteLine("*** Interface Hierarchy ***");
var hex = new Hexagon();
Print(hex);
Print3D(hex);
//Print3D(c1); to się nie kompuluje, circle jest kształtem ale nie super kształtem z 3D
var sender = new DataSender();
sender.SendData(new byte[] { 0x01, 0x02, 0x01, 0x03, 0x07 }); // wysyłąme dane przez TCP
(sender as INfc).SendData(new byte[] { 0x08, 0x09 });

IShape[] shapes = new IShape[] { c1, r1, hex };
foreach (var item in shapes)
{
    item.DrawMe();
}
var r = GetShape(100);
Console.ReadLine();

static void Print(IShape shape)
{
    shape.DrawMe();
}

static void Print3D(ISuperShape shape)
{
    shape.Draw3D();
}

static void GetData(IPerson person)
{
    Console.WriteLine(person.GetData());
}

static IShape GetShape(int i)
{
    switch (i)
    {
        case 0: return new Circle();
        case 1: return new Rectangle();
        default:
            return new Hexagon();
    }
}