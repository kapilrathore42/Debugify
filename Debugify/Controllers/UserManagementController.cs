using Debugify.Application.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Debugify.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserManagementController : ControllerBase
    {
        UserManagementController() { }
        [HttpPost("login")]
        public IActionResult Login([FromBody] UserLoginModel userLogin)
        {
            // Validate user credentials (this is just a sample; use secure validation in production)
            if (userLogin.Username == "test" && userLogin.Password == "password")
            {
                var tokenGenerator = new JwtTokenGenerator();
                var token = tokenGenerator.GenerateToken(userLogin.Username);
                return Ok(new { Token = token });
            }
            return Unauthorized("Invalid username or password");
        }

    }
}
