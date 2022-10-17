using CoreLibrary.Interfaces;

namespace CoreLibrary.Classes
{
    public class Employee : IPerson
    {
        public Employee(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        public string FirstName { get; }

        public string LastName { get; }

        public int Age { get; }

        public override string ToString()
        {
            return $"FirstName: {FirstName}, LastName: {LastName}, Age: {Age}";
        }
    }
}
