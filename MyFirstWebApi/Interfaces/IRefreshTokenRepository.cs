using MyFirstWebApi.Models;

namespace MyFirstWebApi.Interfaces
{
    public interface IRefreshTokenRepository
    {
        RefreshToken Get(string token);

        void Add(RefreshToken token);

        void Update(RefreshToken token);
    }
}