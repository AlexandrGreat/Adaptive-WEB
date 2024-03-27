using LR6.Models;
using LR6.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LR6.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly LoginService _loginService;

        public LoginController(LoginService loginService)
        {
            _loginService=loginService;
        }

        [AllowAnonymous]
        [HttpPost("sign-in")]
        public IActionResult login([FromBody]LoginModel loginModel)
        {
            var result= _loginService.Login(loginModel);
            if (result == "User not found") return NotFound("User not found");
            return Ok(result);
        }

        [HttpPost("sign-up")]
        public Task<User[]> RegisterUser(RegistrationModel newUser)
        {
            return _loginService.RegisterUser(newUser);
        }
    }
}
