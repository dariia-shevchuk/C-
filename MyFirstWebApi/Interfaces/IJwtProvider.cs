using MyFirstWebApi.Models;

namespace MyFirstWebApi.Interfaces
{
    public interface IJwtProvider
    {
        AuthDto Create(int userId);
    }
}