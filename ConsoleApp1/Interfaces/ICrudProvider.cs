namespace ConsoleApp1.Interfaces
{
    public interface ICrudProvider<T>
    {
        ICrud<T> GetCrud();

        void SetCurrentCrudOption(string dbName);
    }
}
