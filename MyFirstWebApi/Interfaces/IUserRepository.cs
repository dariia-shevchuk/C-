using MyFirstWebApi.Models;

namespace MyFirstWebApi.Interfaces
{
    public interface IUserRepository
    {
        User GetByEmail(string email);

        void Add(User user);

        User Get(int id);
    }
}