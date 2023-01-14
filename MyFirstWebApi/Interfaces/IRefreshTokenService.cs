using MyFirstWebApi.Models;

namespace MyFirstWebApi.Interfaces
{
    public interface IRefreshTokenService
    {
        string Create(int id);

        AuthDto Use(string refreshToken);

        void Revoke(string refreshToken);
    }
}