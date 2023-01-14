using MyFirstWebApi.Models;

namespace MyFirstWebApi.Interfaces
{
    public interface IIdentityService
    {
        void SignUp(SignUp signUp);
    }
}
