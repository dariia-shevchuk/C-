namespace MyFirstWebApi.Interfaces
{
    public interface IPasswordService
    {
        bool IsValid(string password1, string password2);

        string Hash(string password);
    }
}

