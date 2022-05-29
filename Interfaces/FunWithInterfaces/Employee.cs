namespace FunWithInterfaces
{
    public class Employee : IPerson
    {
        public Employee(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public string GetData()
        {
            return $"Pracownik o imieniu {Name}";
        }
    }

    public abstract class Person : IPerson
    {
        public Person(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public string GetData()
        {
            Console.WriteLine("w kalsie bzowej");
            return OnGetData();
        }

        protected abstract string OnGetData();
    }

    public class Prist : Person
    {
        public Prist(string name) : base(name)
        {
        }

        protected override string OnGetData()
        {
            return $"Ksiad o imieniu {Name}";
        }
    }
}