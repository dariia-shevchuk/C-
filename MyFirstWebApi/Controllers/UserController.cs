using Microsoft.AspNetCore.Mvc;
using MyFirstWebApi.Interfaces;
using MyFirstWebApi.Models;

namespace MyFirstWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IIdentitiyService _identityuService;
        private readonly IRefreshTokenService _refreshTokenService;

        public UserController(IIdentitiyService identityuService, IRefreshTokenService refreshTokenService)
        {
            _identityuService = identityuService;
            _refreshTokenService = refreshTokenService;
        }

        [HttpPost("SignUp")]
        public ActionResult SignUp([FromBody] SignUp signUp)
        {
            _identityuService.SignUp(signUp);
            return Created("", signUp);
        }

        [HttpPost("SignIn")]
        public AuthDto SignIn([FromBody] SignIn signIn)
        {
            return _identityuService.SignIn(signIn);
        }

        [HttpPost("refresh-token/use")]
        public AuthDto Use([FromBody] UseRefreshToken useRefreshToken)
        {
            return _refreshTokenService.Use(useRefreshToken.RefreshToken);
        }

        [HttpPost("refresh-token/Revoke")]
        public ActionResult Revoke([FromBody] RevokeRefreshToken command)
        {
            _refreshTokenService.Revoke(command.RefreshToken);
            return new NoContentResult();
        }
    }
}
