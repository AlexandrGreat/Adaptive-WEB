using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using LR6.Models;
using Microsoft.AspNetCore.Authorization;

namespace LR6.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoggedInUserController:ControllerBase
    {
        [HttpGet("CurrentUser")]
        [Authorize]
        public IActionResult UserEndpoint()
        {
            var currentUser=GetCurrentUser();
            return Ok("Hello there :)\n" +
                currentUser.Name + "\n" +
                currentUser.Surname + "\n" +
                currentUser.Email + "\n" +
                currentUser.LastLogin) ;
        }

        private User GetCurrentUser() 
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null) 
            {
                var userClaims=identity.Claims;

                return new User
                {
                    Name = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier)?.Value,
                    Surname = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Surname)?.Value,
                    Email = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Email)?.Value,
                    LastLogin = DateOnly.FromDateTime(DateTime.Now),
                };
            }
            return null;
        }
    }
}
