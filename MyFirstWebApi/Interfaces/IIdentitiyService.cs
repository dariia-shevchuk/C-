using MyFirstWebApi.Models;

namespace MyFirstWebApi.Interfaces
{
    public interface IIdentitiyService
    {
        void SignUp(SignUp signUp);

        AuthDto SignIn(SignIn signIn);
    }
}