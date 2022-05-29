// See https://aka.ms/new-console-template for more information
using InterfaceSecondExample;
using System.Collections;

System.Collections.IEnumerable a = null;
System.Collections.IEnumerator b = null;

var r1 = new Rectangle();
var c1 = new Circle();
var hex = new Hexagon();

IShape[] shapes = new IShape[] { c1, r1, hex };
foreach (var item in shapes)
{
    item.DrawMe();
}
Console.WriteLine(new String('-', 40));

var enumerator = shapes.GetEnumerator();

while (enumerator.MoveNext())
{
    var item = enumerator.Current;
    ((IShape)item).DrawMe();
}
Console.WriteLine(new String('-', 40));
var myCollection = new ShapeCollection();
foreach (var item in myCollection)
{
    ((IShape)item).DrawMe();
}

public class ShapeCollection : IEnumerable
{
    private IShape[] shapes;

    public ShapeCollection()
    {
        shapes = new IShape[5]
        {
            new Circle(),
            new Hexagon(),
            new Hexagon(),
            new Rectangle(),
            new Rectangle(),
        };
    }

    public IEnumerator GetEnumerator()
    {
        Console.WriteLine("W metodzie IEnumerable.GetEnumerator");
        return new MyEnumerator(shapes);
    }
}

public class MyEnumerator : IEnumerator
{
    private readonly IShape[] shapes;
    private int index = -1;

    public MyEnumerator(IShape[] shapes)
    {
        this.shapes = shapes;
    }

    public object Current
    {
        get
        {
            Console.WriteLine("W IEnumerator.Current");
            return shapes[index];
        }
    }

    public bool MoveNext()
    {
        Console.WriteLine("W IEnumerator.MoveNext");
        index++;
        return index < shapes.Length;
    }

    public void Reset()
    {
        Console.WriteLine("W IEnumerator.Reset");
        index = -1;
    }
}