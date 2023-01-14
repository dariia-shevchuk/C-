namespace MyFirstWebApi.Interfaces
{
    public interface IRng
    {
        string Generate(int length = 50, bool removeSpecialChars = false);
    }
}