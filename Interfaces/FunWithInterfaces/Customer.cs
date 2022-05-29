namespace FunWithInterfaces
{
    public class Customer : IPerson

    {
        public Customer(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public string GetData()
        {
            return $"Klient o imieniu {Name}";
        }
    }
}