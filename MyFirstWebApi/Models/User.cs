namespace MyFirstWebApi.Models
{
    public class User
    {
        public User(string email, string password, string firstName, string lastName)
        {
            Email = email;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
        }

        public User(int id, string email, string password, string firstName, string lastName)
            : this(email, password, firstName, lastName)
        {
            Id = id;
        }

        public int Id { get; set; }
        public string Email { get; }
        public string Password { get; }
        public string FirstName { get; }
        public string LastName { get; }
    }
}

