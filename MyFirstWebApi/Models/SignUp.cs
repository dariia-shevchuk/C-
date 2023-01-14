namespace MyFirstWebApi.Models
{
    public class SignUp : SignIn
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}