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

Console.ReadLine();

static void Print(IShape shape)
{
    shape.DrawMe();
}

static void GetData(IPerson person)
{
    Console.WriteLine(person.GetData());
}