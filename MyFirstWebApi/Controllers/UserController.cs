using Microsoft.AspNetCore.Mvc;
using MyFirstWebApi.Interfaces;
using MyFirstWebApi.Models;

namespace MyFirstWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IIdentityService _identityService;

        public UserController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [HttpPost]
        public ActionResult Post([FromBody] SignUp signUp)
        {
            _identityService.SignUp(signUp);
            return Created("", signUp);
        }
    }
}
